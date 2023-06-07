using System;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;
namespace modern_calculator.Core
{
    internal class PC
    {
        public OpenHardwareMonitor.Hardware.Computer thisComputer;
        public ComputerInfo PCinfo;
        public double totalRAM = 0;
        public int baseCPUSpeed = 2900; //Set your base CPU speed
        public bool Opened { get; private set; } = false;
        public async void Open()
        {
            await Task.Run(() =>
            {
                PCinfo = new ComputerInfo();
                totalRAM = Math.Round(PCinfo.TotalPhysicalMemory / 1073741824.0, 1);
                thisComputer = new OpenHardwareMonitor.Hardware.Computer()
                {
                    CPUEnabled = true,
                    GPUEnabled = true,
                };
                thisComputer.Open();
                Opened = true;
            });
        }
    }
}
