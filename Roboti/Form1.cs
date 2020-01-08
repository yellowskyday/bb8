using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roboti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormNivo1 formNivo1 = new FormNivo1();
            formNivo1.ShowDialog();
        }

        private void btnNivo2_Click(object sender, EventArgs e)
        {
            FormNivo2 formNivo2 = new FormNivo2();
            formNivo2.ShowDialog();
        }
    }
}
