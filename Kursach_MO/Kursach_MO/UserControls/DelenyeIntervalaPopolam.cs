using System;
using System.Windows.Forms;

namespace Kursach_MO.UserControls
{
    public partial class DelenyeIntervalaPopolam : UserControl
    {
        private double a,b,E;
        private double xm, fm, x1, x2, f1, f2,f0,x0;
        private int i;

        public DelenyeIntervalaPopolam()
        {
            InitializeComponent();
        }

       double Function(double x)
       {
           double f=0;
           i++;
           if (radioButton1.Checked)
           {
               f = Math.Pow(x, 2);
            }
           if (radioButton2.Checked)
           {
               f = Math.Pow(x-2, 2);
           }
           if (radioButton3.Checked)
           {
               f =Math.Sin(x);
            }
           if (radioButton4.Checked)
           {
               f = 2 * x * x - 12 * x;
           }
           listBox1.Items.Add(f);
           return f;
       }

        
        void Dixotomia()
        {
            
            do
            {
                
                xm = (a + b) / 2;
                x1 = (a + xm) / 2;
                x2 = (b + xm) / 2;

                fm = Function(xm);
                f1 = Function(x1);
                f2 = Function(x2);

                if (fm > f1)
                {
                    b = xm;
                    xm = x1;
                    fm = f1;
                }
                else
                {
                    if (fm > f2)
                    {
                       a = xm;
                       xm = x2;
                       fm = f2;
                    }
                    else
                    {
                        a = x1;
                        b = x2;
                    }
                }
            } while (Math.Abs(b - a) > E);
          
           
                x0 = (a + b) / 2;
                f0 = Function(x0);
                x0_TB.Text = Convert.ToString(x0);
                f0_TB.Text = Convert.ToString(f0);
         }


        private void clc_Button_Click(object sender, EventArgs e1)
        {
           i = 0;
           listBox1.Items.Clear();
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
            E = Convert.ToDouble(e_TB.Text.Replace(".",","));

            Dixotomia();

           
        }


    }
}
