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
        private readonly string[] Currencies = { "USD", "EUR", "JPY", "UAH" };
        public CurrencyTranslatorView()
        {
            InitializeComponent();
            To_CurrTrans.SelectedIndex = 0;
            From_CurrTrans.SelectedIndex = 3;
            ErrorBorder_CurrTrans.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
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
            if (AppState.Currency.IsLoaded)
                CurrTrans_output.Text = AppState.Currency.ConvertCurrency(Currencies[From_CurrTrans.SelectedIndex], Currencies[To_CurrTrans.SelectedIndex], Convert.ToDouble(CurrTrans_input.Text.Replace(".", ","))).ToString();
            else if (AppState.Currency.LoadingError)
                Error("Error getting data");
            else
                Error("Data not received yet");
        }
        private void Reverse_CurrTrans_Click(object sender, RoutedEventArgs e)
        {
            ClearError();
            if (CurrTrans_input.Text != "")
                CurrTrans_input.Text = AppState.Currency.ConvertCurrency(Currencies[From_CurrTrans.SelectedIndex], Currencies[To_CurrTrans.SelectedIndex], Convert.ToDouble(CurrTrans_input.Text.Replace(".", ","))).ToString();
            else
                CurrTrans_output.Text = "";
            (To_CurrTrans.SelectedIndex, From_CurrTrans.SelectedIndex) = (From_CurrTrans.SelectedIndex, To_CurrTrans.SelectedIndex);
            if (CurrTrans_input.Text != "")
                CurrTrans_output.Text = AppState.Currency.ConvertCurrency(Currencies[From_CurrTrans.SelectedIndex], Currencies[To_CurrTrans.SelectedIndex], Convert.ToDouble(CurrTrans_input.Text.Replace(".", ","))).ToString();
        }
        private void CurrTrans_input_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (e.Key == Key.OemComma || e.Key == Key.OemPeriod) && CurrTrans_input.Text.Count(el => ".,".Contains(el)) > 0 || CurrTrans_input.Text.Length > 26;
        }
    }
}
