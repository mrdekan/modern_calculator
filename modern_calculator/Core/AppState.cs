using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modern_calculator.Core
{
    internal static class AppState
    {
        public static double ContentHeight { get; set; }
        public static double ContentWidth { get; set; }
        public static double ContentMargin { get; set; }
        public static int NotesZindex { get; set; } = 0;
        public static string CurrencyRateJson { get; set; } = "";
    }
}
