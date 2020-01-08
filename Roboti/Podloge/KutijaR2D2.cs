using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboti
{
    public class KutijaR2D2 : Podloga
    {
        public KutijaR2D2()
        {
            ImgPath = @"C:\Users\marinao\source\repos\Zmijica\Roboti\Images\kutijar2.jpg";
        }

        public override List<Efekat> korakni(Smer smer, Udar udar)
        {
            if (smer == Smer.Gore
                || smer == Smer.Desno )
                return new List<Efekat> { Efekat.R2D2 };
            return new List<Efekat> { Efekat.OduzmiZivot };
        }
    }
}
