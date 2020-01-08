using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Fabrika.Svet;
using Newtonsoft.Json;

namespace Fabrika
{
    public class IgraJedanIgrac : IIgra
    {

        #region Fields

        private Igrac igrac;
        private bool jeKraj;
        private bool naVreme;
        private int vreme;
        private int trenutnoVreme;
        #endregion

        #region Constructors

        public IgraJedanIgrac(bool naVreme, int vreme, string ime)
        {
            igrac = new Igrac(ime);
            this.vreme = vreme;
            this.naVreme = true;
        }

        public string Pobednik()
        {
            if (!jeKraj) return null;
            if (igrac.Novac < 0 ) return "Kompjuter";
            return igrac.Ime;
        }

        public Igrac Igrac { get => igrac; }

        public bool JeKraj { get => jeKraj; }

        public Igrac Igrac1 => Igrac;

        public Igrac Igrac2 => null;

        public MoguciElementi moguciElementi { get; set; }


        #endregion

        #region Methods

        public void TikTak()
        {
            
            trenutnoVreme++;
            if(trenutnoVreme == vreme && naVreme)
            {
                jeKraj = true;
            }
            if(igrac.Novac < 0)
            {
                this.jeKraj = true;
            }
        }

        public void start()
        {
            moguciElementi = new MoguciElementi();

            using (StreamReader r = new StreamReader(Application.StartupPath + @"/../../../Fabrika/Svet/MoguciElementi.json"))
            {
                string json = r.ReadToEnd();
                moguciElementi = JsonConvert.DeserializeObject<MoguciElementi>(json);
            }
        }

        public List<ProizvodniProces> proizvodniProcesiZaKupovinu()
        {
            return moguciElementi.MoguciProizvodniProcesi.Where(x => igrac.Masine.Any(y => y == x.Masina)).ToList();
        }



        #endregion

        #region Private Methods


        #endregion

    }
}
