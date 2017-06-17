using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kursach_MO.UserControls
{
   using static Console;

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
                //f = x * x + y * y;
                f = 10*(x*x)  +10*x*y+3*y*y;
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
            
        }

        Point ResearchInKoord(Point point, string nameCord, double step)
        {
            Point nextPoint = new Point(); //точка для xk+1

            if (String.Equals(nameCord, "X")) //если идем по координате Х
            {
                nextPoint.x = point.x + step; // пытаемся сделать шаг в направлении h[i] по оси Х
                nextPoint.y = point.y; // координата y не меняется
                
            }

            else // иначе идем по координате Y
            {
                nextPoint.y = point.y + step; // пытаемся сделать шаг в направлении h[i] по оси Х
                nextPoint.x = point.x; // координата х не меняется
             
            }

            if (Func(nextPoint) > Func(point)) // если шаг в выбранном направлении был неудачным
            {
                
                if (String.Equals(nameCord, "X")) //если идем по координате Х
                {
                    nextPoint.x = point.x - step; //снова пытаемся сделать шаг в направлении -h[i] по оси Х
                    nextPoint.y = point.y; // координата y не меняется
               
                }
                else // иначе идем по координате Y
                {
                    nextPoint.y = point.y - step; // снова пытаемся сделать шаг в направлении -h[i] по оси Х
                    nextPoint.x = point.x; // координата х не меняется
                }

              
                //if (Func(nextPoint) < Func(point)) // 
                //{
                //    point = nextPoint;
                //}
            }
            point = nextPoint;
            WriteLine($"Получили точку ({point.x};{point.y})");
            return point;
        }

   
        Point Sample(Point prevPoint, Point currentPoint) //шаг по образцу
        {
            Point Xp=new Point();
            int lambda = 2; //ускоряющий коэффициент поиска по образцу

            Xp.x = currentPoint.x + lambda * (currentPoint.x - prevPoint.x);
            Xp.y= currentPoint.y + lambda * (currentPoint.y - prevPoint.y);

            return Xp;
        }

       
        private void Work()
        {
           int alpha = 2; //коэффициент уменьшения шага
          

            double Step = Convert.ToDouble(dx_TB.Text.Replace(".",","));  //начальный шаг
            double eps = Convert.ToDouble(E_TB.Text.Replace(".", ",")); //точность поиска
            
           
            Point prevPoint = new Point();
            Point nextPoint = new Point();
            Point currentPoint = new Point();


            currentPoint.x= Double.Parse(x0_TB.Text.Replace(".", ","));// задали начальеую точку xk=x0 по координате х
            currentPoint.y= Double.Parse(y0_TB.Text.Replace(".", ","));// задали начальную точку xk=x0 по координате y

            //Отладка
            WriteLine($"Определяем значение функции в начальной точке ({currentPoint.x};{currentPoint.y}) ={Func(currentPoint)}");
            //
            nextPoint = currentPoint;

           do
            {
                //Исследующий поиск
                nextPoint = ResearchInKoord(nextPoint, "X", Step);
                nextPoint = ResearchInKoord(nextPoint, "Y", Step);

                //Отладка
                WriteLine($"Точка полученная в результате исслед. поиска= ({nextPoint.x};{nextPoint.y})");
                //

                while (Func(currentPoint) > Func(nextPoint))
                {
                    prevPoint = currentPoint;
                    currentPoint = nextPoint;

                    //ШАГ ПО ОБРАЗЦУ (написать функцию)
                    nextPoint=Sample(prevPoint,currentPoint);
                    WriteLine($"Точка полученная в результате шага по образцу= ({nextPoint.x};{nextPoint.y})");
                    //Исследующий поиск
                    nextPoint = ResearchInKoord(nextPoint, "X", Step);
                    nextPoint = ResearchInKoord(nextPoint, "Y", Step);
                }
                
                Step = Step / alpha;
            
            } while (Math.Abs(Step) > eps);

             Xopt_TB.Text = $"({Math.Round(currentPoint.x, 6)}; {Math.Round(currentPoint.y, 6)})"; 
         //   Yopt_TB.Text = $"{Math.Round(Func(x[0], x[1]),6)}";   


            //   do
            //  {
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

            // }
            // while (Math.Abs(h[1]) > eps);


            // Xopt_TB.Text = $"({Math.Round(x[0], 6)}; {Math.Round(x[1], 6)})"; 
            // Yopt_TB.Text = $"{Math.Round(Func(x[0], x[1]),6)}";                 
            // Draw(x[0], x[1]);
        }

        // рисуем линии уровня и показываем точку минимума
        //private void Draw(double Xopt, double Yopt)
        //{
        //    bmp = new Bitmap(600, 400);
        //    Graphics gr = Graphics.FromImage(bmp);

        //    // рисуем координатные оси
        //    gr.DrawLine(Pens.Black, 300, 0, 300, 400);
        //    gr.DrawLine(Pens.Black, 0, 200, 600, 200);

        //    // наносим насечки
        //    for (int x = 0; x < 600; x += 20)
        //        gr.DrawLine(Pens.Black, x, 198, x, 202);

        //    for (int y = 0; y < 400; y += 20)
        //        gr.DrawLine(Pens.Black, 298, y, 302, y);

        //    // рисуем сами линии
        //    for (int x = 0; x < 600; x++)
        //    for (int y = 0; y < 400; y++)
        //    {
        //        double z = Func((x - 300) / 20.0, (200 - y) / 20.0);

        //        if (Math.Abs(z - Math.Floor(z)) < 0.1)
        //            bmp.SetPixel(x, y, Color.MediumSlateBlue);
        //    }


        //    // отмечаем точку минимума
        //    gr.DrawEllipse(new Pen(Color.Firebrick, 3f),
        //        (int)Math.Floor(Xopt) * 20 + 300 + 6, 200 - (int)Yopt * 20 - 5, 3, 3);
        //    pnImg.Invalidate();
        //}

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
