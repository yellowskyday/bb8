using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboti
{
    public class Kutija : Podloga
    {
        public Kutija()
        {
            ImgPath = @"C:\Users\marinao\source\repos\Zmijica\Roboti\Images\kutija.jpg";
        }

        public override List<Efekat> korakni(Smer smer, Udar udar)
        {
            if (smer == Smer.Desno)
                return new List<Efekat> { Efekat.UkloniPrepreku };
            return new List<Efekat> { Efekat.OduzmiZivot };
        }
    }
}
