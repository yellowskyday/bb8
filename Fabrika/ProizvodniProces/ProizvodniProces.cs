using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrika
{
    public class ProizvodniProces
    {
        #region Fields

        public NivoKvalifikacija NivoKvalifikacija { get; set; }
        public Masina Masina { get; set; }
        public Dictionary<Proizvod, long> SirovineKolicina { get; set; }
        public int TrajanjeUSatima { get; set; }
        public Proizvod IzlazniProizvod { get; set; }


        #endregion

        #region Constructors

        #endregion

        #region Methods

        public int izlaznaKolicinaProizvoda()
        {
            //da se lakse racuna
            return (int)(SirovineKolicina.Sum(x => x.Value) * Masina.StepenProzivodnosti);
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
