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
				line = wb.DownloadString("https://bank.gov.ua/NBU_Exchange/exchange?date=" + DateTime.Now.ToString("dd/M/yyyy").Replace("/", "."));
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
		private void Submit_CurrTrans_Click(object sender, RoutedEventArgs e)
		{
			if (line != "")
			{
				CurrTrans_output.Text = Convert(currency[From_CurrTrans.SelectedIndex], currency[To_CurrTrans.SelectedIndex], double.Parse(CurrTrans_input.Text.Replace(".", ","))).ToString();
			}
		}
	}
}
