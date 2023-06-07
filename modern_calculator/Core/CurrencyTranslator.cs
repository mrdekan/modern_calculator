using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace modern_calculator.Core
{
    internal class CurrencyTranslator
    {
        private const string BANK_JSON_URL = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
        private const string DEFAULT_CURRENCY = "UAH";
        private static string JSON { get; set; }
        public bool IsLoaded
        {
            get => Currencies != null;
        }
        public bool LoadingError { get; private set; } = false;
        private List<Currency> Currencies { get; set; }
        private double GetCurrency(string name) => Currencies.Find(el => el.cc == name).rate;
        public async void DownloadCurrencyRate()
        {
            await Task.Run(() =>
            {
                WebClient wb = new WebClient();
                try
                {
                    JSON = wb.DownloadString(BANK_JSON_URL);
                    Currencies = new JavaScriptSerializer().Deserialize<List<Currency>>(JSON);
                }
                catch
                {
                    LoadingError = true;
                }
            });
        }
        public double ConvertCurrency(string from, string to, double value)
        {
            if (!IsLoaded) return -1;
            if (from == to) return value;
            if (from == DEFAULT_CURRENCY) return Math.Round(value / GetCurrency(to), 3);
            if (to == DEFAULT_CURRENCY) return Math.Round(GetCurrency(from) * value, 3);
            return Math.Round(GetCurrency(from) * value / GetCurrency(to), 3);
        }
    }
}
