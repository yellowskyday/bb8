//using System.Collections.Generic;
//using System.Drawing;

//namespace BoovaIgra
//{
//    public class IgraJedanIgrac : IIgra
//    {

//        #region Fields

//        private Igrac igrac;
//        private Vocka vocka;
//        private Nivo nivo;
//        private Tabla tabla;
//        private bool jeKraj;
//        private bool naVreme;
//        private int vreme;
//        private int trenutnoVreme;
//        #endregion

//        #region Constructors

//        public IgraJedanIgrac(Nivo nivo)
//        {
//            this.nivo = nivo;
//            tabla = new Tabla(nivo.SePojavljujuPrepreke, nivo.VremeDoPrepreke);
//            //matrica = new int[tabla.Duzina, tabla.Sirina];
//            Zmija zmija = new Zmija(tabla.Duzina, nivo.SeSudaraSamaSaSobom, nivo.Raste, nivo.IdeUKrug);
//            vocka = new Jabuka(tabla.Duzina);
//            igrac = new Igrac(zmija);
//            jeKraj = false;
//            naVreme = nivo.NaSat;
//            vreme = nivo.Vreme;
//            trenutnoVreme = 0;
//        }

//        public string Pobednik()
//        {
//            if (!jeKraj) return null;
//            if (igrac.Zivoti > 0 ) return igrac.Ime;
//            return "Kompjuter";
//        }

//        public Igrac Igrac { get => igrac; }
//        public Vocka Vocka { get => vocka; }
//        public Nivo Nivo { get => nivo; }
//        public Tabla Tabla { get => tabla; }

//        public bool JeKraj { get => jeKraj; }

//        public Igrac Igrac1 => Igrac;

//        public Igrac Igrac2 => null;


//        #endregion

//        #region Methods

//        public void TikTak()
//        {
//            switch (nivo.PonasanjePremaVocu)
//            {
//                case PonasanjePremaVocu.Jabuka:
//                    tikTakObican();
//                    break;
//                case PonasanjePremaVocu.DveJabuke:
//                    tikTakJabuke();
//                    break;
//                case PonasanjePremaVocu.Razno:
//                    tikTakIzmeneVocki();
//                    break;
//                default:
//                    break;
//            }
//            trenutnoVreme++;
//            if(trenutnoVreme == vreme && naVreme)
//            {
//                jeKraj = true;
//            }
//        }

//        public void Skreni(Smer smer)
//        {
//            igrac.Zmija.Skreni(smer);
//        }

//        public Color VratiBoju(Pozicija p)
//        {
//            Color color = tabla.Boja;
//            if (p == vocka.Pozicija)
//                color = vocka.Boja;
//            if (p.PozicijaPripadaListi(igrac.Zmija.Pozicije))
//                color = igrac.Zmija.Boja;
//            if (p.PozicijaPripadaListi(tabla.PozicijePrepreka))
//                color = tabla.BojaPrepreke;
//            return color;
//        }

//        #endregion

//        #region Private Methods

//        private void izvrsiEfekte(List<Efekat> efekti)
//        {
//            if (efekti != null)
//            {
//                foreach (var efekat in efekti)
//                {
//                    switch (efekat)
//                    {
//                        case Efekat.DodajPoene:
//                            igrac.OsvojPoene(vocka.Poeni);
//                            break;
//                        case Efekat.DodajZivot:
//                            igrac.ZaradiZivot();
//                            break;
//                        case Efekat.OduzmiZivot:
//                            igrac.IzgubiZivot();
//                            break;
//                        case Efekat.UkloniPrepreku:
//                            tabla.UkoniPrepreku();
//                            break;
//                        default:
//                            break;
//                    }
//                }
//            }
//        }
//        private List<Pozicija> vratiZabranjenePozicije()
//        {
//            var zabranjenePozicije = new List<Pozicija>();
//            zabranjenePozicije.AddRange(igrac.Zmija.Pozicije);
//            zabranjenePozicije.AddRange(tabla.PozicijePrepreka);
//            zabranjenePozicije.Add(vocka.Pozicija);
//            return zabranjenePozicije;
//        }

//        private void tikTakObican()
//        {
//            igrac.Zmija.Korakni(tabla.PozicijePrepreka, new List<Pozicija> { vocka.Pozicija });
//            var efekti = vocka.Pojedi(igrac.Zmija.Glava, tabla.PozicijePrepreka);
//            izvrsiEfekte(efekti);

//            if (vocka.JeNestala)
//            {
//                vocka.Iznikni(vratiZabranjenePozicije());
//            }
//            tabla.StvoriPrepreku(vratiZabranjenePozicije());

//            if (igrac.Zmija.SeSlupala)
//            {
//                igrac.IzgubiZivot();
//            }

//            jeKraj = !igrac.JeZiv;
//        }

//        private void tikTakIzmeneVocki()
//        {
//            igrac.Zmija.Korakni(tabla.PozicijePrepreka, new List<Pozicija> { vocka.Pozicija });
//            var efekti = vocka.Pojedi(igrac.Zmija.Glava, tabla.PozicijePrepreka);
//            izvrsiEfekte(efekti);

//            if (vocka.JeNestala)
//            {
//                vocka = vocka.IznikniNovaVocka(vratiZabranjenePozicije());
//            }
//            tabla.StvoriPrepreku(vratiZabranjenePozicije());

//            if (igrac.Zmija.SeSlupala)
//            {
//                igrac.IzgubiZivot();
//            }

//            jeKraj = !igrac.JeZiv;
//        }

//        private int brojPrethodnihJabuka = 0;
//        private void tikTakJabuke()
//        {
//            igrac.Zmija.Korakni(tabla.PozicijePrepreka, new List<Pozicija> { vocka.Pozicija });
//            var efekti = vocka.Pojedi(igrac.Zmija.Glava, tabla.PozicijePrepreka);
//            izvrsiEfekte(efekti);

//            if (vocka.JeNestala)
//            {
//                if (brojPrethodnihJabuka == 2)
//                {
//                    vocka = vocka.IznikniNovaZlatnaJabuka(vratiZabranjenePozicije());
//                    brojPrethodnihJabuka = 0;
//                }
//                else
//                {
//                    vocka = vocka.IznikniNovaJabuka(vratiZabranjenePozicije());
//                    brojPrethodnihJabuka++;
//                }
//            }
//            tabla.StvoriPrepreku(vratiZabranjenePozicije());

//            if (igrac.Zmija.SeSlupala)
//            {
//                igrac.IzgubiZivot();
//            }

//            jeKraj = !igrac.JeZiv;
//        }

//        public void Skreni1(Smer smer)
//        {
//            Skreni(smer);
//        }

//        public void Skreni2(Smer smer)
//        {
//            return;
//        }

//        #endregion

//    }
//}
