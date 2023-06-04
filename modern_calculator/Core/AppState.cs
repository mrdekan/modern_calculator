using modern_calculator.MVVM.Model;
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
        public static string CurrencyRateJson { get; set; } = "";
        public static PC ThisPC { get; set; } = new PC();
        public static int NotesZindex { get; set; } = 0;
        public static List<Note> Notes { get; set; }
    }
}
