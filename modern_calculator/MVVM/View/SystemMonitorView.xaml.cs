using modern_calculator.Controls;
using modern_calculator.Core;
using OpenHardwareMonitor.Hardware;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace modern_calculator.MVVM.View
{
    /// <summary>
    /// Interaction logic for SystemMonitorView.xaml
    /// </summary>
    public partial class SystemMonitorView : UserControl
    {
        private CircularProgressBar pbCPU = new CircularProgressBar();
        private CircularProgressBar pbGPU = new CircularProgressBar();
        private CircularProgressBar pbRAM = new CircularProgressBar();
        private const int RADIUS = 50;
        private const double PERCENT_TO_ANGLE = 2.7;
        private const int START_POS_IN_PROGRESS_BAR = 225;
        private const double SWITCHING_TO_LARGE_ARC = 100 / 3 * 2;
        public SystemMonitorView()
        {

            InitializeComponent();
            GridTest.Children.Add(pbCPU);
            GridTest.Children.Add(pbGPU);
            GridTest.Children.Add(pbRAM);
            pbCPU.ArcSeg.Point = new Point(-35.34, 35.34);
            pbCPU.Margin = new Thickness(50, 80, 0, 0);
            pbGPU.ArcSeg.Point = new Point(-35.34, 35.34);
            pbGPU.Margin = new Thickness(200, 80, 0, 0);
            pbGPU.Title.Text = "GPU";
            pbRAM.ArcSeg.Point = new Point(-35.34, 35.34);
            pbRAM.Margin = new Thickness(350, 80, 0, 0);
            pbRAM.Title.Text = "RAM";
            SetProcents();
        }
        private async void SetProcents()
        {
            await Task.Run(() =>
            {
                if (!AppState.ThisPC.Opened)
                    AppState.ThisPC.Open();
                Random rand = new Random();
                int cpuLoad = 0,
                    gpuLoad = 0,
                    ramLoad = 0;
                while (true)
                {
                    double xCPU, yCPU, xGPU, yGPU, xRAM, yRAM;
                    cpuLoad += GetCpuLoad() * 2; //Slightly stabilize CPU usage
                    cpuLoad /= 3; //because OpenHardwareMonitor gives not quite accurate values
                    gpuLoad = GetGpuLoad();
                    ramLoad = GetRamLoad();
                    (xCPU, yCPU) = GetPointPos(ref cpuLoad);
                    (xGPU, yGPU) = GetPointPos(ref gpuLoad);
                    (xRAM, yRAM) = GetPointPos(ref ramLoad);
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        pbCPU.ArcSeg.Point = new Point(xCPU, yCPU);
                        pbCPU.ArcSeg.IsLargeArc = cpuLoad > SWITCHING_TO_LARGE_ARC;
                        pbCPU.Load.Text = cpuLoad + "%";
                        pbGPU.ArcSeg.Point = new Point(xGPU, yGPU);
                        pbGPU.ArcSeg.IsLargeArc = gpuLoad > SWITCHING_TO_LARGE_ARC;
                        pbGPU.Load.Text = gpuLoad + "%";
                        pbRAM.ArcSeg.Point = new Point(xRAM, yRAM);
                        pbRAM.ArcSeg.IsLargeArc = ramLoad > SWITCHING_TO_LARGE_ARC;
                        pbRAM.Load.Text = ramLoad + "%";
                    }));
                    Thread.Sleep(100);
                }
            });
        }
        private (double, double) GetPointPos(ref int percent)
        {
            if (percent < 0) percent = 0;
            else if (percent > 100) percent = 100;
            if (percent == 0) return (-35.34, 35.34);
            double angle = PERCENT_TO_ANGLE * percent - START_POS_IN_PROGRESS_BAR;
            return (RADIUS * Math.Cos(angle * Math.PI / 180), RADIUS * Math.Sin(angle * Math.PI / 180));
        }
        private int GetCpuLoad()
        {
            int load = 0;
            float speed = 0;
            foreach (var hardwareItem in AppState.ThisPC.thisComputer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.CPU)
                {
                    hardwareItem.Update();
                    foreach (IHardware subHardware in hardwareItem.SubHardware)
                        subHardware.Update();
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Load && (int)sensor.Value > load) load = (int)sensor.Value;
                        if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("CPU")) speed = sensor.Value ?? AppState.ThisPC.baseCPUSpeed;
                    }
                }
            }
            return (int)Math.Round(load * (speed / AppState.ThisPC.baseCPUSpeed), 0);
        }
        private int GetGpuLoad()
        {
            int load = 0;
            foreach (var hardwareItem in AppState.ThisPC.thisComputer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.GpuAti || hardwareItem.HardwareType == HardwareType.GpuNvidia)
                {
                    hardwareItem.Update();
                    foreach (IHardware subHardware in hardwareItem.SubHardware)
                        subHardware.Update();
                    foreach (var sensor in hardwareItem.Sensors)
                        if (sensor.SensorType == SensorType.Load && sensor.Name == "GPU Core") load = (int)sensor.Value;
                }
            }
            return load;
        }
        private int GetRamLoad()
        {
            var performance = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes");
            var memory = performance.NextValue();
            double ram = AppState.ThisPC.totalRAM - Math.Round(memory / 1000, 1);
            return (int)(ram / AppState.ThisPC.totalRAM * 100);
        }
    }
}
