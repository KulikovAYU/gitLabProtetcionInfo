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
            new Lab1().ShowDialog();
        }

        private void LabBTN2_Click(object sender, EventArgs e)
        {
            new Lab2().ShowDialog();
        }

        private void LabBTN3_Click(object sender, EventArgs e)
        {
            new Lab3().ShowDialog();
        }

        private void LabBTN4_Click(object sender, EventArgs e)
        {
            new Lab4().ShowDialog();
        }
    }
}