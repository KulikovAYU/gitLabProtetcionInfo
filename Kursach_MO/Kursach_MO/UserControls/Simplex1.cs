using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach_MO.UserControls
{
    using static Console;
    public partial class Simplex1 : UserControl
    {
        
        struct Point
        {
            public double x1 { get; set; } 
            public double x2 { get; set; } 
        }

        public Simplex1()
        {
            InitializeComponent();
        }

        private void clc_Button_Click(object sender, EventArgs e)
        {
            Point[] point=new Point[3];

            point[0].x1 = Convert.ToDouble(x0_TB.Text.Replace(".","."));
            point[0].x2 = Convert.ToDouble(y0_TB.Text.Replace(".", ".")); ;

            int N = 2;
            int alpha = 1;// - рёбра симплекса имеют единичную длину

            double d1 = ((Math.Sqrt(N + 1) + N - 1) / (N * Math.Sqrt(2))) * alpha;
            double d2 = ((Math.Sqrt(N + 1)  - 1) / (N * Math.Sqrt(2))) * alpha;

            WriteLine(d1);
            point[1].x1 = point[0].x1 + d1;
            point[1].x2 = point[0].x2 + d2;

            point[1].x1 = point[0].x1 + d2;
            point[1].x2 = point[0].x2 + d1;
        }
    }
}
