using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fabrika
{
    public partial class Form1 : Form
    {

        #region Fields

        IIgra igra;
        Timer sat;
        int vreme;

        #endregion

        #region Constructors

        public Form1()
        {
            InitializeComponent();

            vreme = 0;
            kreirajTimer();
        }

        #endregion

        #region Methods

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            igra = new IgraJedanIgrac(true, 2, "Bo ili Vivi :) ");
            igra.start();
            pokreniSat();        }

        #endregion

        #region Private Methods

        private void kreirajTimer()
        {
            sat = new Timer();
            sat.Interval = 5000; //5sekundi
            sat.Tick += new EventHandler(tikTak);

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

        private void pokreniSat()
        {
            sat.Start();
        }
        private void tikTak(object sender, EventArgs e)
        {
            vreme++;
            igra.TikTak();
            //nacrtajGrid();
            if (igra.JeKraj)
            {
                sat.Stop();
                MessageBox.Show($"Pobednik je {igra.Pobednik() ?? string.Empty}", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        #endregion




    }
}
