using System.Collections.Generic;
using System.Drawing;

namespace Zmijica
{
    public class Jabuka : Vocka
    {

        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Methods 

        public Jabuka(int duzinaTable) : base(duzinaTable, new Pozicija(6,3), 10, Color.Red, null, new List<Efekat> { Efekat.DodajPoene }, false)
        {
        }

        public Jabuka(int duzinaTable, Pozicija pozicija) : base(duzinaTable, pozicija, 10, Color.Red, null, new List<Efekat> { Efekat.DodajPoene }, false)
        {
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
