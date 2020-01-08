using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Zmijica
{
    public partial class Form1 : Form
    {


        #region Fields

        Timer sat;
        Nivo nivo;
        IIgra igra;
        int vreme;
        #endregion

        #region Constructors

        public Form1()
        {
            InitializeComponent();
            this.Width = 900;
            this.Height = 700;

            txtBrzina.Maximum = 3000;
            txtBrzina.Minimum = 1;
            txtBrzina.Value = 400;

            txtTrajanje.Maximum = 40;
            txtTrajanje.Minimum = 4;
            txtTrajanje.Value = 20;

            txtVreme.Maximum = 100000;
            txtVreme.Minimum = 0;
            txtVreme.Value = 100;

            vreme = 0;

            popuniNivo(new NivoSrednji());
            nivo = new NivoSrednji();

            kreirajTimer();
            startIgreJedanIgrac();
            nacrtajGridPrviPut();
            nacrtajGrid();
        }



        #endregion

        #region Methods

        #endregion

        #region Private Methods

        #region Akcije korisnika

        private void korisnikPritisnuoDugmic(object sender, KeyEventArgs e)
        {
            var key = (Keys)e.KeyValue;
            switch (key)
            {
                case Keys.Up:
                    igra.Skreni1(Smer.Gore);
                    break;
                case Keys.Down:
                    igra.Skreni1(Smer.Dole);
                    break;
                case Keys.Right:
                    igra.Skreni1(Smer.Desno);
                    break;
                case Keys.Left:
                    igra.Skreni1(Smer.Levo);
                    break;
                case Keys.W:
                    igra.Skreni2(Smer.Gore);
                    break;
                case Keys.S:
                    igra.Skreni2(Smer.Dole);
                    break;
                case Keys.D:
                    igra.Skreni2(Smer.Desno);
                    break;
                case Keys.A:
                    igra.Skreni2(Smer.Levo);
                    break;
                case Keys.P:
                    pauzirajSat();
                    break;
                default:
                    break;
            }
        }

        private void start(object sender, EventArgs e)
        {
            ucitajNivo();
            if (rbr1.Checked)
                startIgreJedanIgrac();
            else
                startIgreDvaIgraca();
            pokreniSat();
            txtPoeni1.Focus();
        }

        private void ucitajNivo()
        {
            PonasanjePremaVocu ponasanje = PonasanjePremaVocu.Razno;
            if (cbxTipIgre.SelectedItem.ToString() == "Jabuka") ponasanje = PonasanjePremaVocu.Jabuka;
            if (cbxTipIgre.SelectedItem.ToString() == "DveJabuke") ponasanje = PonasanjePremaVocu.DveJabuke;
            nivo = new Nivo(chkRaste.Checked, !chkProlazi.Checked, (int)txtBrzina.Value, chkPrepreke.Checked, (int)txtTrajanje.Value, ponasanje, chkIdeUKrug.Checked, chkSeSudara.Checked, chkNaVreme.Checked, (int)txtVreme.Value);
        }
        #endregion

        #region Sat

        private void pokreniSat()
        {
            sat.Start();
        }
        private void tikTak(object sender, EventArgs e)
        {
            vreme++;
            igra.TikTak();
            nacrtajGrid();
            if (igra.JeKraj)
            {
                sat.Stop();
                MessageBox.Show($"Pobednik je {igra.Pobednik() ?? string.Empty}", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
            }
        }

        private void pauzirajSat()
        {
            if (sat.Enabled)
            {
                sat.Stop();
                label1.Visible = true;
            }
            else
            {
                sat.Start();
                label1.Visible = false;
            }
        }

        private void podesiSat(int brzina)
        {
            if (brzina < 1 || brzina > 3000)
            {
                MessageBox.Show("Nije ispravna brzina!");
                return;
            }
            sat.Interval = brzina;
        }

        #endregion

        #region Opste

        private void nacrtajGrid()
        {
            txtPoeni1.Text = igra.Igrac1 == null ? string.Empty : igra.Igrac1.Poeni.ToString();
            lblBrojZivota1.Text = igra.Igrac1 == null ? string.Empty : igra.Igrac1.Zivoti.ToString();

            txtPoeni2.Text = igra.Igrac2 == null ? string.Empty : igra.Igrac2.Poeni.ToString();
            lblBrojZivota2.Text = igra.Igrac2 == null ? string.Empty : igra.Igrac2.Zivoti.ToString();

            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    Pozicija p = new Pozicija(i, j);
                    tableLayoutPanel1.GetControlFromPosition(i, j).BackColor = igra.VratiBoju(p);
                }
            }

            txtSat.Text = vreme.ToString();
        }
        #endregion

        #region Inicijalno
        private void startIgreJedanIgrac()
        {
            igra = new IgraJedanIgrac(nivo);
            podesiSat(nivo.Brzina);
        }

        private void startIgreDvaIgraca()
        {
            igra = new IgraDvaIgraca(nivo);
            podesiSat(nivo.Brzina);
        }

        private void kreirajTimer()
        {
            sat = new Timer();
            sat.Interval = 500;
            sat.Tick += new EventHandler(tikTak);

        }

        private void nacrtajGridPrviPut()
        {
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    var panel = new Panel();
                    tableLayoutPanel1.Controls.Add(new Panel(), i, j);
                }
            }
        }



        #endregion

        #endregion

        private void lakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popuniNivo(new NivoLak());

        }

        private void srednjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popuniNivo(new NivoSrednji());
        }

        private void tezakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popuniNivo(new NivoTezak());
        }

        private void popuniNivo(Nivo n)
        {
            txtBrzina.Value = n.Brzina;
            txtTrajanje.Value = n.VremeDoPrepreke;
            chkPrepreke.Checked = n.SePojavljujuPrepreke;
            chkRaste.Checked = n.Raste;
            chkProlazi.Checked = !n.SeSudaraSamaSaSobom;
            cbxTipIgre.SelectedItem = n.PonasanjePremaVocu.ToString();
            chkIdeUKrug.Checked = n.IdeUKrug;
            chkSeSudara.Checked = n.SeSudaraju;
            chkNaVreme.Checked = n.NaSat;
            txtVreme.Value = n.Vreme;
        }

        private void r2D2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
