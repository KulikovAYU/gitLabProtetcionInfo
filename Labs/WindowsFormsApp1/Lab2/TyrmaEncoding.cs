using System;
using System.Collections;

namespace WindowsFormsApp1
{
    // данная часть класса  парсит закодированную строку и раскодирует её, образовав выходой файл

    // Последовательность:
    // 1. Прочитать файл, разбив его по 3 символа. Если символ содержит 000, то это пробел (его сразу записываем в выходную строку)
    // Если остаток от деления на 3 !=0, то были добавлены пробелы в конец строки. Их отбросим
    // 2. Сформируем числа вида 001 110, где первые три бита - номер строки, а вторые - номер столбца
    // 3. Сформируем byte[] bytes = new byte[sizeof(int)]. Затем скопируем BitArray в bytes . Получим число 45, где 4- номер строки, 5- номер столбца
    // 4. Из исходного алфавита извлечем букву и запишем её в выходной файл.
    partial class Tyrma
    {
        int codeStrCnt;
        string outStr;
        Position Pos;
        bool isWordready;
       
        void ParceCodeFile(ref char codeStr)
        {
            codeStrCnt++;

            outStr += Convert.ToString(codeStr);

            if (codeStrCnt % 3 == 0)
             FindSpacesInCodeStr(ref outStr);
        }

        void FindSpacesInCodeStr (ref string strWhtSpace) // Функция ищет пробелы в строчке
        {
            codeStrCnt = 0;

            isWordready = false;

            if (String.Equals(strWhtSpace, "000"))
            {
                OutputEncodeStrInFile += " ";
            }
            else
            {
                byte[] bytes = new byte[sizeof(int)];

                switch (Pos)
                {
                   case Position.eFirst:

                        m_symbolArray[0] = new BitArray(ConvertToBool(ref strWhtSpace));
                        m_symbolArray[0].Length = 3;
                        m_symbolArray[0].CopyTo(bytes, 0);
                        m_nNumberStr = BitConverter.ToInt32(bytes, 0) - 1; // т.к. при кодировании добавляли единицу
                        Pos = Position.eSecond;
                        break;

                    case Position.eSecond:
                        m_symbolArray[1] = new BitArray(ConvertToBool(ref strWhtSpace));
                        m_symbolArray[1].Length = 3;
                        m_symbolArray[1].CopyTo(bytes, 0);
                        m_nNumberStolb = BitConverter.ToInt32(bytes, 0) - 1;// т.к. при кодировании добавляли единицу
                        Pos = Position.eFirst;
                        isWordready = true; // флаг готовности слова (т.е. номер строки и номер столбца определен)
                        break;
                }
            }

            outStr = null;

            if (isWordready)
                OutputEncodeStrInFile += FindSymbolInAlpha(m_nNumberStr, m_nNumberStolb);
        }

        bool[] ConvertToBool(ref string str)
        {
            bool[] values = new bool[3];
            int count = 0;
            foreach (char st in str)
            {
                values[count] = (st == '0') ? false : true;
                count++;
            }
            return values;
        }

        string FindSymbolInAlpha(int nNumberStr, int nNumberStolb)
        {
            string letter = null;
            letter = PrisonAphabet[nNumberStr][nNumberStolb];
            return letter;
        }
    }
}
