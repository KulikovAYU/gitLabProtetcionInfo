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

        class Point
        {
            public double F { get; set; }
            public double x { get; set; }

            public double y { get; set; }
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
        }

     
        Point ResearchInKoord(Point point, double step) //исследующий поиск
        {
         Point nextPoint=new Point();

        //ШАГАЕМ ПО ОСИ Х

            nextPoint.x = point.x -step;

            if (Func(nextPoint)>=Func(point))
            {
                nextPoint.x = point.x + step;
                if ((Func(nextPoint) >= Func(point)))
                {
                    //пробуем поменять по у

                    nextPoint.y = point.y - step;

                    if (Func(nextPoint)>=Func(point))
                    {
                        nextPoint.y = point.y + step;

                        if (Func(nextPoint) < Func(point))
                        {
                            point = nextPoint;

                        }
                        
                    }
                    else
                    {
                        point = nextPoint;
                    }
                }
                else
                {
                    point = nextPoint;
                }
            }
            else
            {
                point = nextPoint;
               
                nextPoint.y = point.y - step;

                if (Func(nextPoint)>=Func(point ))
                {
                    nextPoint.y = point.y + step;

                    if (Func(nextPoint) < Func(point))
                    {
                        point = nextPoint;
                    }

                }
                else
                {
                    point = nextPoint;
                }
            }
            return point;
        }

   
        Point Sample(Point prevPoint, Point currentPoint) //шаг по образцу
        {
            Point Xp=new Point();
            int lambda = 2; //ускоряющий коэффициент поиска по образцу


            Xp.x = currentPoint.x + lambda * (currentPoint.x - prevPoint.x);
            Xp.y = currentPoint.y + lambda * (currentPoint.y - prevPoint.y);
            
            return Xp;
        }

       
        private void Work()
        {
            Point prevPoint = new Point();    // =xk-1
            Point nextPoint = new Point();   // =xk+1;
            Point currentPoint = new Point(); // =xk;


            currentPoint.x= Double.Parse(x0_TB.Text.Replace(".", ","));// задали начальеую точку xk=x0 по координате х
            currentPoint.y= Double.Parse(y0_TB.Text.Replace(".", ","));// задали начальную точку xk=x0 по координате y
            double Step = Convert.ToDouble(dx_TB.Text.Replace(".", ","));  //начальный шаг
            double eps = Convert.ToDouble(E_TB.Text.Replace(".", ",")); //точность поиска
            int alpha = 2; //коэффициент уменьшения шага

         
            
          
            do
            {
               nextPoint = ResearchInKoord(currentPoint,Step);//Исследующий поиск

                while (Func(currentPoint) > Func(nextPoint))
                {
                   prevPoint = currentPoint;
                   currentPoint = nextPoint;
                    
                   nextPoint = Sample(prevPoint, currentPoint);//ШАГ ПО ОБРАЗЦУ 
                   nextPoint = ResearchInKoord(nextPoint,Step);//Исследующий поиск
                   
                }

            Step = Step / alpha;
            } while (Math.Abs(Step) > eps);

             Xopt_TB.Text = $"({Math.Round(currentPoint.x, 6)}; {Math.Round(currentPoint.y, 6)})"; 
   
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
