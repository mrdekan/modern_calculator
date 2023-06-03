using System;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;
namespace modern_calculator.Core
{
    static internal class PC
    {
        public static OpenHardwareMonitor.Hardware.Computer thisComputer;
        public static ComputerInfo PCinfo;
        public static double totalRAM = 0;
        public static int baseCPUSpeed = 2900;
        public static bool Opened { get; private set; } = false;
        public async static void Open()
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
