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
    //using static Console;
    public partial class Simplex1 : UserControl
    {
        
      public  class Point
        {
            public double x1 { get; set; } 
            public double x2 { get; set; }
            public double F { get; set; }

            int i;
            public int Sh
            {
                get {return i;}
                set {i=value;}
            }

        }

        public Simplex1()
        {
            InitializeComponent();
        }

        private double Func(Point p)
        {
            double x = p.x1;
            double y = p.x2;
            double f = 0;
            if (radioButton1.Checked)
            {
                  f = x * x + y * y;
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


        void NewSimplex(ref Point[] point ,double alpha)
        {
            int N = 2;
            double delta1 = ((Math.Sqrt(N + 1) + N - 1) / (N * Math.Sqrt(2))) * alpha;
            double delta2 = ((Math.Sqrt(N + 1)  - 1) / (N * Math.Sqrt(2))) * alpha;

            Console.WriteLine($"delta1: ({delta1}; delta2:{delta2})");

            point[1].x1 = point[0].x1 + delta2;
            point[1].x2 = point[0].x2 + delta1;


            point[2].x1 = point[0].x1 + delta1;
            point[2].x2 = point[0].x2 + delta2;

            for (int i = 0; i < point.Length; i++)
            {
                Console.WriteLine($"Новая точка {i}: ({point[i].x1};{point[i].x2})");
            }
           
           
        }

        void RepeatPoint(ref Point[] point, ref double alpha)
        {
            int N = 2;//размерность задачи
            double M = Math.Round((1.65 * N) + 0.05 * N * N);

            for (int i = 0; i < point.Length; i++)
            {
                if (point[i].Sh >= M)
                {
                    Console.WriteLine($"Точка с координатами {point[i].x1};{point[i].x2} не исключается на протяжении {point[i].Sh} итераций");
                    alpha *= 0.5;
                    Console.WriteLine($"alpha={alpha}");
                    Array.Sort(point, (x, y) => x.F.CompareTo(y.F));
                    NewSimplex(ref point, alpha);
                    point[i].Sh = 0;
                }
                else
                {
                    point[i].Sh++;
                }
            }
        }

       
        private void clc_Button_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            Point[] point = new Point[3];
            double eps;//точность
            double alpha;// - рёбра симплекса имеют единичную длину
            int n=2;// остальные точки
            
          

            for (int i = 0; i < point.Length; i++)
            {
                point[i] = new Point();
                point[i].Sh = 0;
            }

            point[0].x1 = Convert.ToDouble(x0_TB.Text.Replace(".",","));
            point[0].x2 = Convert.ToDouble(y0_TB.Text.Replace(".", ","));
            alpha = Convert.ToDouble(alphaTB.Text.Replace(".", ","));
            eps = Convert.ToDouble(E_TB.Text.Replace(".", ",")); 

            Point xc=new Point();// центр тяжести
            Point xk = new Point();// новая точка

            int it = 0;

            //1. Построить новый симплекс в пространстве незвасисимых переменных
            NewSimplex(ref point, alpha);

            while (alpha>=eps)
           {
               it++;
               textBox3.Text = textBox3.Text + string.Format("{0}\t", it);
                //2. Находим значение функции в вершинах симплекса
                for (int i = 0; i < point.Length; i++)
                {
                    point[i].F = Func(point[i]);
                }

                //3. Находим точку в которой функция имеет наибольшее значение
                Array.Sort(point, (x, y) => x.F.CompareTo(y.F));
              
                //4. Находим центры тяжести всех остальных точек за исключением xh

                xc.x1 = (1 / Convert.ToDouble(n)) * (point[0].x1 + point[1].x1);
                xc.x2 = (1 / Convert.ToDouble(n)) * (point[0].x2 + point[1].x2);

                //5.Спроецировать вершину xh
                xk.x1 = 2 * xc.x1 - point[2].x1;
                xk.x2 = 2 * xc.x2 - point[2].x2;

                point[2].x1 = xk.x1;
                point[2].x2= xk.x2;
                point[2].Sh = 0;

               
               for (int i = 0; i < point.Length; i++)
               {
                   textBox3.Text = textBox3.Text + string.Format("(");
                   textBox3.Text = textBox3.Text + string.Format("{0:f6};", point[i].x1);
                   textBox3.Text = textBox3.Text + string.Format("{0:f6}", point[i].x2);
                   textBox3.Text = textBox3.Text + string.Format(")\t");
               }
                 textBox3.Text = textBox3.Text+ Environment.NewLine + string.Format("F({1:f6};{2:f6}) ={0:f6};\t", point[0].F,point[0].x1,point[0].x2);

                //6. заменяем худшую точку на xk
                RepeatPoint(ref point, ref alpha);
               textBox3.Text += Environment.NewLine;
            }

            MessageBox.Show(
                $"Расчет закончен. Точка оптимума ({Math.Round(point[0].x1,5)};{Math.Round(point[0].x2, 5)}). Значение функции F={Math.Round(point[0].F, 5)}");
            optimumTB.Text = "("+Math.Round(point[0].x1, 5).ToString().ToString()+";" + Math.Round(point[0].x2, 5).ToString()+")";

            //Console.WriteLine( "Точка оптимума =({0:f6};{1:f6})",point[0].x1,point[0].x2);
        }
    }
}
