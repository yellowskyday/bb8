using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Zmijica
{
    public class Zmija
    {
        //TODO
        //limun
        //Vivijeve slike
        #region Fields
        private List<Pozicija> pozicije = new List<Pozicija>();
        private Smer trenutniSmer;
        private bool seSlupala;
        private bool seSudaraSamaSaSobom;
        int duzinaTable;
        bool raste;
        Color boja;
        private bool ideUKrug;

        public bool SeSlupala { get => seSlupala;  }
        public List<Pozicija> Pozicije { get => pozicije;  }

        public Pozicija Glava { get => pozicije[0]; }
        public Color Boja { get => boja; }
        #endregion

        #region Constructors

        public Zmija(int duzinaTable)
        {
            pozicije.Clear();
            pozicije.Insert(0, new Pozicija(6, 6));
            pozicije.Insert(1, new Pozicija(6, 7));
            pozicije.Insert(2, new Pozicija(6, 8));
            trenutniSmer = Smer.Gore;
            seSlupala = false;
            this.duzinaTable = duzinaTable;
            seSudaraSamaSaSobom = false;
            raste = true;
            boja = Color.BlueViolet;
            ideUKrug = false;
        }

        public Zmija(int duzinaTable, bool seSudaraSamaSaSobom, bool raste, bool ideUKrug)
        {
            pozicije.Clear();
            pozicije.Insert(0, new Pozicija(6, 12));
            pozicije.Insert(1, new Pozicija(6, 13));
            pozicije.Insert(2, new Pozicija(6, 14));
            trenutniSmer = Smer.Gore;
            seSlupala = false;
            this.duzinaTable = duzinaTable;
            this.seSudaraSamaSaSobom = seSudaraSamaSaSobom;
            this.raste = raste;
            boja = Color.BlueViolet;
            this.ideUKrug = ideUKrug;
        }

        public Zmija(List<Pozicija> pozicije, Smer trenutniSmer, int duzinaTable, bool seSudaraSamaSaSobom, bool raste, Color boja, bool ideUKrug)
        {
            this.pozicije.Clear();
            this.pozicije.AddRange(pozicije);
            this.trenutniSmer = trenutniSmer;
            seSlupala = false;
            this.duzinaTable = duzinaTable;
            this.seSudaraSamaSaSobom = seSudaraSamaSaSobom;
            this.raste = raste;
            this.boja = boja;
            this.ideUKrug = ideUKrug;
        }

        #endregion

        #region Methods

        public void Korakni(List<Pozicija> pozicijeZabranjene = null, List<Pozicija> pozocijeVoce = null)
        {
            Pozicija sledecaGlava = Glava.Korakni(trenutniSmer);
            if(ideUKrug)
            {
                if (sledecaGlava.X == -1) sledecaGlava = new Pozicija(duzinaTable - 1, sledecaGlava.Y);
                if (sledecaGlava.X == duzinaTable) sledecaGlava = new Pozicija(0, sledecaGlava.Y);
                if (sledecaGlava.Y == -1) sledecaGlava = new Pozicija(sledecaGlava.X, duzinaTable - 1);
                if (sledecaGlava.Y == duzinaTable) sledecaGlava = new Pozicija(sledecaGlava.X, 0);

            }

            proveriSeSlupala(sledecaGlava, pozicijeZabranjene);
            bool jePojelaVoce = proveriPojelaVocku(sledecaGlava, pozocijeVoce);

            if (!seSlupala)
            {
                pozicije.Insert(0, sledecaGlava);
                if (!raste || !jePojelaVoce)
                    pozicije.RemoveAt(pozicije.Count - 1);
            }
        }

        public void Skreni(Smer smer)
        {
            switch (smer)
            {
                case Smer.Gore:
                    if (trenutniSmer == Smer.Gore || trenutniSmer == Smer.Dole) return;
                    trenutniSmer = Smer.Gore;
                    break;
                case Smer.Dole:
                    if (trenutniSmer == Smer.Gore || trenutniSmer == Smer.Dole) return;
                    trenutniSmer = Smer.Dole;
                    break;
                case Smer.Desno:
                    if (trenutniSmer == Smer.Levo || trenutniSmer == Smer.Desno) return;
                    trenutniSmer = Smer.Desno;
                    break;
                case Smer.Levo:
                    if (trenutniSmer == Smer.Levo || trenutniSmer == Smer.Desno) return;
                    trenutniSmer = Smer.Levo;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Private Methods

        private void proveriSeSlupala(Pozicija sledecaGlava, List<Pozicija> pozicijeZabranjene)
        {
            seSlupala =
                sledecaGlava.X < 0
                || sledecaGlava.X > duzinaTable - 1
                || sledecaGlava.Y < 0
                || sledecaGlava.Y > duzinaTable - 1;

            if (seSudaraSamaSaSobom)
                seSlupala |= sledecaGlava.PozicijaPripadaListi(pozicije);

            if(pozicijeZabranjene != null)
                seSlupala |= sledecaGlava.PozicijaPripadaListi(pozicijeZabranjene);

        }

        private bool proveriPojelaVocku(Pozicija sledecaGlava, List<Pozicija> pozocijeVoce)
        {
            return sledecaGlava.PozicijaPripadaListi(pozocijeVoce);

        }

        #endregion


    }
}
