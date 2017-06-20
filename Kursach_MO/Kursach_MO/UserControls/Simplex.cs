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

    public partial class Simplex : UserControl
    {
        public struct structura { public double[] p1x; public double[] p1y; public double[] p2x; public double[] p2y; public double[] p3x; public double[] p3y; }

        int n, alpha = 1, gamma = 2;
        double k = 2, beta = 0.5, eps;
        double[,] Simpl;
        double[] Xn, F;
        public Bitmap bmp;

        int o , h, g, l;

        

        double fh, fl, fg;
        bool flagh = false, flagg = false, flagl = false;

      

        double sigma=1;
        Graphics graph;
       
        public Pen pero = new Pen(Color.Black);
        public Simplex()
        {
            graph = CreateGraphics();
            InitializeComponent();
            n = 2;//количество переменных
        }

        public double Func(double[] X)
        {
            double f = 0;
            //MessageBox.Show(X[0].ToString());
            double x = X[0];
            double y = X[1];

            if (radioButton1.Checked)
                {
                    f =Math.Pow(x,2)  + Math.Pow(y,2);
                }
            if (radioButton2.Checked)
                {
                    f = 100 * Math.Pow((y - x * x), 2) + Math.Pow((1 - x), 2);
                }
            if (radioButton3.Checked)
                {
                    f = Math.Pow(x, 4) + Math.Pow(y, 4) + 2 * Math.Pow(x, 2) * Math.Pow(y, 2) - 4 * x + 3;
                }
            
          return f;
        }

        private structura smpl;

        private void clc_Button_Click(object sender, EventArgs e)
        {
            Xn = new double[n];
            Simpl = new double[n, n + 1];
            double[] X0 = new double[n];
            double[] Xr = new double[n];
            double[] Xe = new double[n];
            double[] Xc = new double[n];
            smpl = new structura();
            smpl.p1x = new double[500];
            smpl.p1y = new double[500];
            smpl.p2x = new double[500];
            smpl.p2y = new double[500];
            smpl.p3x = new double[500];
            smpl.p3y = new double[500];
            double Fr, Fe, Fc;


            F = new double[n + 1];
            
            eps = Convert.ToDouble(E_TB.Text);
            o = 0;//счетчик итераций
            Xn[0]= Convert.ToDouble(x0_TB.Text);
            Xn[1] = Convert.ToDouble(y0_TB.Text);

            textBox3.Clear();

            Creation();

            Calculation();
            check();
            while (sigma > eps)
            {
                if (flagl == false)
                {
                    FindMax();
                }
                flagl = false;
                flagg = false;
                textBox3.Text = textBox3.Text + string.Format("{0}\t", o+1);
                for (int i = 0; i < n + 1; i++)
                {
                    textBox3.Text = textBox3.Text + string.Format("(");
                    for (int j = 0; j < n; j++)
                    {
                        if (j != n - 1)
                        {
                            textBox3.Text = textBox3.Text + string.Format("{0:f6};", Simpl[j, i]);
                        }
                        else
                        {
                            textBox3.Text = textBox3.Text + string.Format("{0:f6}", Simpl[j, i]);
                        }
                    }
                    textBox3.Text = textBox3.Text + string.Format(")\t");
                }

                textBox3.Text = textBox3.Text + string.Format("{0:f15}", fl);
                textBox3.Text += Environment.NewLine;
                if (n == 2)
                {
                    smpl.p1x[o] = Simpl[0, 0];
                    smpl.p1y[o] = Simpl[1, 0];
                    smpl.p2x[o] = Simpl[0, 1];
                    smpl.p2y[o] = Simpl[1, 1];
                    smpl.p3x[o] = Simpl[0, 2];
                    smpl.p3y[o] = Simpl[1, 2];
                }

                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < n + 1; i++)
                    {
                        if (i != h)
                        {
                            X0[j] += Simpl[j, i] / n;
                        }

                    }
                }
                for (int i = 0; i < n; i++)
                {
                    Xr[i] = (1 + alpha) * X0[i] - alpha * Simpl[i, h];
                }
                Fr = Func(Xr);
                if (Fr <= fl)
                {
                    for (int i = 0; i < n; i++)
                    {
                        Xe[i] = gamma * Xr[i] + (1 - gamma) * X0[i];
                    }
                    Fe = Func(Xe);
                    if (Fe <= fl)
                    {
                        for (int i = 0; i < n; i++)
                            Simpl[i, h] = Xe[i];
                        l = h;
                        h = g;
                        fl = Fe;
                        fh = fg;
                        F[l] = Fe;
                        //F[h] = fg;
                        flagg = true;
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                            Simpl[i, h] = Xr[i];
                        l = h;
                        h = g;
                        fl = Fr;
                        fh = fg;
                        F[l] = Fr;
                        //F[h] = fg;
                        flagg = true;
                    }
                }
                else
                {
                    if (Fr <= fg)
                    {
                        for (int i = 0; i < n; i++)
                            Simpl[i, h] = Xr[i];
                        F[h] = Fr;
                        h = g;
                        fh = fg;

                        //F[h] = fg;
                        flagg = true;
                    }
                    else
                    {
                        if (Fr >= fh)
                        {
                            for (int i = 0; i < n; i++)
                                Xc[i] = (1 + beta) * X0[i] - 1 * beta * Xr[i];
                            Fc = Func(Xc);
                            if (Fc < fh)
                            {
                                for (int i = 0; i < n; i++)
                                    Simpl[i, h] = Xc[i];
                                F[h] = Fc;
                                fh = Fc;

                                //F[h] = Fc;
                                //flagl = true;
                            }
                            else
                            {
                                for (int i = 0; i < n + 1; i++)
                                {

                                    if (i == l) continue;
                                    for (int j = 0; j < n; j++)
                                    {

                                        Simpl[j, i] = 0.5 * (Simpl[j, i] - Simpl[j, l]) + Simpl[j, l];

                                    }
                                }
                                flagh = true;

                            }
                        }
                        else
                        {
                            for (int i = 0; i < n; i++)
                                Simpl[i, h] = Xr[i];
                            F[h] = Fr;
                            fh = Fr;
                            flagl = true;
                        }
                    }
                }
                if (flagh == true)
                {
                    Calculation();
                }
                flagh = false;
                check(); 
                //MessageBox.Show(sigma.ToString());
                for (int i = 0; i < n; i++)
                {
                    X0[i] = 0;

                }
                o++;
                //new Form2(Simpl);

               

            }
            textBox3.Text = textBox3.Text + string.Format("{0}\t", o);
            for (int i = 0; i < n + 1; i++)
            {
                textBox3.Text = textBox3.Text + string.Format("(");
                for (int j = 0; j < n; j++)
                {
                    if (j != n - 1)
                    {
                        textBox3.Text = textBox3.Text + string.Format("{0:f6};", Simpl[j, i]);
                    }
                    else
                    {
                        textBox3.Text = textBox3.Text + string.Format("{0:f6}", Simpl[j, i]);
                    }
                }
                textBox3.Text = textBox3.Text + string.Format(")\t");
            }

            textBox3.Text = textBox3.Text + string.Format("{0:f15}", fl);
            textBox3.Text += Environment.NewLine;
            // MessageBox.Show(fl.ToString());


            //MessageBox.Show("Поиск закончен. Количество итераций {0}", {o});
            MessageBox.Show("Поиск закончен. Количество итераций "+ o);
        }

        public void Creation()
        {
            /*for (int i = 0; i < n ; i++)
                k += Xn[i]/n;*/
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n + 1; j++)
                    Simpl[i, j] = Xn[i];
            for (int i = 1; i < n + 1; i++)
                Simpl[i - 1, i] = Simpl[i - 1, i] + k;
        }
        public void FindMax()
        {
            if (flagg != true)
            {
                fh = F[0];
                h = 0;
                for (int i = 1; i < n + 1; i++)
                {
                    if (fh < F[i])
                    {
                        fh = F[i];
                        h = i;
                    }
                }
            }
            if (flagg != true)
            {
                fl = F[0];
                l = 0;
                for (int i = 1; i < n + 1; i++)
                {
                    if (fl > F[i])
                    {
                        fl = F[i];
                        l = i;
                    }
                }
            }
            if (h != 0 && l != 0)
            {
                fg = F[0];
                g = 0;
            }
            else
            {
                if (h != 1 && l != 1)
                {
                    fg = F[1];
                    g = 1;
                }
                else
                {
                    fg = F[2];
                    g = 2;
                }
            }
            for (int i = g; i < n + 1; i++)
            {
                if (fg < F[i] && i != h && i != l)
                {
                    fg = F[i];
                    g = i;
                }
            }
        }
        public void check() 
        {
            double fsr, sigmabuf;
        fsr = 0;
            sigmabuf = 0;
            for (int i = 0; i<n + 1; i++)
                fsr += F[i] / (n + 1);
            for (int i = 0; i<n + 1; i++)
                sigmabuf += Math.Pow(F[i] - fsr, 2) / (n + 1);
            sigma = Math.Sqrt(sigmabuf);


        }
    public void Calculation()
        {
            for (int i = 0; i < n + 1; i++)
            {
                double[] xbuf = new double[n];
                for (int j = 0; j < n; j++)
                    xbuf[j] = Simpl[j, i];
                F[i] = Func(xbuf);
            }
        }
        private void Graph_BT_Click(object sender, EventArgs e)
        {
            new Form2(smpl, o).Show();
        }
    }
}
