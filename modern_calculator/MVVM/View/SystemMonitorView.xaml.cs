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
            if(!PC.Opened) PC.Open();
            Random rand = new Random();
            int cpuLoad = 0, gpuLoad, ramLoad;
            await Task.Run(() =>
            {
                while (true)
                {
                    double xCPU, yCPU, xGPU, yGPU, xRAM, yRAM;
                    cpuLoad += GetCpuLoad()*2; //Slightly stabilize CPU usage
                    cpuLoad /= 3; //because OpenHardwareMonitor gives not quite accurate values
                    gpuLoad = GetGpuLoad();
                    ramLoad = GetRamLoad();
                    (xCPU, yCPU) = GetPointPos(cpuLoad);
                    (xGPU, yGPU) = GetPointPos(gpuLoad);
                    (xRAM, yRAM) = GetPointPos(ramLoad);
                    Application.Current.Dispatcher.Invoke(new Action(() => {
                        pbCPU.ArcSeg.Point = new Point(xCPU, yCPU);
                        pbCPU.ArcSeg.IsLargeArc = cpuLoad > 100 / 3 * 2;
                        pbCPU.Load.Text = cpuLoad+"%";
                        pbGPU.ArcSeg.Point = new Point(xGPU, yGPU);
                        pbGPU.ArcSeg.IsLargeArc = gpuLoad > 100 / 3 * 2;
                        pbGPU.Load.Text = gpuLoad + "%";
                        pbRAM.ArcSeg.Point = new Point(xRAM, yRAM);
                        pbRAM.ArcSeg.IsLargeArc = ramLoad > 100 / 3 * 2;
                        pbRAM.Load.Text = ramLoad + "%";
                    }));
                    Thread.Sleep(100);
                }
            });
        }
        private (double, double) GetPointPos(int procents)
        {
            if (procents == 0) return (-35.34, 35.34);
            double angle = 2.7 * procents - 225;
            return (50 * Math.Cos(angle * Math.PI / 180), 50 * Math.Sin(angle * Math.PI / 180));
        }
        private int GetCpuLoad()
        {
            int load = 0;
            float speed = 0;
            foreach (var hardwareItem in PC.thisComputer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.CPU)
                {
                    hardwareItem.Update();
                    foreach (IHardware subHardware in hardwareItem.SubHardware)
                        subHardware.Update();
                    foreach (var sensor in hardwareItem.Sensors) { 
                        if (sensor.SensorType == SensorType.Load && (int)sensor.Value>load) load = (int)sensor.Value;
                        if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("CPU")) speed = sensor.Value??PC.baseCPUSpeed;
                    }
                }
            }
            return (int)Math.Round(load * (speed/PC.baseCPUSpeed), 0);
        }
        private int GetGpuLoad()
        {
            int load = 0;
            foreach (var hardwareItem in PC.thisComputer.Hardware)
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
            double ram = PC.totalRAM - Math.Round(memory / 1000, 1);
            return (int)(ram/PC.totalRAM*100);
        }
    }
}
