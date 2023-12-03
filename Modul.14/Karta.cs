using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul._14
{
    public class Karta
    {
        public string Mast { get; set; }
        public string Tip { get; set; }

        public Karta(string mast, string tip)
        {
            Mast = mast;
            Tip = tip;
        }
    }
}
