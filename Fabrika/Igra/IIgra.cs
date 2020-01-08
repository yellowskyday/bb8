using Fabrika.Svet;
using System.Collections.Generic;
using System.Drawing;

namespace Fabrika
{
    public interface IIgra
    {
        Igrac Igrac1 { get; }
        Igrac Igrac2 { get; }
        bool JeKraj { get; }
        
        MoguciElementi moguciElementi { get; }

        string Pobednik();

        void start();

        void TikTak();

        List<ProizvodniProces> proizvodniProcesiZaKupovinu();
    }
}