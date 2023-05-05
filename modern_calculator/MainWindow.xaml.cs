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

namespace modern_calculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private static double calc_operand_a;
		private int calc_operands = 0;
		private char calc_operator = 'n';
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Close_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Hide_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		private void Title_MouseDown_1(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left) this.DragMove();
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
				calc_operand_a = double.Parse(Main_operand_calc.Text);
				Main_operand_calc.Text = "0";
			}
			else
			{
				calc_operand_a = Calc(calc_operand_a, double.Parse(Main_operand_calc.Text), calc_operator);
				operand_calc.Text = calc_operand_a.ToString()+"+";
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
				calc_operand_a = double.Parse(Main_operand_calc.Text);
				Main_operand_calc.Text = "0";
			}
			else
			{
				calc_operand_a = Calc(calc_operand_a, double.Parse(Main_operand_calc.Text), calc_operator);
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
				calc_operand_a = double.Parse(Main_operand_calc.Text);
				Main_operand_calc.Text = "0";
			}
			else
			{
				calc_operand_a = Calc(calc_operand_a, double.Parse(Main_operand_calc.Text), calc_operator);
				operand_calc.Text = calc_operand_a.ToString() + "×";
				Main_operand_calc.Text = "0";
				calc_operator = '×';
			}
		}

		private void Divide_Click(object sender, RoutedEventArgs e)
		{
			if (calc_operator == 'n')
			{
				operand_calc.Text = Main_operand_calc.Text + "÷";
				calc_operator = '÷';
				calc_operands++;
				calc_operand_a = double.Parse(Main_operand_calc.Text);
				Main_operand_calc.Text = "0";
			}
			else
			{
				calc_operand_a = Calc(calc_operand_a, double.Parse(Main_operand_calc.Text), calc_operator);
				operand_calc.Text = calc_operand_a.ToString() + "÷";
				Main_operand_calc.Text = "0";
				calc_operator = '÷';
			}
		}
		private int CommasInString(string str)
		{
			int count = 0;
			foreach(char c in str) if(c == ',') count++;
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
				calc_operand_a = Calc(calc_operand_a, double.Parse(Main_operand_calc.Text), calc_operator);
				Main_operand_calc.Text = calc_operand_a.ToString();
				calc_operator = 'n';
			}
		}
		#endregion
	}
}
