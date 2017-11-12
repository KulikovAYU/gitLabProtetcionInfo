using System;

namespace WindowsFormsApp1
{
    class Gammirovanie
    {
        public Gammirovanie() { }

        public Gammirovanie(Lab1 form) 
        {
            m_form = form;
            space = Convert.ToInt32(' '); // инициализация пробела
            count = 0;
            isBegin = true;
        }

        int count;
        bool isBegin;
        private Lab1 m_form;
        private string[] substrings;
      

        private int[] theFirstLine;
        private int[] theSecondLine;

        private int[] deshifr;

        private int space;
        private int gamma;

        //Функция парсит две входные строки в зависимости от метки isFirstString - т.е. метки первой строки
        public void ParcingString(ref string hexStrings, bool isFirstString = true)
        {
            Char delimeter = ' '; // разделитель
            substrings = hexStrings.Split(delimeter);

            int j = 0;

            foreach (string hs in substrings)
            {
                j++;
            }

            if (isFirstString)
            {
                theFirstLine = new int[j];
                deshifr = new int[j];
            }
            else
            {
                theSecondLine = new int[j];
                deshifr = new int[j];
            }
         
            int k = 0;

            foreach (string hs in substrings)
            {
                if (isFirstString)
                {
                    theFirstLine[k] = Convert.ToInt32(hs, 16); // конвертируем из 16 ричной в десятичную
                }
                else
                {
                    theSecondLine[k] = Convert.ToInt32(hs, 16); // конвертируем из 16 ричной в десятичную
                }
                k++;
            }
        }


      // функция дешифрования вызывается рекурсивно до тех пор, пока не будет конец первой строки
        public void Find()
        {

            while (count < theFirstLine.Length)
            {
                if (isBegin)
                {
                    gamma = theSecondLine[0] ^ space;
                    deshifr[0] = theFirstLine[0] ^ gamma;
                }
                else
                {
                    gamma = theSecondLine[count] ^ deshifr[count - 1];
                    deshifr[count] = theFirstLine[count] ^ gamma;
                }
                isBegin = false;

                //Console.Write((Convert.ToChar(deshifr[count])).ToString()); // отладочная консольная строка
                m_form.RichTB1.Text += (Convert.ToChar(deshifr[count])).ToString();
              
                count++;

                Find(); // рекурсивный вызов функции Find
            }
        }
    }
 
}
