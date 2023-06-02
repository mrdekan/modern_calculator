using MaterialDesignColors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
	/// Interaction logic for CurrencyTranslatorView.xaml
	/// </summary>
	public partial class CurrencyTranslatorView : UserControl
	{
		private string line = "";
		private string[] currency = { "USD", "EUR", "JPY", "UAH" };
		public CurrencyTranslatorView()
		{
			InitializeComponent();
			To_CurrTrans.SelectedIndex = 0;
			From_CurrTrans.SelectedIndex = 3;
			ErrorBorder_CurrTrans.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
			WebClient wb = new WebClient();
			try
			{
				line = wb.DownloadString("https://bank.gov.ua/NBU_Exchange/exchange?date=" + DateTime.Now.ToString("dd.M.yyyy"));
			}
			catch
			{
				CurrTrans_output.Text = "An error occured when processing your request";
			}
		}
		private double getCurrency(string name, string xml)
		{
			if (!xml.Contains(name)) return 0;
			int i = xml.IndexOf(name), b = 55;
			while (i < xml.IndexOf(name) + b)
			{
				i++;
				if (xml[i] == '0') b++;
			}
			string res = "";
			while (xml[i] == '.' || Char.IsDigit(xml[i]))
			{
				res += xml[i];
				i++;
			}
			return double.Parse(res.Replace(".", ",")) / Math.Pow(10,b-55);
		}
		private double Convert(string from, string to, double value)
		{
			if (from == to) return value;
			if (from == "UAH") return Math.Round(value / getCurrency(to, line), 3);
			if (to == "UAH") return Math.Round((getCurrency(from, line) * value), 3);
			return Math.Round(value / getCurrency(to, line) * getCurrency(from, line) * value, 3);
		}
		private void ClearError()
		{
			ErrorLabel_CurrTrans.Text = "";
			ErrorBorder_CurrTrans.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
		}
		private void Error(string err)
		{
			ErrorBorder_CurrTrans.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
			ErrorLabel_CurrTrans.Text = err;
		}
		private void Submit_CurrTrans_Click(object sender, RoutedEventArgs e)
		{
			ClearError();
            if (CurrTrans_input.Text == "")
            {
				Error("This field can not be empty");
				return;
			}
			if(!Regex.IsMatch(CurrTrans_input.Text, "^[0-9,.]+$"))
            {
				Error("Incorrect input");
				return;
			}
			if (line != "")
			{
				CurrTrans_output.Text = Convert(currency[From_CurrTrans.SelectedIndex], currency[To_CurrTrans.SelectedIndex], double.Parse(CurrTrans_input.Text.Replace(".", ","))).ToString();
			}
		}

        private void Reverse_CurrTrans_Click(object sender, RoutedEventArgs e)
        {
			ClearError();
			if (CurrTrans_input.Text != "")
			{
				CurrTrans_input.Text = Convert(currency[From_CurrTrans.SelectedIndex], currency[To_CurrTrans.SelectedIndex], double.Parse(CurrTrans_input.Text.Replace(".", ","))).ToString();
			}
            else
            {
				CurrTrans_output.Text = "";
            }
			int temp = From_CurrTrans.SelectedIndex;
			From_CurrTrans.SelectedIndex = To_CurrTrans.SelectedIndex;
			To_CurrTrans.SelectedIndex = temp;
			if (CurrTrans_input.Text != "")
			{
				CurrTrans_output.Text = Convert(currency[From_CurrTrans.SelectedIndex], currency[To_CurrTrans.SelectedIndex], double.Parse(CurrTrans_input.Text.Replace(".", ","))).ToString();
			}
		}
		private static bool HasNotMoreOneComma(string s)
		{
			int count = 0;
			foreach (char c in s) if (c == ',' || c == '.') count++;
			return count < 1;
		}
		private void CurrTrans_input_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.Key == Key.OemComma || e.Key == Key.OemPeriod)
			{
				if (!HasNotMoreOneComma(CurrTrans_input.Text)) e.Handled = true;
			}
			if (CurrTrans_input.Text.Length > 26)
			{
				e.Handled = true;
			}
		}
    }
}
