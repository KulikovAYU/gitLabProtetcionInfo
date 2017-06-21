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
    public partial class Form2 : Form
    {
        //public Graphics g;
        //public Bitmap bmp=new Bitmap(600,400);
        public Graphics gr;
        public Pen pero = new Pen(Color.Black);
        double max, step, nkoordx, nkoordy;
        Simplex.structura s1;
        int o, j = 0;

     

        public Form2(Simplex.structura s, int i)
        {

            InitializeComponent();
            gr = CreateGraphics();
            s1 = s;
            o = i;
            //s1 = s;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            //bmp = new Bitmap(600, 400);
            //gr = Graphics.FromImage(bmp);
            //gr.DrawRectangle(Pens.Black, 10, 10, 500, 500);
            //gr.DrawLine(Pens.Black, 0, 0, 100, 50);
            // рисуем координатные оси
            gr.DrawLine(Pens.Black, 250, 0, 250, 500);
            gr.DrawLine(Pens.Black, 0, 250, 500, 250);
            max = Math.Max(s1.p1x[0], Math.Max(s1.p1y[0], Math.Max(s1.p2x[0], Math.Max(s1.p2y[0], Math.Max(s1.p3x[0], s1.p3y[0])))));
            max *= 2;
            step = 250 / max;
            step = step - (step % 2);
            if (step % 2 != 0) step -= 1;

            int i= 0;
            // наносим насечки
            for (double x = 250; x < 500; x += step)
            {

                gr.DrawLine(Pens.Black, (float)x, (float)(250 - step / 10), (float)x, (float)(250 + step / 10));
                gr.DrawString(i.ToString(),new Font("Arial",10),Brushes.Black,new PointF((float)x-5f, (float)(250 - step / 10)+7f) );
                i++;

            }
            i = 0;
            for (double x = 250; x > 0; x -= step)
            {
                gr.DrawLine(Pens.Black, (float)x, (float)(250 - step / 10), (float)x, (float)(250 + step / 10));
                gr.DrawString(i.ToString(), new Font("Arial", 10), Brushes.Black, new PointF((float)x - 5f, (float)(250 - step / 10) + 7f));
                i--;
            }

            i = 0;
            for (double y = 250; y < 500; y += step)
            {
                gr.DrawLine(Pens.Black, (float)(250 - step / 10), (float)y, (float)(250 + step / 10), (float)y);
                gr.DrawString(i.ToString(), new Font("Arial", 10), Brushes.Black, new PointF((float)(250 - step / 10) + 7f, (float)y - 5f));
                i--;
            }

            i = 0;
            for (double y = 250; y > 0; y -= step)

            {
                gr.DrawLine(Pens.Black, (float)(250 - step / 10), (float)y, (float)(250 + step / 10), (float)y);
                gr.DrawString(i.ToString(), new Font("Arial", 10), Brushes.Black, new PointF((float)(250 - step / 10) + 7f , (float)y - 5f));
                i++;
            }
            
            nkoordx = 250;
            nkoordy = 250;
            //Random r1 = new Random();
            //float k1 = (float)r1.NextDouble();
            //MessageBox.Show(o.ToString());

            //MessageBox.Show(s1.p1x[0].ToString()+' '+s1.p1y[0].ToString());



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (j != o)
            {
                gr.DrawLine(pero, (float)(nkoordx + s1.p1x[j] * step), (float)(nkoordy - s1.p1y[j] * step), (float)(nkoordx + s1.p2x[j] * step), (float)(nkoordy - s1.p2y[j] * step));
                gr.DrawLine(pero, (float)(nkoordx + s1.p1x[j] * step), (float)(nkoordy - s1.p1y[j] * step), (float)(nkoordx + s1.p3x[j] * step), (float)(nkoordy - s1.p3y[j] * step));
                gr.DrawLine(pero, (float)(nkoordx + s1.p3x[j] * step), (float)(nkoordy - s1.p3y[j] * step), (float)(nkoordx + s1.p2x[j] * step), (float)(nkoordy - s1.p2y[j] * step));

                if (j % 5 == 0) pero.Color = Color.Red;
                else
                {
                    if (j % 5 == 1) pero.Color = Color.Green;
                    else
                    {
                        if (j % 5 == 2) pero.Color = Color.Orange;
                        else
                        {
                            if (j % 5 == 3) pero.Color = Color.Blue;
                            else
                            {
                                pero.Color = Color.Brown;
                            }
                        }
                    }
                }
                j++;
            }
            else
            {
                MessageBox.Show("Конец поиска");
            }
        }
    }
}
