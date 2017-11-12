using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Labs : Form
    {
        public Labs()
        {
            InitializeComponent();
        }

        private void LabBTN1_Click(object sender, EventArgs e)
        {
            Lab1 lab = new Lab1();
            lab.ShowDialog();
        }

        private void LabBTN2_Click(object sender, EventArgs e)
        {
            Lab2 lab = new Lab2();
            lab.ShowDialog();
        }
    }
}
