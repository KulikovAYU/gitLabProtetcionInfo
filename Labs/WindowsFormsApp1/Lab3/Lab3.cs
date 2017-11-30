using System;
using System.Windows.Forms;
//D:\Рабочая_область\Загрузки\Lab_3 (преобразов - ключ исправл.)
namespace WindowsFormsApp1
{
    public partial class Lab3 : Form
    {
        enum  Status {eCode, eunCode }
        public Lab3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           CheckStringLenghtEncrypt();
        }

        void CheckStringLenghtEncrypt()
        {
            if (textBox2.Text.Length == 8)
            {

                if (textBox1.Text.Length > 31) // проверяем, чтобы ключ содержал более 31 символа
                {

                    if (richTextBox1.Text.Length > 0) // если текстовое поле не пустое, то 
                    {
                        richTextBox2.Text = EncryptText(richTextBox1.Text, textBox1.Text, textBox2.Text); // начинаем шифрование и результат помещаем в richTextBox2
                        DialogResult res = MessageBox.Show("Шифрование выполнено! Очистить поле текста для зашифрования?","Гаммирование с обратной связью",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                        if (res == DialogResult.OK)
                        {
                            richTextBox1.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Шифруемый текст не может быть пустым!", "Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Ключевая фраза должна содержать 32 символа!","Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else
            {
                MessageBox.Show("Значение синхропосылки должно содержать 8 символов!","Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

       
        }

        void CheckStringLenghtDecrypt()
        {
            if (textBox2.Text.Length == 8)
            {
                if (textBox1.Text.Length > 31)
                {
                    if (richTextBox2.Text.Length > 0)
                    {
                          richTextBox1.Text = DecryptText(richTextBox2.Text, textBox1.Text, textBox2.Text); // Тут
                    }
                    else
                    {
                        MessageBox.Show("Шифруемый текст не может быть пустым!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Ключевая фраза должна содержать 32 символа!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else
            {
                MessageBox.Show("Значение синхропосылки должно содержать 8 символов!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            CheckStringLenghtDecrypt();
        }
        
        /// <summary>
        /// Запуск алгоритма шифрования
        /// </summary>
        /// <param name="text"></param>
        /// <param name="keyString"></param>
        /// <returns></returns>
        private string EncryptText(string text, string keyString, string keyStringSynchro) 
        {
            byte[] strbytes = GetBytesArrayFromText(text);
            byte[] result = new byte[strbytes.Length];
            byte[] synchro = GetSynchroFromText(keyStringSynchro);
            byte[] key = GetKeyFromText(keyString);


            Gost28147.Gost28147Ecb(strbytes, result, key, synchro, Gost28147.Status.eCode);

            return PrintByteArray(result);
          
        }



        /// <summary>
        /// Запуск расшифрования
        /// </summary>
        /// <param name="text"></param>
        /// <param name="keyString"></param>
        /// <param name="keyStringSynchro"></param>
        /// <returns></returns>

        private string DecryptText(string text, string keyString, string keyStringSynchro)
        {
            byte[] strbytes = GetDecBytesArrayFromText(text);
            byte[] result = new byte[strbytes.Length];
            byte[] synchro = GetSynchroFromText(keyStringSynchro);
            byte[] key = GetKeyFromText(keyString);


            Gost28147.Gost28147Ecb(strbytes, result, key, synchro, Gost28147.Status.eunCode);

            return PrintString(result);
        }







        /// <summary>
        /// Функция преобразует символы исходного текста в байты и записываем результат в массив
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private byte[] GetBytesArrayFromText(string text)
        {
           
            int blocksCount = 0;
            double tmp;
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            byte[] strBytes = enc.GetBytes(text); // записываем коды символов в массив
            tmp = strBytes.Length / 8; // считаем, сколько блоков по 64 бита (8 Байт) содержит исходный текст
            Gost28147.NumberOfFullBlocks = (int)tmp;
            if ((strBytes.Length % 8) != 0) // если длина исходного текста не делится нацело на 8
            {
                blocksCount = Convert.ToInt32(Math.Truncate(tmp)) + 1; // добавляем к целым блокам (по 64 бита) ещё один
                Gost28147.NumberOffillBlocks = (int) (strBytes.Length - 8*Math.Truncate(tmp)); // считаем количество заполненных блоков
            }
            else
            {
                blocksCount = Convert.ToInt32(Math.Truncate(tmp)); // считаем количество целых блоков
            }

            byte[] bytesArray = new byte[blocksCount * 8]; // инициализируем массив байт размерностью, в зависимости от числа блоков в исх. тексте
            Array.Copy(strBytes, 0, bytesArray, 0, strBytes.Length); // копируем в него коды символов исх. текста
            return bytesArray;
        }


        /// <summary>
        /// Функция преобразует символы ключа в байты и записывает результат в массив
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private byte[] GetKeyFromText(string text)
        {
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            byte[] strBytes = enc.GetBytes(text);
            byte[] arr = new byte[32];
            Array.Copy(strBytes, 0, arr, 0, 32);

            return arr;
        }

        /// <summary>
        /// Функция преобразует символы синхропосылки в байты и записывает результат в массив
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private byte[] GetSynchroFromText(string text) // 
        {
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            byte[] strBytes = enc.GetBytes(text);
            byte[] arr = new byte[8];
            Array.Copy(strBytes, 0, arr, 0, 8);

            return arr;
        }

        /// <summary>
        /// Функция выводит зашифрованный массив байтов
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private string PrintByteArray(Byte[] arr)
        {
            string str = "";
            if (arr == null)
            {
                return "NULL";
            }
            int i;
            for (i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " ";
            }
            return str;
        }


        private string PrintString(Byte[] arr)
        {
            string str = "";
            if (arr == null)
            {
                return "NULL";
            }
            int i;
            for (i = 0; i < arr.Length; i++)
            {
                str += Convert.ToChar(arr[i]);
            }
            return str;
        }

        private byte[] GetDecBytesArrayFromText(string text)
        {
            int i = 0;
            foreach (char c in text)
            {
                if (c == ' ')
                {
                    i++;
                }
            }

            byte[] result = new byte[i];
            i = 0;

            string tmp = "";

            foreach (char c in text)
            {
                if (c != ' ')
                {
                    tmp += c;
                }
                else
                {
                    result[i] = byte.Parse(tmp);
                    i++;
                    tmp = "";
                }
            }

            return result;
        }

    }
}
