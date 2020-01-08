using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboti
{
    public class Nista : Podloga
    {
        public Nista()
        {
            ImgPath = @"C:\Users\marinao\source\repos\Zmijica\Roboti\Images\nista.jpg";
        }

        public override List<Efekat> korakni(Smer smer, Udar udar)
        {
            return new List<Efekat> {  };
        }
    }
}
