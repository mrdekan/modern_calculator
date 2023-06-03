using modern_calculator.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace modern_calculator.MVVM.View
{
    /// <summary>
    /// Interaction logic for CurrencyTranslatorView.xaml
    /// </summary>
    public partial class CurrencyTranslatorView : UserControl
    {
        private const string BANK_JSON_URL = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
        private string[] currency = { "USD", "EUR", "JPY", "UAH" };
        private string json = "";
        List<Currency> currencies;
        public CurrencyTranslatorView()
        {
            InitializeComponent();
            To_CurrTrans.SelectedIndex = 0;
            From_CurrTrans.SelectedIndex = 3;
            ErrorBorder_CurrTrans.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            Download();
        }
        private async void Download()
        {
            await Task.Run(() =>
            {
                WebClient wb = new WebClient();
                try
                {
                    json = wb.DownloadString(BANK_JSON_URL);
                    currencies = new JavaScriptSerializer().Deserialize<List<Currency>>(json);
                }
                catch
                {
                    CurrTrans_output.Text = "An error occured when processing your request";
                }
            });
        }
        private double GetCurrency(string name) => currencies.Find(el => el.cc == name).rate;
        private double ConvertCurr(string from, string to, double value)
        {
            if (json == "") return -1;
            if (from == to) return value;
            if (from == "UAH") return Math.Round(value / GetCurrency(to), 3);
            if (to == "UAH") return Math.Round(GetCurrency(from) * value, 3);
            return Math.Round(GetCurrency(from) * value / GetCurrency(to), 3);
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
            if (!Regex.IsMatch(CurrTrans_input.Text, "^[0-9,.]+$"))
            {
                Error("Incorrect input");
                return;
            }
            double d = Convert.ToDouble(CurrTrans_input.Text.Replace(",", "."));
            if (json != "")
                CurrTrans_output.Text = ConvertCurr(currency[From_CurrTrans.SelectedIndex], currency[To_CurrTrans.SelectedIndex], Convert.ToDouble(CurrTrans_input.Text.Replace(",", "."))).ToString();
        }

        private void Reverse_CurrTrans_Click(object sender, RoutedEventArgs e)
        {
            ClearError();
            if (CurrTrans_input.Text != "")
                CurrTrans_input.Text = ConvertCurr(currency[From_CurrTrans.SelectedIndex], currency[To_CurrTrans.SelectedIndex], Convert.ToDouble(CurrTrans_input.Text.Replace(",", "."))).ToString();
            else
                CurrTrans_output.Text = "";
            (To_CurrTrans.SelectedIndex, From_CurrTrans.SelectedIndex) = (From_CurrTrans.SelectedIndex, To_CurrTrans.SelectedIndex);
            
            if (CurrTrans_input.Text != "")
                CurrTrans_output.Text = ConvertCurr(currency[From_CurrTrans.SelectedIndex], currency[To_CurrTrans.SelectedIndex], Convert.ToDouble(CurrTrans_input.Text.Replace(",", "."))).ToString();
        }
        private void CurrTrans_input_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (e.Key == Key.OemComma || e.Key == Key.OemPeriod) && CurrTrans_input.Text.Count(el => ".,".Contains(el)) > 0 || CurrTrans_input.Text.Length > 26;
        }
    }
}
