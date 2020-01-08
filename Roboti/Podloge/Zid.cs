using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboti
{
    public class Zid : Podloga
    {
        public Zid()
        {
            ImgPath = @"C:\Users\marinao\source\repos\Zmijica\Roboti\Images\zid.jpg";
        }

        public override List<Efekat> korakni(Smer smer, Udar udar)
        {
            if (smer == Smer.Gore)
                return new List<Efekat> {  };
            return new List<Efekat> { Efekat.OduzmiZivot };
        }
    }
}
