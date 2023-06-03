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
	/// Interaction logic for CalculatorView.xaml
	/// </summary>
	public partial class CalculatorView : UserControl
	{
		private static double calc_operand_a;
		private int calc_operands = 0;
		private char calc_operator = 'n';
		public CalculatorView()
		{
			InitializeComponent();
		}
		private void Print(int n)
		{
			if (Main_operand_calc.Text.Length >= 15) return;
			if (calc_operator == 'n') operand_calc.Text = "";
			if (Main_operand_calc.Text == "0")
			{
				Main_operand_calc.Text = n.ToString();
				return;
			}
			Main_operand_calc.Text += n.ToString();
		}
		#region Numbers Input
		private void One_Click(object sender, RoutedEventArgs e)
		{
			Print(1);
		}

		private void Two_Click(object sender, RoutedEventArgs e)
		{
			Print(2);
		}

		private void Three_Click(object sender, RoutedEventArgs e)
		{
			Print(3);
		}

		private void Four_Click(object sender, RoutedEventArgs e)
		{
			Print(4);
		}

		private void Five_Click(object sender, RoutedEventArgs e)
		{
			Print(5);
		}

		private void Six_Click(object sender, RoutedEventArgs e)
		{
			Print(6);
		}

		private void Seven_Click(object sender, RoutedEventArgs e)
		{
			Print(7);
		}

		private void Eight_Click(object sender, RoutedEventArgs e)
		{
			Print(8);
		}

		private void Nine_Click(object sender, RoutedEventArgs e)
		{
			Print(9);
		}

		private void Zero_Click(object sender, RoutedEventArgs e)
		{
			Print(0);
		}
		#endregion
		#region Calculations
		private double Calc(double a, double b, char op)
		{
			switch (op)
			{
				case '+':
					return a + b;
				case '-':
					return a - b;
				case '×':
					return a * b;
				case '÷':
					return a / b;
			}
			return 0;
		}
		private void Add_Click(object sender, RoutedEventArgs e)
		{
			if (calc_operator == 'n')
			{
				operand_calc.Text = Main_operand_calc.Text + "+";
				calc_operator = '+';
				calc_operands++;
				calc_operand_a = Convert.ToDouble(Main_operand_calc.Text.Replace(",", "."));
				Main_operand_calc.Text = "0";
			}
			else
			{
				calc_operand_a = Calc(calc_operand_a, Convert.ToDouble(Main_operand_calc.Text.Replace(",", ".")), calc_operator);
				operand_calc.Text = calc_operand_a.ToString() + "+";
				Main_operand_calc.Text = "0";
				calc_operator = '+';
			}
		}

		private void Subtract_Click(object sender, RoutedEventArgs e)
		{
			if (calc_operator == 'n')
			{
				operand_calc.Text = Main_operand_calc.Text + "-";
				calc_operator = '-';
				calc_operands++;
				calc_operand_a = Convert.ToDouble(Main_operand_calc.Text.Replace(",", "."));
				Main_operand_calc.Text = "0";
			}
			else
			{
				calc_operand_a = Calc(calc_operand_a, Convert.ToDouble(Main_operand_calc.Text.Replace(",", ".")), calc_operator);
				operand_calc.Text = calc_operand_a.ToString() + "-";
				Main_operand_calc.Text = "0";
				calc_operator = '-';
			}
		}

		private void Multiply_Click(object sender, RoutedEventArgs e)
		{
			if (calc_operator == 'n')
			{
				operand_calc.Text = Main_operand_calc.Text + "×";
				calc_operator = '×';
				calc_operands++;
				calc_operand_a = Convert.ToDouble(Main_operand_calc.Text.Replace(",", "."));
                Main_operand_calc.Text = "0";
			}
			else
			{
				calc_operand_a = Calc(calc_operand_a, Convert.ToDouble(Main_operand_calc.Text.Replace(",", ".")), calc_operator);
				operand_calc.Text = calc_operand_a.ToString() + "×";
				Main_operand_calc.Text = "0";
				calc_operator = '×';
			}
		}
		private void Divide_Click_1(object sender, RoutedEventArgs e)
		{
			if (calc_operator == 'n')
			{
				operand_calc.Text = Main_operand_calc.Text + "÷";
				calc_operator = '÷';
				calc_operands++;
				calc_operand_a = Convert.ToDouble(Main_operand_calc.Text.Replace(",", "."));
				Main_operand_calc.Text = "0";
			}
			else
			{
				calc_operand_a = Calc(calc_operand_a, Convert.ToDouble(Main_operand_calc.Text.Replace(",", ".")), calc_operator);
				operand_calc.Text = calc_operand_a.ToString() + "÷";
				Main_operand_calc.Text = "0";
				calc_operator = '÷';
			}
		}
		private int CommasInString(string str)
		{
			int count = 0;
			foreach (char c in str) if (c == ',') count++;
			return count;
		}
		private void Point_Click(object sender, RoutedEventArgs e)
		{
			if (Main_operand_calc.Text.Length >= 15) return;
			if (CommasInString(Main_operand_calc.Text) == 0) Main_operand_calc.Text += ",";
		}

		private void Submit_Calc_Click(object sender, RoutedEventArgs e)
		{
			if (calc_operator == 'n')
			{
				if (Main_operand_calc.Text.EndsWith(",")) Main_operand_calc.Text = Main_operand_calc.Text.Remove(Main_operand_calc.Text.Length - 1);
				operand_calc.Text = Main_operand_calc.Text + "=";
			}
			else
			{
				operand_calc.Text = calc_operand_a.ToString() + calc_operator + Main_operand_calc.Text + "=";
				calc_operand_a = Calc(calc_operand_a, Convert.ToDouble(Main_operand_calc.Text.Replace(",", ".")), calc_operator);
				Main_operand_calc.Text = calc_operand_a.ToString();
				calc_operator = 'n';
			}
		}
		#endregion

		private void Clear_calc_Click(object sender, RoutedEventArgs e)
		{
			Main_operand_calc.Text = "0";
			operand_calc.Text = "";
			calc_operands = 0;
			calc_operand_a = 0;
			calc_operator = 'n';
		}

		private void Backspace_calc_Click(object sender, RoutedEventArgs e)
		{
			if (Main_operand_calc.Text.Length <= 1) Main_operand_calc.Text = "0";
			else Main_operand_calc.Text = Main_operand_calc.Text.Remove(Main_operand_calc.Text.Length - 1);
		}

		private void Main_operand_calc_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (Clipboard.GetText() != Main_operand_calc.Text)
				Clipboard.SetText(Main_operand_calc.Text);
		}
	}
}
