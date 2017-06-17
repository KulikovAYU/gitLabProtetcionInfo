using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kursach_MO.UserControls
{
   

    public partial class HookeDjieves : UserControl
    {
        public HookeDjieves()
        {
            InitializeComponent();
        }

        Bitmap bmp = new Bitmap(600, 400);

        private double Func(Point p)
        {
            double x = p.x;
            double y = p.y;
            double f=0;

            if (radioButton1.Checked)
            {
                f = x * x + y * y;
            }
            if (radioButton2.Checked)
            {
                f = 100*Math.Pow((y - x * x),2) +Math.Pow((1-x),2);
            }

            if (radioButton3.Checked)
            {
                f = Math.Pow(x, 4)+ Math.Pow(y, 4) + 2* Math.Pow(x, 2) * Math.Pow(y, 2)-4*x+3;
            }

            return f;
            // return 2 * x - 1.3 * y + Math.Exp(0.04 * x * x + 0.12 * y * y);
        }

        private double Research(double [] x) // Исследовательский поиск
        {

        double[] x_new = new double[2]; ;

            bool Success = false;

                do
                {
                    Success = false;

                    for (int i = 0; i < 2; i++)  // по каждой компоненте координатного вектора
                    {
                        x_new[i] = x[i] + h[i];    // пытаемся сделать шаг в направлении h[i]

                        if (Func(x_new[0], x_new[1]) >= Func(x[0], x[1]))  // если шаг в выбранном направлении был неудачным
                        {
                            h[i] = -h[i];          // изменяем направление шага на противоположное
                            x_new[i] = x[i] + h[i];  // снова пытаемся сделать шаг

                            if (Func(x_new[0], x_new[1]) < Func(x[0], x[1]))
                            {
                                x[i] = x_new[i];
                                Success = true;      //шаг был удачен
                            }
                        }
                        else
                        {
                            x[i] = x_new[i];
                            Success = true;        //шаг был удачен
                        }

                        x_new[i] = x[i];
                    }

                    if (Success == false) //производим дробление шага, т.к. поиск был неудачным
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            h[i] = h[i] / alpha;
                        }
                    }
                }
                while (Success || (Math.Abs(h[1]) > eps)); //пока не переместимся в новую точку или шаг поиска станет малым

            Xopt_TB.Text = $"({Math.Round(x[0], 6)}; {Math.Round(x[1], 6)})";
            Yopt_TB.Text = $"{Math.Round(Func(x[0], x[1]), 6)}";
            Draw(x[0], x[1]);
            return Research(x);
        }

        
        void Sample(double[] x) //поиск по образцу
        {
            double[] x_new;
            for (int i = 0; i < 2; i++)
            {
                x_new[i] = x[i] + lambda * (x[i] - x_prev[i]);
            }

            if (Func(x_new[0], x_new[1]) < Func(x[0], x[1])) // переходим на новую точку
            {
                for (int j = 0; j < 2; j++)
                {
                    x_prev[j] = x[j];
                    x[j] = x_new[j];
                }
            }
        }

        private double[] h;
        private double[] x_new;
        private double[] x_prev;
         
       

        private void Work()
        {
            double[] x = new double[2];
            Point[] point=new Point[2];

           
            //x[0] = Double.Parse(x0_TB.Text.Replace(".", ","));
            //x[1] = Double.Parse(y0_TB.Text.Replace(".", ","));

            double Step = Convert.ToDouble(dx_TB.Text.Replace(".",","));  //начальный шаг
            double eps = Convert.ToDouble(E_TB.Text.Replace(".", ",")); //точность поиска
            
            int lambda = 2; //ускоряющий коэффициент поиска по образцу
            int alpha = 2; //коэффициент уменьшения шага

            h = new double[2];
            
            //x_new = new double[2];
            //x_prev = new double[2];

            for (int i = 0; i < 2; i++) //задаем соответственно шаги по осям
            {
                h[i] = Step;// принимается равномерный шаг

                point[i].x= Double.Parse(x0_TB.Text.Replace(".", ","));// задали начальеую точку xk=x0 по координате х
                point[i].y= Double.Parse(y0_TB.Text.Replace(".", ","));// задали начальную точку xk=x0 по координате y
            }

            //Вычисляем f(xk)
            double f = Func(point[1]);


            

            // выполнить исследование в точке xk. Получить новую точку xk+1
            for (int i = 0; i < 2; i++)
            {
              //  x_prev[i] = x[i];
                x_new[i] = x[i];
                Research(x);
            }

            do
            {
            #region Коммент исследующий поиск
                //do
                //{
                //    Success = false;

                //    for (int i = 0; i < 2; i++)
                //    {
                //        x_prev[i] = x[i];
                //        x_new[i] = x[i];
                //    }

                //    for (int i = 0; i < 2; i++)  // по каждой компоненте координатного вектора
                //    {
                //        x_new[i] = x[i] + h[i];    // пытаемся сделать шаг в направлении h[i]

                //        if (Func(x_new[0], x_new[1]) >= Func(x[0], x[1]))  // если шаг в выбранном направлении был неудачным
                //        {
                //            h[i] = -h[i];          // изменяем направление шага на противоположное
                //            x_new[i] = x[i] + h[i];  // снова пытаемся сделать шаг

                //            if (Func(x_new[0], x_new[1]) < Func(x[0], x[1]))
                //            {
                //                x[i] = x_new[i];
                //                Success = true;      //шаг был удачен
                //            }
                //        }
                //        else
                //        {
                //            x[i] = x_new[i];
                //            Success = true;        //шаг был удачен
                //        }

                //        x_new[i] = x[i];
                //    }

                //    if (Success == false) //производим дробление шага, т.к. поиск был неудачным
                //    {
                //        for (int i = 0; i < 2; i++)
                //        {
                //            h[i] = h[i] / alpha;
                //        }
                //    }
                //}
                //while (Success || (Math.Abs(h[1]) > eps)); //пока не переместимся в новую точку или шаг поиска станет малым
                #endregion
            
            // поиск по образцу
             Sample(x);
             Research(x);

                #region Поиск по образцу
                //for (int i = 0; i < 2; i++)
                //{
                //    x_new[i] = x[i] + lambda * (x[i] - x_prev[i]);
                //}

                //if (Func(x_new[0], x_new[1]) < Func(x[0], x[1])) // переходим на новую точку
                //{
                //    for (int j = 0; j < 2; j++)
                //    {
                //        x_prev[j] = x[j];
                //        x[j] = x_new[j];
                //    }
                //}
                #endregion

            }
            while (Math.Abs(h[1]) > eps);


          Xopt_TB.Text = $"({Math.Round(x[0], 6)}; {Math.Round(x[1], 6)})"; 
          Yopt_TB.Text = $"{Math.Round(Func(x[0], x[1]),6)}";                 
          Draw(x[0], x[1]);
        }

        // рисуем линии уровня и показываем точку минимума
        private void Draw(double Xopt, double Yopt)
        {
            bmp = new Bitmap(600, 400);
            Graphics gr = Graphics.FromImage(bmp);

            // рисуем координатные оси
            gr.DrawLine(Pens.Black, 300, 0, 300, 400);
            gr.DrawLine(Pens.Black, 0, 200, 600, 200);

            // наносим насечки
            for (int x = 0; x < 600; x += 20)
                gr.DrawLine(Pens.Black, x, 198, x, 202);

            for (int y = 0; y < 400; y += 20)
                gr.DrawLine(Pens.Black, 298, y, 302, y);

            // рисуем сами линии
            for (int x = 0; x < 600; x++)
            for (int y = 0; y < 400; y++)
            {
                double z = Func((x - 300) / 20.0, (200 - y) / 20.0);

                if (Math.Abs(z - Math.Floor(z)) < 0.1)
                    bmp.SetPixel(x, y, Color.MediumSlateBlue);
            }

            
            // отмечаем точку минимума
            gr.DrawEllipse(new Pen(Color.Firebrick, 3f),
                (int)Math.Floor(Xopt) * 20 + 300 + 6, 200 - (int)Yopt * 20 - 5, 3, 3);
            pnImg.Invalidate();
        }

        private void clc_Button_Click(object sender, EventArgs e)
        {
            Work();
        }

        private void pnImg_Paint(object sender, PaintEventArgs e)
        {
            pnImg.CreateGraphics().DrawImage(bmp, 0, 0);
        }
    }
}
