using System.Collections.Generic;
using System.Drawing;

namespace Zmijica
{
    public class Bobica : Vocka
    {

        #region Fields

        #endregion

        #region Constructors

        public Bobica(int duzinaTable) : base(duzinaTable, new Pozicija(6, 3), -10, Color.CornflowerBlue, null, new List<Efekat> { Efekat.DodajPoene, Efekat.OduzmiZivot }, true)
        {
        }

        public Bobica(int duzinaTable, Pozicija pozicija) : base(duzinaTable, pozicija, -10, Color.CornflowerBlue, null, new List<Efekat> { Efekat.DodajPoene, Efekat.OduzmiZivot }, true)
        {
        }

        #endregion

        #region Methods 

        #endregion

        #region Private Methods

        #endregion

    }
}
