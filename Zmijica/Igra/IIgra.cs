using System.Drawing;

namespace Zmijica
{
    public interface IIgra
    {
        Igrac Igrac1 { get; }
        Igrac Igrac2 { get; }
        bool JeKraj { get; }
        Nivo Nivo { get; }
        Tabla Tabla { get; }
        Vocka Vocka { get; }

        void Skreni1(Smer smer);
        void Skreni2(Smer smer);
        void TikTak();
        Color VratiBoju(Pozicija p);

        string Pobednik();
    }
}