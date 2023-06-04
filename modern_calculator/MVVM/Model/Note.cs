using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modern_calculator.MVVM.Model
{
    [Serializable]
    public class Note
    {
        public int Id { get; set; }
        public double PosX {  get; set; }
        public double PosY { get; set; }
        public string Text { get; set; }
    }
}
