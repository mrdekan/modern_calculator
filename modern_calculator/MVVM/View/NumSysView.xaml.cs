using modern_calculator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for NumSysView.xaml
    /// </summary>
    public partial class NumSysView : UserControl
    {
        private readonly int[] numSystems = { 2, 8, 10, 16 };
        public NumSysView()
        {
            InitializeComponent();
            FromSys_NumSys.SelectedIndex = 2;
            ToSys_NumSys.SelectedIndex = 0;
            ErrorBorder_NumSys.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }
        private void ClearError()
        {
            ErrorLabel_NumSys.Text = "";
            ErrorBorder_NumSys.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }
        private void Error(string err)
        {
            ErrorBorder_NumSys.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            ErrorLabel_NumSys.Text = err;
        }
        private bool CheckInput(int numSys, string input)
        {
            switch (numSys)
            {
                case 0:
                    return Regex.IsMatch(input, "^[0-1,.]+$");
                case 1:
                    return Regex.IsMatch(input, "^[0-7,.]+$");
                case 2:
                    return Regex.IsMatch(input, "^[0-9,.]+$");
                case 3:
                    return Regex.IsMatch(input, "^[0-9A-Fa-f,.]+$");
            }
            return false;
        }
        private void NumSys_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemComma || e.Key == Key.OemPeriod)
                if (NumSys_input.Text.Count(el => ".,".Contains(el)) == 1) 
                    e.Handled = true;
            if (NumSys_input.Text.Length > 26)
                e.Handled = true;
        }
        private void Reverse_NumSys_Click(object sender, RoutedEventArgs e)
        {
            ClearError();
            if (NumSys_input.Text != "")
                NumSys_input.Text = AppState.NumSysConverter.Convert(numSystems[FromSys_NumSys.SelectedIndex], numSystems[ToSys_NumSys.SelectedIndex], NumSys_input.Text, 8);
            else
                NumSys_output.Text = "";
            (ToSys_NumSys.SelectedIndex, FromSys_NumSys.SelectedIndex) = (FromSys_NumSys.SelectedIndex, ToSys_NumSys.SelectedIndex);
            if (NumSys_input.Text != "")
                NumSys_output.Text = AppState.NumSysConverter.Convert(numSystems[FromSys_NumSys.SelectedIndex], numSystems[ToSys_NumSys.SelectedIndex], NumSys_input.Text, 8);
        }
        private void Submit_NumSys_Click(object sender, RoutedEventArgs e)
        {
            ClearError();
            if (NumSys_input.Text == "")
            {
                Error("This field can not be empty");
                return;
            }
            if (!CheckInput(FromSys_NumSys.SelectedIndex, NumSys_input.Text))
            {
                Error("Incorrect input");
                return;
            }
            NumSys_input.Text = NumSys_input.Text.Replace(".", ",").ToUpper();
            NumSys_output.Text = AppState.NumSysConverter.Convert(numSystems[FromSys_NumSys.SelectedIndex], numSystems[ToSys_NumSys.SelectedIndex], NumSys_input.Text, 8);
        }
        private void NumSys_output_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (NumSys_output.Text != "" && Clipboard.GetText() != NumSys_output.Text) Clipboard.SetText(NumSys_output.Text);
        }
    }
}