using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboti
{
    public class Oblak : Podloga
    {
        public Oblak()
        {
            ImgPath = @"C:\Users\marinao\source\repos\Zmijica\Roboti\Images\oblak.jpg";
        }
        public override List<Efekat> korakni(Smer smer, Udar udar)
        {
            if (smer == Smer.Dole)
                return new List<Efekat> { };
            return new List<Efekat> { Efekat.OduzmiZivot };
        }
    }
}
