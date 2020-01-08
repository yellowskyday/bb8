using System.Collections.Generic;

namespace Roboti
{
    public abstract class Podloga
    {

        #region Fields

        string imgPath;

        public string ImgPath { get => imgPath; set => imgPath = value; }

        #endregion

        #region Constructors

        #endregion

        #region Methods

        public abstract List<Efekat> korakni(Smer smer, Udar udar);

        #endregion

        #region Private Methods

        #endregion

    }
}
