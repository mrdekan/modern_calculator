using modern_calculator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
