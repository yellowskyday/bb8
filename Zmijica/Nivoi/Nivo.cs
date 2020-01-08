namespace Zmijica
{
    public class Nivo
    {

        #region Fields

        bool raste;
        bool seSudaraSamaSaSobom;
        int brzina;
        bool sePojavljujuPrepreke;
        int vremeDoPrepreke;
        PonasanjePremaVocu ponasanjePremaVocu;
        bool ideUKrug;
        bool seSudaraju;
        bool naSat;
        int vreme;

        #endregion

        #region Constructors

        public Nivo(bool raste, bool seSudaraSamaSaSobom, int brzina, bool sePojavljujuPrepreke, int vremeDoPrepreke, PonasanjePremaVocu ponasanjePremaVocu, bool ideUKrug, bool seSudaraju, bool naSat, int vreme)
        {
            this.raste = raste;
            this.seSudaraSamaSaSobom = seSudaraSamaSaSobom;
            this.brzina = brzina;
            this.sePojavljujuPrepreke = sePojavljujuPrepreke;
            this.vremeDoPrepreke = vremeDoPrepreke;
            this.ponasanjePremaVocu = ponasanjePremaVocu;
            this.ideUKrug = ideUKrug;
            this.seSudaraju = seSudaraju;
            this.naSat = naSat;
            this.vreme = vreme;
        }

        public bool Raste { get => raste;  }
        public bool SeSudaraSamaSaSobom { get => seSudaraSamaSaSobom; }
        public int Brzina { get => brzina;  }
        public bool SePojavljujuPrepreke { get => sePojavljujuPrepreke;  }
        public int VremeDoPrepreke { get => vremeDoPrepreke; }
        public PonasanjePremaVocu PonasanjePremaVocu { get => ponasanjePremaVocu; }
        public bool IdeUKrug { get => ideUKrug; }
        public bool SeSudaraju { get => seSudaraju; }
        public bool NaSat { get => naSat;  }
        public int Vreme { get => vreme;  }

        #endregion

        #region Methods

        #endregion

        #region Private Methods

        #endregion

    }
}
