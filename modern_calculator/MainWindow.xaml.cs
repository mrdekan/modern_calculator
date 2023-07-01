using modern_calculator.Core;
using System.Windows;
using System.Windows.Input;

namespace modern_calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppState.ThisPC.Open();
            AppState.Currency.DownloadCurrencyRate();
            AppState.ContentWidth = Content.Width;
            AppState.ContentHeight = Content.Height;
            AppState.ContentMargin = Menu.Width;
            FileWorker.Load();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            FileWorker.Save();
        }

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Title_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }
    }
}
