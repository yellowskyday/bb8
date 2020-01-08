using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmijica
{
    public class Igrac
    {

        #region Fields

        private int poeni;
        private int zivoti;
        private string ime;

        public int Poeni { get => poeni; }

        public bool JeZiv { get => zivoti > 0; }
        public int Zivoti { get => zivoti; }
        public string Ime { get => ime; }

        #endregion

        #region Constructors

        public Igrac(string ime, int poeni, int zivoti)
        {
            this.poeni = poeni;
            this.zivoti = zivoti;
            this.ime = ime;
        }

        #endregion

        #region Methods

        public void OsvojPoene(int osvojeniPoeni)
        {
            poeni += osvojeniPoeni;
        }

        public void IzgubiPoene(int izgubljeniPoeni)
        {
            poeni -= izgubljeniPoeni;
        }

        public void IzgubiZivot()
        {
            zivoti--;
        }

        public void ZaradiZivot()
        {
            zivoti++;
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
