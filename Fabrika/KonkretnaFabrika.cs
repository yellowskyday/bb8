using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrika
{
    public class KonkretnaFabrika
    {

        #region Fields

        int duzina;
        int sirina;
        List<Radnik> radnici;
        List<Tuple<Masina, int, int>> masinaPolozaj;

        decimal novac;

        #endregion

        #region Constructors

        #endregion

        #region Methods

        public void zaposli(Radnik radnik)
        {
            radnici.Add(radnik);
        }

        public void otpusti(Radnik radnik, int redniBrojDanaUMesecu)
        {
            novac -= radnik.PlataNaSat * 8 * redniBrojDanaUMesecu;
            radnici.Remove(radnik);
        }

        public void mesecniIzdaci()
        {
            radnici.ForEach(x =>
            {
                novac -= x.PlataNaSat * 8 * 30;
            }
            );
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
