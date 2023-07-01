using modern_calculator.Core;
using System.Windows;
using System.Windows.Controls;

namespace modern_calculator.MVVM.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            BlurredCheckbox.IsChecked = AppState.Settings.BlurredBackground;
        }
        private void BlurredCheckbox_Click(object sender, RoutedEventArgs e)
        {
            AppState.Settings.BlurredBackground = BlurredCheckbox.IsChecked ?? false;
        }
    }
}
