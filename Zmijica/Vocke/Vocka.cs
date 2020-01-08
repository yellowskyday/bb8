using System;
using System.Collections.Generic;
using System.Drawing;

namespace Zmijica
{
    public abstract class Vocka
    {

        #region Fields

        private int poeni;
        private string slika;
        private Color boja;
        private int duzinaTable;
        private Pozicija pozicija;
        private List<Efekat> efekti;
        private bool jeNestala;
        private int trajanje;
        private bool daLiNestaje;
        private int trenutnoTrajanje;

        #endregion

        #region Constructors

        public Vocka(int duzinaTable)
        {
            this.duzinaTable = duzinaTable;
            jeNestala = false;
        }
        public Vocka(int duzinaTable, Pozicija pozicija, int poeni, Color boja, string slika, List<Efekat> efekti, bool daLiNestaje)
        {
            this.duzinaTable = duzinaTable;
            this.pozicija = pozicija.Clone();
            this.poeni = poeni;
            this.boja = boja;
            this.slika = slika;
            this.efekti = efekti;
            this.trajanje = 15;
            this.daLiNestaje = daLiNestaje;
            jeNestala = false;
        }

        public Pozicija Pozicija { get => pozicija; }
        public int Poeni { get => poeni;  }
        public string Slika { get => slika;  }
        public Color Boja { get => boja; }
        public bool JeNestala { get => jeNestala; }


        #endregion

        #region Methods

        public List<Efekat> Pojedi(Pozicija glava, List<Pozicija> pozicijeZabranjene)
        {
            if (glava != pozicija || jeNestala)
            {
                trenutnoTrajanje++;
                if (trenutnoTrajanje == trajanje && daLiNestaje)
                {
                    jeNestala = true;
                    trenutnoTrajanje = 0;
                }
                return null;
            }
            jeNestala = true;
            return efekti;
        }

        public void Iznikni(List<Pozicija> pozicijeZabranjene)
        {
            if (!jeNestala) return; 
            
            pozicija = pomeri(pozicijeZabranjene);
            jeNestala = false;
        }

        public Vocka IznikniNovaVocka(List<Pozicija> pozicijeZabranjene)
        {
            int broj = (new Random()).Next(0,4);
            Vocka vocka = null;
            pozicija = pomeri(pozicijeZabranjene);
            if (broj == 0)
            {
                vocka = new Jabuka(this.duzinaTable, pozicija);
            }
            if (broj == 1)
            {
                vocka = new Bobica(this.duzinaTable, pozicija);
            }
            if (broj == 2)
            {
                vocka = new ZlatnaJabuka(this.duzinaTable, pozicija);
            }
            if (broj == 3)
            {
                vocka = new Narandza(this.duzinaTable, pozicija);
            }

            return vocka;
        }

        public Vocka IznikniNovaJabuka(List<Pozicija> pozicijeZabranjene)
        {
            pozicija = pomeri(pozicijeZabranjene);
            Vocka vocka = new Jabuka(this.duzinaTable, pozicija);
            return vocka;
        }

        public Vocka IznikniNovaZlatnaJabuka(List<Pozicija> pozicijeZabranjene)
        {
            pozicija = pomeri(pozicijeZabranjene);
            Vocka vocka = new ZlatnaJabuka(this.duzinaTable, pozicija);
            return vocka;
        }

        #endregion

        #region Private Methods

        private Pozicija pomeri(List<Pozicija> pozicijeZabranjene)
        {
            Random r = new Random();
            var sledecaPozicija = new Pozicija(r.Next(16), r.Next(16));
            while (sledecaPozicija.PozicijaPripadaListi(pozicijeZabranjene))
            {
                sledecaPozicija = new Pozicija(r.Next(16), r.Next(16));
            }
            return sledecaPozicija;
        }

        #endregion


    }
}
