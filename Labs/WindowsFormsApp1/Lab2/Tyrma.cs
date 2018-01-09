using System.Windows.Forms;
using System;
using System.IO;
using System.Collections;

namespace WindowsFormsApp1
{
    partial class Tyrma
    {
        private Lab2 m_form;
        private DirectoryInfo m_dir;
        private string m_bufNameFile;
        private char m_symbol;
        private int m_nNumberStr;
        private int m_nNumberStolb;
        private BitArray m_space;
        private BitArray[] m_symbolArray;
        private StreamWriter m_writer;
        private delegate void Print(Action i);
        enum Action { eCoding, eUncoding }
        enum Position { eFirst, eSecond }

        private static string[][] PrisonAphabet = null;
        public static string OutputStrInFile { get; set; } // выходная срока всего массива битов
        public static string OutputEncodeStrInFile { get; set; } // выходная срока всего массива битов
        public Tyrma(Lab2 form)
        {
            InitializePrivateFields(); // инициализация нулями приватных полей
            InitAlphavit();// Инициализация алфавита
            m_form = form;
            m_dir = new DirectoryInfo(@"..\..\..");
            m_bufNameFile = m_dir.FullName.ToString() + "\\WindowsFormsApp1\\Lab2\\Files";
            m_symbolArray = new BitArray[2];
        }

        public static void InitAlphavit()
        {
            PrisonAphabet = new string[6][];
            PrisonAphabet[0] = new string[] { "а", "б", "в", "г", "д" };
            PrisonAphabet[1] = new string[] { "е", "ж", "з", "и", "к" };
            PrisonAphabet[2] = new string[] { "л", "м", "н", "о", "п" };
            PrisonAphabet[3] = new string[] { "р", "с", "т", "у", "ф" };
            PrisonAphabet[4] = new string[] { "х", "ц", "ч", "ш", "щ" };
            PrisonAphabet[5] = new string[] { "ы", "ь", "э", "ю", "я" };
        }

        public string GetPathName() { return m_bufNameFile; }

        void InitializePrivateFields()
        {
            m_dir = null;
            m_bufNameFile = null;
            m_symbol = ' ';
            OutputStrInFile = null;
            m_nNumberStr = 0;
            m_nNumberStolb = 0;
            m_space = null;
            m_symbolArray = null;
            m_writer = null;

            ////////////инициализация переменных для расшифрования///////////////
            codeStrCnt = 0;
            outStr = null;
            OutputEncodeStrInFile = null;
            isWordready = false;
            Pos = Position.eFirst;
        }

        private void LoadInputFile(Action eTypeOfAction)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            DialogResult result= new DialogResult();
            if (eTypeOfAction == Action.eCoding)
            {
                fileDlg.InitialDirectory = m_dir.FullName.ToString() + "\\WindowsFormsApp1\\Lab2\\Files";
                fileDlg.Filter = "txt files (*.txt)|*.txt";
                fileDlg.Title = "Выбор файла";
                fileDlg.RestoreDirectory = true;
                result = fileDlg.ShowDialog();
            }
           
            if (result == DialogResult.OK || eTypeOfAction == Action.eUncoding)
            {
                try
                {
                    FileStream file = null;

                    if (eTypeOfAction == Action.eCoding)
                    {
                        m_form.textBox1.Text = fileDlg.FileName;
                        file = new FileStream(fileDlg.FileName, FileMode.Open); //создаем файловый поток
                    }

                    if (eTypeOfAction == Action.eUncoding)
                    {
                        file = new FileStream(m_form.textBox2.Text, FileMode.Open); //создаем файловый поток
                    }

                    StreamReader fileReader = new StreamReader(file);  // создаем «потоковый читатель» и связываем его с файловым потоком 

                    //  m_inputString= fileReader.ReadToEnd();//считываем все данные с потока.Для приведения всего этого дела к нижнему регистру можно использовать функцию (ToLower())

                    while (!fileReader.EndOfStream) // посимвольно считываем текст из файла
                    {
                        m_symbol = (char)fileReader.Read();

                        if (eTypeOfAction == Action.eCoding)
                        {
                            m_symbol = Convert.ToChar(m_symbol.ToString().ToLower()); // преобразуем все буквы к нижнему регистру
                            FindSymbolPosition(ref m_symbol);
                        }

                        if (eTypeOfAction == Action.eUncoding)
                        {
                            // TODO: Добавить действия для раскодирования соообщения
                            ParceCodeFile(ref m_symbol);
                        }
                    }

                    if (eTypeOfAction == Action.eCoding)
                    {
                        CheckStrLenght();
                        m_writer.Write(OutputStrInFile);
                    }

                    if (eTypeOfAction == Action.eUncoding)
                    {
                        m_writer.Write(OutputEncodeStrInFile);
                        // TODO: Добавить действия для раскодирования соообщения
                    }

                    fileReader.Close();//закрываем поток
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: Нельзя прочитать фал с диска. Код ошибки: " + ex.Message);
                }
            }
        }

