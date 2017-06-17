using System;
using System.Windows.Forms;

namespace Kursach_MO.UserControls
{
    public partial class GoldDivision : UserControl
    {
        private double a, b, E;
        private double x1, x2, f1, f2, f0, x0;
        private int i;

        public GoldDivision()
        {
            InitializeComponent();
        }

        double Function(double x)
        {
            double f = 0;
            i++;
            if (radioButton1.Checked)
            {
                f = Math.Pow(x, 2);
            }
            if (radioButton2.Checked)
            {
                f = Math.Pow(x - 2, 2);
            }
            if (radioButton3.Checked)
            {
                f = Math.Sin(x);
            }
            if (radioButton4.Checked)
            {
                f = 2 * x * x - 12 * x;
            }
          
            return f;
        }

        void GoldDevision()
        {
            x1 = a + 0.382 * (b - a);
            x2 = b - 0.382*(b - a);
            f1=Function(x1);
            f2 = Function(x2);


            do
            {
                if (f1 < f2)
                {
                    b = x2;
                    x2 = x1;
                    x1 = a + 0.382 * (b - a);
                    f2 = f1;
                    f1 = Function(x1);
                }

                else
                {
                    a = x1;
                    x1 = x2;
                    x2 = b - 0.382 * (b - a);
                    f1 = f2;
                    f2 = Function(x2);

                }
            } while (Math.Abs(b-a)>E);

            x0 = (a + b) / 2;
            f0 = Function(x0);
            x0_TB.Text = Convert.ToString(Math.Round(x0, 5));
            f0_TB.Text = Convert.ToString(Math.Round(f0, 5));
          

        }

        private void clc_Button_Click(object sender, EventArgs e)
        {
            i = 0;
            if (a_TB.Text == "")
            {
                MessageBox.Show("введите а");
                a_TB.Focus();
            }
            if (b_TB.Text == "")
            {
                MessageBox.Show("введите b");
                b_TB.Focus();
            }
            a = Convert.ToDouble(a_TB.Text);
            b = Convert.ToDouble(b_TB.Text);
            E = Convert.ToDouble(e_TB.Text.Replace(".", ","));

            GoldDevision();
        }
    }
}
