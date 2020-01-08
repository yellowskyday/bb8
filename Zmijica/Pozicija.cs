using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmijica
{
    public class Pozicija
    {

        #region Fields
        int x;
        int y;

        public int X { get => x; }
        public int Y { get => y; }
        #endregion

        #region Constructors

        public Pozicija(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        #endregion

        #region Methods

        public Pozicija Korakni(Smer smer)
        {
            switch (smer)
            {
                case Smer.Gore:
                    return new Pozicija(x, y - 1);
                case Smer.Dole:
                    return new Pozicija(x, y + 1);
                case Smer.Levo:
                    return new Pozicija(x - 1, y);
                case Smer.Desno:
                    return new Pozicija(x + 1, y);
                default:
                    return Clone();
            }
        }

        public bool PozicijaPripadaListi(List<Pozicija> pozicije)
        {
            if (pozicije == null) return false;
            return pozicije.Any(z => z.x == this.x && z.y == this.y);
        }

        public Pozicija Clone()
        {
            return new Pozicija(x, y);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Pozicija)) return false;
            return ((Pozicija)obj).x == this.x && ((Pozicija)obj).y == this.y;
        }

        public static bool operator ==(Pozicija pozicija1, Pozicija pozicija2)
        {
            return pozicija1.x == pozicija2.x && pozicija1.y == pozicija2.y;
        }

        public static bool operator !=(Pozicija pozicija1, Pozicija pozicija2)
        {
            return pozicija1.x != pozicija2.x || pozicija1.y != pozicija2.y;
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
