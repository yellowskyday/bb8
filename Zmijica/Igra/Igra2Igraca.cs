using System.Collections.Generic;
using System.Drawing;

namespace Zmijica
{
    public class IgraDvaIgraca: IIgra
    {

        #region Fields

        private Igrac igrac1;
        private Igrac igrac2;
        private Vocka vocka;
        private Nivo nivo;
        private Tabla tabla;
        private bool jeKraj;
        private bool naVreme;
        private int vreme;
        private int trenutnoVreme;
        #endregion

        #region Constructors

        public IgraDvaIgraca(Nivo nivo)
        {
            this.nivo = nivo;
            tabla = new Tabla(nivo.SePojavljujuPrepreke, nivo.VremeDoPrepreke);
            //matrica = new int[tabla.Duzina, tabla.Sirina];
            
            Zmija zmija1 = new Zmija(new List<Pozicija> { new Pozicija(10, 6), new Pozicija(10, 7), new Pozicija(10, 8) }
                , Smer.Gore, tabla.Duzina, nivo.SeSudaraSamaSaSobom, nivo.Raste, Color.Firebrick, nivo.IdeUKrug);

            Zmija zmija2 = new Zmija(new List<Pozicija> { new Pozicija(6, 6), new Pozicija(6, 7), new Pozicija(6, 8) }
                , Smer.Gore, tabla.Duzina, nivo.SeSudaraSamaSaSobom, nivo.Raste, Color.Magenta, nivo.IdeUKrug);
            vocka = new Jabuka(tabla.Duzina, new Pozicija(8,11));
            igrac1 = new Igrac(zmija1, "Bo");
            igrac2 = new Igrac(zmija2, "Vivi");
            jeKraj = false;
            naVreme = nivo.NaSat;
            vreme = nivo.Vreme;
            trenutnoVreme = 0;
        }

        public string Pobednik()
        {
            if (!jeKraj) return null;
            if (igrac1.Zivoti == 0 && igrac2.Zivoti == 0) return "Kompjuter";
            if (igrac1.Zivoti == 0) return igrac2.Ime;
            if (igrac2.Zivoti == 0) return igrac1.Ime;
            if(igrac1.Poeni > igrac2.Poeni) return igrac1.Ime;
            if (igrac2.Poeni > igrac1.Poeni) return igrac2.Ime;
            return "Kompjuter";
        }

        public Igrac Igrac1 { get => igrac1; }
        public Igrac Igrac2 { get => igrac2; }
        public Vocka Vocka { get => vocka; }
        public Nivo Nivo { get => nivo; }
        public Tabla Tabla { get => tabla; }

        public bool JeKraj { get => jeKraj; }


        #endregion

        #region Methods

        public void TikTak()
        {
            igrac1.Zmija.Korakni(vratiZabranjenePozicije1(), new List<Pozicija> { vocka.Pozicija });
            igrac2.Zmija.Korakni(vratiZabranjenePozicije2(), new List<Pozicija> { vocka.Pozicija });

            if ((igrac1.Zmija.Glava == igrac2.Zmija.Glava))
            {
                if (nivo.SeSudaraju)
                {
                    igrac1.IzgubiZivot();
                    igrac2.IzgubiZivot();
                }
            }
            else
            {
                var efekti = vocka.Pojedi(igrac1.Zmija.Glava, tabla.PozicijePrepreka);
                izvrsiEfekte(efekti, igrac1);

                var efekt2 = vocka.Pojedi(igrac2.Zmija.Glava, tabla.PozicijePrepreka);
                izvrsiEfekte(efekt2, igrac2);

                if (vocka.JeNestala)
                {
                    switch (nivo.PonasanjePremaVocu)
                    {
                        case PonasanjePremaVocu.Jabuka:
                            tikTakObican();
                            break;
                        case PonasanjePremaVocu.DveJabuke:
                            tikTakJabuke();
                            break;
                        case PonasanjePremaVocu.Razno:
                            tikTakIzmeneVocki();
                            break;
                        default:
                            break;
                    }
                }
                tabla.StvoriPrepreku(vratiZabranjenePozicije());

                if (igrac1.Zmija.SeSlupala)
                {
                    igrac1.IzgubiZivot();
                }
                if (igrac2.Zmija.SeSlupala)
                {
                    igrac2.IzgubiZivot();
                }
            }
            jeKraj = !igrac1.JeZiv || !igrac2.JeZiv;

            trenutnoVreme++;
            if (trenutnoVreme == vreme && naVreme)
            {
                jeKraj = true;
            }

        }

