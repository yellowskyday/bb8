using System.Collections.Generic;
using System.Drawing;

namespace Zmijica
{
    public class ZlatnaJabuka : Vocka
    {

        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Methods 

        public ZlatnaJabuka(int duzinaTable) : base(duzinaTable, new Pozicija(6,3), 20, Color.Gold, null, new List<Efekat> { Efekat.DodajPoene, Efekat.UkloniPrepreku }, false)
        {
        }

        public ZlatnaJabuka(int duzinaTable, Pozicija pozicija) : base(duzinaTable, pozicija, 20, Color.Gold, null, new List<Efekat> { Efekat.DodajPoene, Efekat.UkloniPrepreku }, false)
        {
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
