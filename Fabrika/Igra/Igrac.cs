using Fabrika.Svet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrika
{
    public class Igrac
    {

        #region Fields

        public int Poeni { get; set; }
        public string Ime { get; set; }
        public int Novac { get; set; }

        public List<Masina> Masine { get; set; }
        public List<Radnik> Radnici { get; set; }

    #endregion

    #region Constructors

    public Igrac(string ime)
        {
            Novac = 1000;
            this.Ime = ime;
        }

        #endregion

        #region Methods

        #endregion

        #region Private Methods

        #endregion

    }
}
