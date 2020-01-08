using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrika
{
    public class Radnik
    {
        #region Fields

        public string Ime { get; set; }
        public NivoKvalifikacija NivoKvalifikacija { get; set; }
        public LicneOsobine LicneOsobine { get; set; }
        public int PlataNaSat { get; set; }
        public int BrojMeseciZaKV { get; set; }
        public int BrojMeseciZaVKV { get; set; }
        public int BrojMeseciZaInzenjera { get; set; }
        public bool JeNaObuci { get; set; }

        #endregion

        #region Constructors

        #endregion

        #region Methods

        public int obuciSe(NivoKvalifikacija noviNivoKvalifikacija)
        {
            return 1;
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
