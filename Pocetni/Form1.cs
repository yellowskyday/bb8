using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pocetni
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 1000;
            this.Height = 750;
        }

        private void imgBB8_Click(object sender, EventArgs e)
        {
            Roboti.Form1 f = new Roboti.Form1();
            f.ShowDialog();
        }

        private void imgZmijica_Click(object sender, EventArgs e)
        {
            Zmijica.Form1 f = new Zmijica.Form1();
            f.ShowDialog();
        }

        private void btnFabrika_Click(object sender, EventArgs e)
        {
            Fabrika.Form1 f = new Fabrika.Form1();
            f.ShowDialog();
        }
    }
}
