using System;

namespace modern_calculator.MVVM.Model
{
    [Serializable]
    internal class SettingsModel
    {
        public SettingsModel()
        {
            BlurredBackground = false;
            SysMonitorRefreshDelay = 0.2f;
        }
        public SettingsModel(float sysMonitorDelay, bool blurredBackground)
        {
            SysMonitorRefreshDelay = sysMonitorDelay;
            BlurredBackground = blurredBackground;
        }
        public float SysMonitorRefreshDelay { get; private set; }
        public bool BlurredBackground { get; private set; }
    }
}
