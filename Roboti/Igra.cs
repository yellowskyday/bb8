using Roboti.Podloge;
using System.Collections.Generic;

namespace Roboti
{
    public class Igra
    {

        #region Fields

        PokretnaTraka pokretnaTraka;
        int brojZivota;
        int trenutnaPozicija;
        private Kraj kraj;
        public Kraj Kraj { get => kraj; }

        #endregion

        #region Constructors
        public Igra()
        {
            pokretnaTraka = new PokretnaTraka();
            brojZivota = 1;
            trenutnaPozicija = 0;
            kraj = Kraj.Ne;
        }

        #endregion

        #region Methods

        public void TikTak(Smer smer, Udar udar)
        {
            List<Efekat> efekats = pokretnaTraka.vrati(trenutnaPozicija).korakni(smer, udar);
            izvrsiEfekte(efekats);
        }

        public void korakni()
        {
            trenutnaPozicija++;
        }

        #endregion

        #region Private Methods

        private void izvrsiEfekte(List<Efekat> efekti)
        {
            if (efekti != null)
            {
                foreach (var efekat in efekti)
                {
                    switch (efekat)
                    {
                        //case Efekat.DodajPoene:
                        //    igrac.OsvojPoene(vocka.Poeni);
                        //    break;
                        case Efekat.DodajZivot:
                            brojZivota++;
                            break;
                        case Efekat.OduzmiZivot:
                            brojZivota--;
                            if (brojZivota == 0) kraj = Kraj.Izgubio;
                            break;
                        //case Efekat.UkloniPrepreku:
                        //    tabla.UkoniPrepreku();
                        //    break;
                        case Efekat.R2D2:
                            kraj = Kraj.Prosao;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public Podloga vrati(int i)
        {
            return pokretnaTraka.vrati(i);
        }

        #endregion


    }
}
