using System;
using System.Collections.Generic;
using System.Drawing;

namespace Zmijica
{
    public class Tabla
    {
        #region Fields

        int duzina;
        int sirina;
        Color boja;
        string slika;
        Color bojaPrepreke;
        string slikaPrepreke;
        List<Pozicija> pozicijePrepreka;
        bool imaPrepreke;
        int vremeDoPrepreke;
        int trenutnoVremeDoPrepreke;

        public int Duzina { get => duzina; }
        public int Sirina { get => sirina; }
        public Color Boja { get => boja; }
        public Color BojaPrepreke { get => bojaPrepreke; }
        public List<Pozicija> PozicijePrepreka { get => pozicijePrepreka; }


        #endregion

        #region Constructors

        public Tabla(bool imaPrepreke, int vremeDoPrepreke)
        {
            duzina = 17;
            sirina = 17;
            boja = Color.LightBlue;
            bojaPrepreke = Color.DarkSlateGray;
            pozicijePrepreka = new List<Pozicija>();
            this.imaPrepreke = imaPrepreke;
            trenutnoVremeDoPrepreke = 0;
            this.vremeDoPrepreke = vremeDoPrepreke;
        }

        public Tabla(int duzina, int sirina, Color boja, Color bojaPrepreke, int vremeDoPrepreke)
        {
            this.duzina = duzina;
            this.sirina = sirina;
            this.boja = boja;
            this.bojaPrepreke = bojaPrepreke;
            this.pozicijePrepreka = new List<Pozicija>();
            this.vremeDoPrepreke = vremeDoPrepreke;
            this.trenutnoVremeDoPrepreke = 0;
        } 

        #endregion

        #region Methods

        public void StvoriPrepreku(List<Pozicija> zabranjenePozicije)
        {
            if (!imaPrepreke) return;
            if (vremeDoPrepreke != trenutnoVremeDoPrepreke)
            {
                trenutnoVremeDoPrepreke++;
            }
            else
            {
                Random r = new Random();
                var sledecaPozicija = new Pozicija(r.Next(16), r.Next(16));
                while (sledecaPozicija.PozicijaPripadaListi(pozicijePrepreka)
                    || (sledecaPozicija.PozicijaPripadaListi(zabranjenePozicije)))
                {
                    sledecaPozicija = new Pozicija(r.Next(16), r.Next(16));
                }
                pozicijePrepreka.Add(sledecaPozicija);

                trenutnoVremeDoPrepreke = 0;
            }
        }

        internal void UkoniPrepreku()
        {
            if(pozicijePrepreka.Count > 0)
            {
                Random r = new Random();
                pozicijePrepreka.RemoveAt(r.Next(pozicijePrepreka.Count - 1));

            }
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
