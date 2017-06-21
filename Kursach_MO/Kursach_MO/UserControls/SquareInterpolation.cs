using System;
using System.Windows.Forms;

namespace Kursach_MO.UserControls
{
   

    public partial class SquareInterpolation : UserControl
    {

        
        private double x1, x2, x3, dx, E,Ex;
        private int i;
       private double _x,_F;//для формулы квадратичной аппроксимации: точка и значение функции в точке
        
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
            if (radioButton5.Checked)
            {
                f = 2 * x * x + 16 / x;
            }

            return f;
        }

        #region Пузырьковая сортировка

        // Метод перестановки элементов
        static void Swap(Point[] items, int left, int right)
        {
            if (left != right)
            {
                double temp = items[left].F;
                items[left].F = items[right].F;
                items[right].F = temp;

                temp = items[left].x;
                items[left].x = items[right].x;
                items[right].x = temp;
            }
        }
        // Метод реализует сортировку пузырьком 
      //public static void BubbleSort(ref Point[] items)
      //  {
      //      bool swapped;

      //      do
      //      {
      //          swapped = false;

      //          for (int i = 1; i < items.Length; i++)
      //          {
      //              if ((items[i - 1].F).CompareTo(items[i].F) > 0)
      //              {
      //                  Swap(items, i - 1, i);

      //                  swapped = true;
      //              }


      //          }
      //      }

      //      while (swapped != false);
      //  }

        #endregion

        struct Point
        {
            public double x { get; set; }
            public double F { get; set; }
        }

        void SquareInterpoletion()
        {
        

            Point[] points=new Point[3];

            points[0].x = x1;
            x2= x1 + dx;
            points[1].x = x2;
            points[0].F = Function(x1);
            points[1].F = Function(x2);
            
            if (points[1].F < points[0].F)
            {
                x3 = x2 + dx;
            }
            else
            {
                x3 = points[0].x - dx;
            }
            points[2].x = x3;

            points[2].F = Function(points[2].x);

            //for (int i = 0; i < f.Length; i++)
            //{
            //    Console.WriteLine($"f[{i}].F={f[i].F}");
            //    Console.WriteLine($"x[{i}].x={f[i].x}");
            //}

           // int iter=0; (отладка)

            do
            {
                //iter++; (отладка)
                //Console.WriteLine($"итерация N{iter}"); (отладка)

                #region Формула квадратичной аппроксимации (точка _x и значение _F=F(_x))

                double a1 = (points[1].F - points[0].F) / (x2 - x1);
                double a2 = 1 / (points[2].x - points[1].x) * ((points[2].F - points[0].F) / (x3 - x1) - a1);
                _x = (x1 + x2) / 2 - a1 / (2 * a2);
                _F = Function(_x);
                //Console.WriteLine($"x*={_x}"); //(отладка)
                //Console.WriteLine($"F(x*)={_F}");// (отладка)
                #endregion

                Array.Sort(points,( x, y)=>x.F.CompareTo(y.F));

                 //BubbleSort(ref f);


                //for (int i = 0; i < points.Length; i++) //(отладка)
                //{


                //    Console.WriteLine($"f[{i}].F={points[i].F}"); //(отладка)
                //   Console.WriteLine($"x[{i}].x={points[i].x}"); //(отладка)
                //}

                points[2].F = _F;
                points[2].x = _x;

               
                Console.WriteLine();

            } while (Math.Abs(points[0].F - _F) > E && Math.Abs(points[0].x - _x) > Ex);

        }

        public SquareInterpolation()
        {
            InitializeComponent();
        }

        private void clc_Button_Click(object sender, EventArgs e)
        {
            i = 0;
            if (x1_TB.Text == "")
            {
                MessageBox.Show("введите x1");
                x1_TB.Focus();
            }
            if (dx_TB.Text == "")
            {
                MessageBox.Show("введите Δx");
                dx_TB.Focus();
            }
            if (E_TB.Text == "")
            {
                MessageBox.Show("введите Ԑ");
                E_TB.Focus();
            }
            if (Ex_TB.Text == "")
            {
                MessageBox.Show("введите Ԑx");
                Ex_TB.Focus();
            }

            x1 = Convert.ToDouble(x1_TB.Text.Replace(".", ","));
            dx = Convert.ToDouble(dx_TB.Text.Replace(".", ","));
            E = Convert.ToDouble(E_TB.Text.Replace(".", ","));
            Ex = Convert.ToDouble(Ex_TB.Text.Replace(".", ","));

            SquareInterpoletion();

            x0_TB.Text = Convert.ToString(Math.Round(_x, 6));
            f0_TB.Text = Convert.ToString(Math.Round(_F, 6));
            i_TB.Text= Convert.ToString(i);

            
            //WriteLine($"_x={_x}"); (отладка)
            //Console.ReadKey(); (отладка)
        }

    }
}
