using System;

namespace modern_calculator.MVVM.Model
{
    [Serializable]
    internal class SettingsModel
    {
        public float SysMonitorRefreshDelay { get; private set; }
        public bool BlurredBackground { get; private set; }
        public SettingsModel(float sysMonitorDelay, bool blurredBackground)
        {
            SysMonitorRefreshDelay = sysMonitorDelay;
            BlurredBackground = blurredBackground;
        }
    }
}