        private void FindSymbolPosition(ref char strFromFile) // функция ищет символы в алфавите
        {
            if (String.Equals(" ", strFromFile.ToString())) // если во входной строке затесался пробел
            {
                CreateBitArray(true);
            }
            else
            { // иначе бежим искать буквы
                
                for (int i = 0; i < PrisonAphabet.Length; i++)
                {
                    for (int j = 0; j < PrisonAphabet[i].Length; j++)
                    {
                        string str = PrisonAphabet[i][j];
                        if (String.Equals(PrisonAphabet[i][j], strFromFile.ToString()))
                        {
                            m_nNumberStr = i+1; // номер строки с символом (добавил префиксную часть инкремента специально)

                            m_nNumberStolb = j+1; // номер столбца с символом (добавил префиксную часть инкремента специально)
                            CreateBitArray();
                            break;
                        }
                    }
                }
            }
        } 

        private void CreateBitArray(bool isHasSpace = false /*признак пробела*/)
        {

            if (isHasSpace)
            {
                m_space = new BitArray(3, false); // инициализируем тремя битами 000
           
                string spaceString = PrintBitArray(ref m_space);

                CreateOutputString(ref spaceString);
            }
            else
            {
                m_symbolArray[0] = new BitArray(new int[] { m_nNumberStr });// Хранение байтов от младшего к старшему (little-endian) при печати буквы, например, м, не стоит пугаться следущего 110 вместо 011, т.к. это особенность хранения массива битов языка С

                m_symbolArray[0].Length = 3;

                m_symbolArray[1] = new BitArray(new int[] { m_nNumberStolb });// при печати буквы, например, м, не стоит пугаться следущего 110 вместо 011, т.к. это особенность хранения массива битов языка С

                m_symbolArray[1].Length = 3;

                string strRow = PrintBitArray(ref m_symbolArray[0]);
                string strCols = PrintBitArray(ref m_symbolArray[1]);
                CreateOutputString(ref strRow,  strCols);

            }

        }
      
        private void PrintBitArrayOtladka(ref BitArray Array)
        {
            int countArrays = 0;
            int result;
            foreach(bool b in Array)
            {
                result = (b == true) ? 1 : 0;
                countArrays++;
            }
        }

        private string PrintBitArray(ref BitArray Array) // функция побитно печатает символы в массиве битов
        {
            int result=0;

            string strSymbolAlphavit="";

            foreach (bool b in Array)
            {
                result = (b == true) ? 1 : 0;

                strSymbolAlphavit += result.ToString();
            }

            return strSymbolAlphavit;            
        }

        static void CreateOutputString(ref string strRow, string strCols = null) // функция создает выходную строку
        {
            String outputStr = null;

            outputStr = (strRow + strCols);

            OutputStrInFile += outputStr;
        }

        static void CheckStrLenght() // функция дополняет оставшиеся в закодированном сообщении биты нулями
        {
            if (OutputStrInFile.Length % 8 == 0) // если выходная строка получилась кратна 8-ми (т.е. байту)
            {
                return;
            }
            else
            {
                OutputStrInFile += "0";

                CheckStrLenght();
            }
        }
        public void CreateCodeFile(string myActionMessage) // функция создает выходной текстовый файл
        {
            try
            {

            FileStream fileStream = null;

            if (String.Equals(myActionMessage, "Code"))
                fileStream = new FileStream(m_bufNameFile + "\\shifr.txt", FileMode.Create); //создаем файловый поток

            if (String.Equals(myActionMessage, "UnCode"))
               fileStream = new FileStream(m_bufNameFile + "\\deshifr.txt", FileMode.Create); //создаем файловый поток

            m_writer = new StreamWriter(fileStream);

            if (fileStream==null)
               MessageBox.Show("Ошибка: Файловый поток не был создан" );
            
            Print del = null;

            del = LoadInputFile;
                switch (myActionMessage)
                {
                case "Code":
                        del.Invoke(Action.eCoding);
                        m_form.textBox2.Text = m_bufNameFile + "\\shifr.txt";
                        break;

                case "UnCode":
                        del.Invoke(Action.eUncoding);
                        m_form.textBox3.Text = m_bufNameFile + "\\deshifr.txt";
                        break;

                default: break;
                }

             m_writer.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: Нельзя записать фал на диск. Код ошибки: " + ex.Message);
            }
        }
    }
}