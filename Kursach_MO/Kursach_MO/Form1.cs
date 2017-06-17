using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kursach_MO.UserControls;

namespace Kursach_MO
{
    public partial class Form1 : Form
    {
        private DelenyeIntervalaPopolam p1;
        private GoldDivision p2;
        private SquareInterpolation p3;
        private HookeDjieves p4;
        private Simplex p5;


        public Form1()
        {
            InitializeComponent();
            p1 = new DelenyeIntervalaPopolam();
            p2=new GoldDivision();
            p3=new SquareInterpolation();
            p4=new HookeDjieves();
            p5=new Simplex();
         }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(p1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(p2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(p3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(p4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(p5);
        }
    }
}
