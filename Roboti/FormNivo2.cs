using Roboti.Podloge;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Roboti
{
    public partial class FormNivo2 : Form
    {

        #region Fields
        
        Timer sat;
        int vreme;
        Igra igra;
        Smer smer;
        Udar udar;

        #endregion

        #region Constructors

        public FormNivo2()
        {
            InitializeComponent();

            kreirajTimer();
        }

        #endregion

        #region Methods
        private void start()
        {
            igra = new Igra();
            pokreniSat();
            pictureBoxSredina.Focus();
        }

        private void tikTak(object sender, EventArgs e)
        {
            vreme++;
            nacrtajGrid(vreme);

            proveriKraj();
            igra.korakni();
            igra.TikTak(smer, udar);

            //if (igra.JeKraj)
            //{
            //    sat.Stop();
            //    MessageBox.Show($"Pobednik je {igra.Pobednik() ?? string.Empty}", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //}
        }

        private void nacrtajGrid(int vreme)
        {
            for (int i = 0; i < 10; i++)
            { 
                var slika = igra.vrati(vreme + i + 1);
                var dugme = vratiDugme(i);
                dugme.BackgroundImage = (new ImageHelper()).vratiSliku(slika.ImgPath, 81, 91);
            }
        }

        private void proveriKraj()
        {
            if (igra.Kraj == Kraj.Ne) return;
            sat.Stop();
            if (igra.Kraj == Kraj.Prosao)
            {
                string imgPath = @"C:\Users\marinao\source\repos\Zmijica\Roboti\Images\r2-bb8.jpg";
                pictureBoxSredina.Image = (new ImageHelper()).vratiSliku(imgPath, 81, 91);
                MessageBox.Show($"Bravo, pobedio si!", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show($"Izgubio si!", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private Button vratiDugme(int i)
        {
            switch (i)
            {
                case 0:
                    return btn1;
                case 1:
                    return btn2;
                case 2:
                    return btn3;
                case 3:
                    return btn4;
                case 4:
                    return btn5;
                case 5:
                    return btn6;
                case 6:
                    return btn7;
                case 7:
                    return btn8;
                case 8:
                    return btn9;
                case 9:
                    return btn10;
                default:
                    return btn1;
                    break;
            }
        }

        #endregion

        #region Private Methods

        private void korisnikPritisnuoDugmic(object sender, KeyEventArgs e)
        {
            string imgPathGore = @"C:\Users\marinao\source\repos\Zmijica\Roboti\Images\bb8 ide prema r2d2Gore.jpeg";
            string imgPathDole = @"C:\Users\marinao\source\repos\Zmijica\Roboti\Images\bb8 ide prema r2d2Dole.jpeg";

            smer = Smer.Desno;
            var key = (Keys)e.KeyValue;
            switch (key)
            {
                case Keys.Up:
                    smer = Smer.Gore;
                    //pictureBoxSredina.Image = (new ImageHelper()).vratiSliku(imgPathGore, 81, 91);
                    pictureBoxSredina.Image = null;
                    pictureBoxDole.Image = null;
                    pictureBoxGore.Image = (new ImageHelper()).vratiSliku(imgPathGore, 81, 91);

                    break;
                case Keys.Down:
                    smer = Smer.Dole;
                    //pictureBoxSredina.Image = (new ImageHelper()).vratiSliku(imgPathDole, 81, 91);
                    pictureBoxSredina.Image = null;
                    pictureBoxDole.Image = (new ImageHelper()).vratiSliku(imgPathGore, 81, 91); ;
                    pictureBoxGore.Image = null;
                    break;
                case Keys.Right:
                    smer = Smer.Desno;
                    pictureBoxSredina.Image = (new ImageHelper()).vratiSliku(imgPathGore, 81, 91); ;
                    pictureBoxDole.Image = null;
                    pictureBoxGore.Image = null;
                    break;
                case Keys.Left:
                    smer = Smer.Desno;//??
                    break;
                
                case Keys.P:
                    //pauzirajSat();
                    break;
                default:
                    break;
            }
            Udar udar = Udar.Ne;
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                udar = Udar.Da;
            }
        }

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            start();
        }
        #region Sat

        private void kreirajTimer()
        {
            sat = new Timer();
            sat.Interval = 1000;
            sat.Tick += new EventHandler(tikTak);

        }
        private void pokreniSat()
        {
            sat.Start();
        }
        private void pauzirajSat()
        {
            if (sat.Enabled)
            {
                sat.Stop();
            }
            else
            {
                sat.Start();
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
    }
}
