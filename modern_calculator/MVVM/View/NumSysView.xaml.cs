using System;
using System.Collections.Generic;
using System.Linq;
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

namespace modern_calculator.MVVM.View
{
	/// <summary>
	/// Interaction logic for NumSysView.xaml
	/// </summary>
	public partial class NumSysView : UserControl
	{
		private int inputNumSys;
		public NumSysView()
		{
			InitializeComponent();
		}
		private static bool HasNotMoreOneComma(string s)
		{
			int count = 0;
			foreach(char c in s) if(c == ',' || c == '.') count++;
			return count < 1;
		}
		private void NumSys_input_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.OemComma || e.Key == Key.OemPeriod)
			{
				if(NumSys_input.Text == "" || !HasNotMoreOneComma(NumSys_input.Text)) e.Handled = true;
				return;
			}
			if (e.Key < Key.D0 || e.Key > Key.D9 || NumSys_input.Text.Length > 26)
			{
				e.Handled = true;
			}
		}
    }
}