        public void Skreni1(Smer smer)
        {
            igrac1.Zmija.Skreni(smer);
        }

        public void Skreni2(Smer smer)
        {
            igrac2.Zmija.Skreni(smer);
        }

        public Color VratiBoju(Pozicija p)
        {
            Color color = tabla.Boja;
            if (p == vocka.Pozicija)
                color = vocka.Boja;
            if (p.PozicijaPripadaListi(igrac1.Zmija.Pozicije))
                color = igrac1.Zmija.Boja;
            if (p.PozicijaPripadaListi(igrac2.Zmija.Pozicije))
                color = igrac2.Zmija.Boja;
            if (p.PozicijaPripadaListi(tabla.PozicijePrepreka))
                color = tabla.BojaPrepreke;
            return color;
        }

        #endregion

        #region Private Methods

        private void izvrsiEfekte(List<Efekat> efekti, Igrac igrac)
        {
            if (efekti != null)
            {
                foreach (var efekat in efekti)
                {
                    switch (efekat)
                    {
                        case Efekat.DodajPoene:
                            igrac.OsvojPoene(vocka.Poeni);
                            break;
                        case Efekat.DodajZivot:
                            igrac.ZaradiZivot();
                            break;
                        case Efekat.OduzmiZivot:
                            igrac.IzgubiZivot();
                            break;
                        case Efekat.UkloniPrepreku:
                            tabla.UkoniPrepreku();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private List<Pozicija> vratiZabranjenePozicije()
        {
            var zabranjenePozicije = new List<Pozicija>();
            zabranjenePozicije.AddRange(igrac1.Zmija.Pozicije);
            zabranjenePozicije.AddRange(igrac2.Zmija.Pozicije);
            zabranjenePozicije.AddRange(tabla.PozicijePrepreka);
            zabranjenePozicije.Add(vocka.Pozicija);
            return zabranjenePozicije;
        }
        private List<Pozicija> vratiZabranjenePozicije1()
        {
            var zabranjenePozicije = new List<Pozicija>();
            if(nivo.SeSudaraju)
                zabranjenePozicije.AddRange(igrac2.Zmija.Pozicije);
            zabranjenePozicije.AddRange(tabla.PozicijePrepreka);
            return zabranjenePozicije;
        }

        private List<Pozicija> vratiZabranjenePozicije2()
        {
            var zabranjenePozicije = new List<Pozicija>();
            if (nivo.SeSudaraju)
                zabranjenePozicije.AddRange(igrac1.Zmija.Pozicije);
            zabranjenePozicije.AddRange(tabla.PozicijePrepreka);
            return zabranjenePozicije;
        }

        private void tikTakObican()
        {
            vocka.Iznikni(vratiZabranjenePozicije());
        }

        private void tikTakIzmeneVocki()
        {
            
                vocka = vocka.IznikniNovaVocka(vratiZabranjenePozicije());
        }

        private int brojPrethodnihJabuka = 0;
        private void tikTakJabuke()
        {
            if (brojPrethodnihJabuka == 2)
            {
                vocka = vocka.IznikniNovaZlatnaJabuka(vratiZabranjenePozicije());
                brojPrethodnihJabuka = 0;
            }
            else
            {
                vocka = vocka.IznikniNovaJabuka(vratiZabranjenePozicije());
                brojPrethodnihJabuka++;
            }
        }

        #endregion

    }
}
