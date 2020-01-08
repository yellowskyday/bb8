using System.Collections.Generic;
using System.Drawing;

namespace Zmijica
{
    public class Narandza : Vocka
    {

        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Methods 

        public Narandza(int duzinaTable) : base(duzinaTable, new Pozicija(6,3), 10, Color.Orange, null, new List<Efekat> { Efekat.DodajZivot }, true)
        {
        }

        public Narandza(int duzinaTable, Pozicija pozicija) : base(duzinaTable, pozicija, 10, Color.Orange, null, new List<Efekat> { Efekat.DodajZivot }, true)
        {
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
