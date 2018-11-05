using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingGraph
{

        public class algorit
        {

            public static readonly algorit alg;

            static algorit()
            {
                if (alg == null)
                {
                    alg = new algorit();
                }
            }

            public static algorit GetInstance
        {
                get { return alg; }
            }

            public int[,] mas;
        // mas[i][j] - максимальная величина потока, способная течь по ребру (i,j) or матрица хранящая граф

        public int len; //количество вершин графа
        public int lin; //количество ребер графа
        public string al = "";
            public int type = 3; //количество ребер графа


            public void create_mas(int n, int n1, int n3)
            {
                if (n3==3) mas = new int[n1, 2];
            else mas = new int[n, n1];

                len = n;
                lin = n1;
                type = n3;
            }


        public string Bulid(int[,] massy, int leny)
        {

            string result = "";
            int[,] masCopy = new int[leny, leny];
            for (int i = 0; i < leny; i++)
            {
                for (int j = 0; j < leny; j++)
                {
                    masCopy[i, j] = massy[i, j];
                }
            }
            string[] a1 = RetRow(massy, 1);
            result = result + al;
            return result;

        }



        public virtual string[] RetRow(int[,] Arr, int j) //возращает строку с индексом j из массива Arr
        {
            if (type == 3)
            {
                string[] mas1 = new string[2];
                for (int i = 0; i < 2; i++)
                {
                    mas1[i] = Arr[j, i].ToString();
                }

                return mas1;
            }
            else
            {
                string[] mas1 = new string[lin];
                for (int i = 0; i < lin; i++)
                {
                    mas1[i] = Arr[j, i].ToString();
                }

                return mas1;
            }

        }

        public virtual int CountUnits(int[,] Arr, int j) //подсчет единиц 
        {
            if (type == 3)
            {
                int count = 0;
                for (int i = 0; i < 2; i++)
                {
                    if (Arr[j, i].ToString().Equals("1"))
                        count++;
                }
                string[] mas1 = new string[2];
                mas1 = RetRow(Arr, j);
                if (count <= mas1.Length)
                    return count;
                else return 0;
            }
            else
            {
                int count = 0;
                for (int i = 0; i < lin; i++)
                {
                    if (Arr[j, i].ToString().Equals("1"))
                        count++;
                }
                string[] mas1 = new string[lin];
                mas1 = RetRow(Arr, j);

                if (count <= mas1.Length)
                    return count;
                else return 0;
            }

        }


        public virtual bool Check(int[,] Arr, int number)
        {
            int result = 0;
            int temp = 0;
            int lim = Arr.GetLength(0);
            int lim2= Arr.GetLength(1);

            for (int i = 0; i < lim2; i++)
            {
                int[,] mass = new int[1,lim];
                for (int j=0; j < lim; j++)
                {
                    mass[0, j] = Arr[j, i];
                }
                lin = mass.Length;
                type = 2;
                temp = CountUnits(mass, 0);
                if (temp == 2 || temp ==0)
                    result += temp;
                else return false;
            }

            if (result == number) return true;
            else return false;
        }























        public string Вulid(int [,] massy, int leny)
        {
            if (leny == 1) al = "1111";   if (leny == 2)  al = "1010"; if (leny == 3) al = "";


            string result = "";
                int[,] masCopy = new int[leny, leny];
                for (int i = 0; i < leny; i++)
            {
                for (int j = 0; j < leny; j++)
                {
                    masCopy[i, j] = massy[i, j];
                }            
            }
                string[] a1 = RetRow(massy, 1);
            result = result + al;
            return result;

        }



            public virtual string[] RеtRow(int[,] Arr, int j) //возращает строку с индексом j из массива Arr
            {
            if (type == 3)
            {
                string[] mas1 = new string[2];
                for (int i = 0; i < 2; i++)
                {
                    mas1[i] = Arr[j, i].ToString();
                }
                
                return mas1;
            }
            else
            {
                string[] mas1 = new string[lin];
                for (int i = 0; i < lin; i++)
                {
                    mas1[i] = Arr[j, i].ToString();
                }
               
                return mas1;
            }

            }











            public void DoLinks(System.Windows.Forms.RichTextBox TextBox) 
            {
                TextBox.AppendText(" Список ребер графа:\n");
                TextBox.AppendText("\n");

            if (type == 1) // если по матрице смежности
            {
                int[,] masCopy = new int[len, len];
                for (int i = 0; i < len; i++)
                    for (int j = 0; j < len; j++)
                        masCopy[i, j] = mas[i, j];

                for (int i = 0; i < len; i++)
                    for (int j = 0; j < len; j++)
                    {
                        if (masCopy[i, j] != 0)
                        {
                            TextBox.AppendText("Вершина " + (i+1).ToString() + " - " + "Вершина " + (j+1).ToString()+ "\n");
                            masCopy[i, j] = 0;
                            masCopy[j, i] = 0;
                        }
                    }       
            }
            if (type == 2) // если по матрице инцидентности 
            {
                int[,] masCopy = new int[len, lin];
                for (int i = 0; i < len; i++)
                    for (int j = 0; j < lin; j++)
                        masCopy[i, j] = mas[i, j];

                for (int i = 0; i < lin; i++)
                {
                    int flag = 0;
                    for (int j = 0; j < len; j++)
                    {

                        if (masCopy[j, i] != 0 && flag == 0)
                        {
                            TextBox.AppendText("Вершина " + (j + 1).ToString() + " - ");
                            flag = 1;
                        }
                        else
                        {
                            if (masCopy[j, i] != 0 && flag == 1)
                            {
                                TextBox.AppendText("Вершина " + (j + 1).ToString() + "\n");
                            }
                        }
                    }
                }
            }

            if (type == 3) //если по списку ребер 
            {
                for (int i = 0; i < lin; i++)
                   TextBox.AppendText("Вершина " + mas[i,0] + " - " + "Вершина " + mas[i, 1] +"\n");

            }

            }

        public void DoSmez(System.Windows.Forms.RichTextBox TextBox) 
        {
            TextBox.AppendText(" Матрица смежности графа:\n");

            if (type == 1) // если по матрице смежности
            {
                TextBox.AppendText("\n");
                TextBox.AppendText("     ");
                for (int i = 0; i < len; i++) TextBox.AppendText((i+1) + " ");
                TextBox.AppendText("\n");
                  for (int i = 0; i < len; i++)
                {
                    TextBox.AppendText(" "+ (i+1) +" ");
                    for (int j = 0; j < len; j++)
                    {
                     TextBox.AppendText(" " + mas[i, j]);  
                    }
                    TextBox.AppendText("\n");
                }
            }
            if (type == 2) // если по матрице инцидентности 
            {
                int[,] masCopy = new int[len, len];
                for (int i = 0; i < len; i++)
                    for (int j = 0; j < len; j++)
                        masCopy[i, j] = 0;
                for (int i = 0; i < lin; i++)
                {
                    int flag = 0;
                    int f = -1;
                    int f1 = -1;
                    for (int j = 0; j < len; j++)
                    {

                            if (mas[j, i] != 0 && flag == 0)
                            {
                                f = j;
                                flag = 1;
                            }
                            else
                            {
                                if (mas[j, i] != 0 && flag == 1)
                                {
                                f1 = j;
                                }
                            }
                        
                    }
                    if (f != -1 && f1 != -1) masCopy[f, f1] = 1;                   
                }



                TextBox.AppendText("\n");
                TextBox.AppendText("     ");
                for (int i = 0; i < len; i++) TextBox.AppendText((i + 1) + " ");
                TextBox.AppendText("\n");
                for (int i = 0; i < len; i++)
                {
                    TextBox.AppendText(" " + (i + 1) + " ");
                    for (int j = 0; j < len; j++)
                    {
                        TextBox.AppendText(" " + masCopy[i, j]);
                    }
                    TextBox.AppendText("\n");
                }

            }

            if (type == 3) //если по списку ребер 
            {
                int[,] masCopy = new int[len, len];
                for (int i = 0; i < len; i++)
                    for (int j = 0; j < len; j++)
                        masCopy[i, j] = 0;
                for (int i = 0; i < lin; i++)
                {
                    masCopy[mas[i, 0] -1 , mas[i, 1] -1] = 1;
                    masCopy[mas[i, 1] -1 , mas[i, 0] -1] = 1;
                }

                TextBox.AppendText("\n");
                TextBox.AppendText("     ");
                for (int i = 0; i < len; i++) TextBox.AppendText((i + 1) + " ");
                TextBox.AppendText("\n");
                for (int i = 0; i < len; i++)
                {
                    TextBox.AppendText(" " + (i + 1) + " ");
                    for (int j = 0; j < len; j++)
                    {
                        TextBox.AppendText(" " + masCopy[i, j]);
                    }
                    TextBox.AppendText("\n");
                }
            }
        }


           public void DoInt(System.Windows.Forms.RichTextBox TextBox) 
            {
              TextBox.AppendText(" Матрица инцидентности графа:\n");
            if (type == 1) // если по матрице смежности
            {
                int count = 0;
                int flag = 0;
                for (int i = 0; i < len; i++)
                    for (int j = 0; j < len; j++)
                        if (mas[i, j] != 0 && i!=j )
                        {
                            count++;
                            mas[j, i] = 0;
                        }

                        int[,] masCopy = new int[len, count];
                for (int i = 0; i < len; i++)
                    for (int j = 0; j < count; j++)
                        masCopy[i, j] = 0;


                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < lin; j++)
                    {

                        if (mas[i, j] != 0 && i!=j)
                        {
                            mas[i, j] = 0;
                            mas[j, i] = 0;
                            masCopy[i, flag] = 1;
                            masCopy[j, flag] = 1;
                            flag++;
                        }    
                    }
                }


                TextBox.AppendText("\n");
                TextBox.AppendText("     ");
                for (int i = 0; i < count; i++) TextBox.AppendText((i + 1) + " ");
                TextBox.AppendText("\n");
                for (int i = 0; i < len; i++)
                {
                    TextBox.AppendText(" " + (i + 1) + " ");
                    for (int j = 0; j < count; j++)
                    {
                        TextBox.AppendText(" " + masCopy[i, j]);
                    }
                    TextBox.AppendText("\n");
                }
            }
            if (type == 2) // если по матрице инцидентности 
            {

                TextBox.AppendText("\n");
                TextBox.AppendText("     ");
                for (int i = 0; i < lin; i++) TextBox.AppendText((i + 1) + " ");
                TextBox.AppendText("\n");
                for (int i = 0; i < len; i++)
                {
                    TextBox.AppendText(" " + (i + 1) + " ");
                    for (int j = 0; j < lin; j++)
                    {
                        TextBox.AppendText(" " + mas[i, j]);
                    }
                    TextBox.AppendText("\n");
                }

            }
            if (type == 3) //если по списку ребер 
            {
                int[,] masCopy = new int[len, lin];
                for (int i = 0; i < len; i++)
                    for (int j = 0; j < lin; j++)
                        masCopy[i, j] = 0;

                for (int i = 0; i < lin; i++)
                {
                    masCopy[mas[i, 0]-1, i] = 1;
                    masCopy[mas[i, 1]-1, i] = 1;
                }
                   




                    TextBox.AppendText("\n");
                TextBox.AppendText("     ");
                for (int i = 0; i < lin; i++) TextBox.AppendText((i + 1) + " ");
                TextBox.AppendText("\n");
                for (int i = 0; i < len; i++)
                {
                    TextBox.AppendText(" " + (i + 1) + " ");
                    for (int j = 0; j < lin; j++)
                    {
                        TextBox.AppendText(" " + masCopy[i, j]);
                    }
                    TextBox.AppendText("\n");
                }
            }

        }

     

        }

}
