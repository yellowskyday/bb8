using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboti
{
    public class Trava : Podloga
    {
        public Trava()
        {
            ImgPath = @"C:\Users\marinao\source\repos\Zmijica\Roboti\Images\trava.jpg";
        }

        public override List<Efekat> korakni(Smer smer, Udar udar)
        {
            if (smer == Smer.Gore
                || smer == Smer.Desno)
                return new List<Efekat> { };
            return new List<Efekat> { Efekat.OduzmiZivot };//{ Efekat.OduzmiZivot };
        }
    }
}
