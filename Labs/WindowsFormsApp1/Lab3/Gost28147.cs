using System;

namespace WindowsFormsApp1
{
    class Gost28147
    {
       public enum Status { eCode, eunCode } 
       
        public static byte[,] P // блок подстановки из 8-ми узлов
        {
            get { return p; }
        }

        public static int NumberOffillBlocks { get; set; } = 0; // число старших незаполненных разрядов 8 ми байтового  блока

        public static int NumberOfFullBlocks { get; set; } = 0; // число полных 64 битных блока

        //Таблицы замены из RFC4357, S - блоки (КЗУ)
        private static readonly byte[,] p =
        {
            {0x04,0x0a,0x09,0x02,0x0d,0x08,0x00,0x0e,0x06,0x0B,0x01,0x0c,0x07,0x0f,0x05,0x03},
            {0x0e,0x0b,0x04,0x0c,0x06,0x0d,0x0f,0x0a,0x02,0x03,0x08,0x01,0x00,0x07,0x05,0x09},
            {0x05,0x08,0x01,0x0d,0x0a,0x03,0x04,0x02,0x0e,0x0f,0x0c,0x07,0x06,0x00,0x09,0x0b},
            {0x07,0x0d,0x0a,0x01,0x00,0x08,0x09,0x0f,0x0e,0x04,0x06,0x0c,0x0b,0x02,0x05,0x03},
            {0x06,0x0c,0x07,0x01,0x05,0x0f,0x0d,0x08,0x04,0x0a,0x09,0x0e,0x00,0x03,0x0b,0x02},
            {0x04,0x0b,0x0a,0x00,0x07,0x02,0x01,0x0d,0x03,0x06,0x08,0x05,0x09,0x0c,0x0f,0x0e},
            {0x0d,0x0b,0x04,0x01,0x03,0x0f,0x05,0x09,0x00,0x0a,0x0e,0x07,0x06,0x08,0x02,0x0c},
            {0x01,0x0f,0x0d,0x00,0x05,0x07,0x0a,0x04,0x09,0x02,0x03,0x0e,0x06,0x0b,0x08,0x0c}
        };

        
        /// <summary>
        /// Функция запускает алгоритм шифрования
        /// </summary>
        /// <param name="ot"></param>
        /// <param name="st"></param>
        /// <param name="k"></param>
        public static void Gost28147Ecb(byte[] ot, byte[] st, byte[] k, byte[] syncro, Status eStat)
        {
            if (ot.Length != st.Length) throw new ArgumentException("Invalid input arrays length");
            if ((ot.Length % 8) != 0) throw new ArgumentException("Invalid input arrays length"); // проверяем, чтобы длина массива была кратна 8


            uint tempInRight = Bytes2Dword(syncro, 0); // S в левый блок
            uint tempInLeft = Bytes2Dword(syncro, 4); // S в правый блок


            int offset = 0;
           
            bool isLastBlock = false;
            while (offset < ot.Length) // берем последовательно блоки по 8 Байт (64 бит) на вход, пока они не закончатся
            {
                uint tempOutLeft = 0; // Гш2
                uint tempOutRight = 0;// Гш1
                                  
                EncryptBlock(ref tempInRight , ref tempInLeft, ref tempOutRight, ref tempOutLeft, p, k); //+ шифрование блока (64 бит), поделенного на 2 части по 32 бита

                if (isLastBlock)
                    CorrectGamma(ref tempOutLeft, ref tempOutRight);

                uint tempCodeRight = 0;
                uint tempCodeLeft = 0;

               
                tempCodeRight = tempOutRight ^ Bytes2Dword(ot, offset);  //Tш1 = To1 + N1 (Tо1 = Tш1 + N1)
                tempCodeLeft = tempOutLeft ^ Bytes2Dword(ot, offset + 4);//Tш2 = To2 + N2 (Tо2 = Tш2 + N2)


                Array.Copy(Dword2Bytes(tempCodeRight), 0, st, offset, 4); // Копирование результата в массив st
                Array.Copy(Dword2Bytes(tempCodeLeft), 0, st, offset + 4, 4);// Копирование результата в массив st

                if (eStat == Status.eCode)
                {
                    tempInRight = tempCodeRight; //N1 = Tш1
                    tempInLeft = tempCodeLeft;   //N2 = Tш2
                }
                if (eStat == Status.eunCode)
                {
                    tempInRight = Bytes2Dword(ot, offset); // N1 = Тш1 (т.е. первый 32 битный блок зашифрованных данных)
                    tempInLeft = Bytes2Dword(ot, offset + 4);// N2 = Тш2 (т.е. второй 32 битный блок зашифрованных данных)
                }

                    offset += 8;

                if (NumberOfFullBlocks == offset/8)
                    isLastBlock = true;
            }
        }

     
        /// <summary>
        /// Функция корректирует гамму на последнем шаге
        /// </summary>
        /// <param name="gammaLeft"></param>
        /// <param name="gammaRight"></param>
        private static void CorrectGamma(ref uint gammaLeft, ref uint gammaRight)
        {
           
            ulong Gamma = gammaRight | ((ulong)gammaLeft << 32);

            switch (NumberOffillBlocks)
            {
                case 0: break;
                case 1: Gamma &= 0xff; break;
                case 2: Gamma &= 0xffff; break;
                case 3: Gamma &= 0xffffff; break;
                case 4: Gamma &= 0xffffffff; break;
                case 5: Gamma &= 0xffffffffff; break;
                case 6: Gamma &= 0xffffffffffff; break;
                case 7: Gamma &= 0xffffffffffffff; break;
                default: break;

            }
            gammaLeft = (uint)(Gamma >> 32);
            gammaRight = (uint)Gamma;
        }

        /// <summary>
        /// Функция разбивает 32 битный блок на 4 массива байтов
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static byte[] Dword2Bytes(uint input)
        {
            return new[]
            {
                (byte)(input & 0x000000ff), //получаем младший байт числа 
                (byte)((input >> 8) & 0x000000ff), //побитовый сдвиг -- второй символ 
                (byte)((input >> 16) & 0x000000ff), //побитовый сдвиг -- третий символ 
                (byte)((input >> 24) & 0x000000ff)    //побитовый сдвиг -- четвертый символ             
            };
        }

        /// <summary>
        /// Функция преобразует блок из 4 байт (32 бит) в uint число через сдвиги
        /// </summary>
        /// <param name="input"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        private static uint Bytes2Dword(byte[] input, int offset) // 
        {
            if (offset + 4 > input.Length) throw new ArgumentOutOfRangeException();
            return (((uint)input[offset + 3] << 24) | ((uint)input[offset + 2] << 16) |( (uint)input[offset + 1] << 8) ^ (input[offset]));
        }

        //разбиваем ключ на блоки (КОДИРОВАНИЕ)
        /// <summary>
        /// Функция описывает схему 32 циклов шифрования (схема Фейштеля)
        /// </summary>
        /// <param name="inLeft"></param>
        /// <param name="inRight"></param>
        /// <param name="outLeft"></param>
        /// <param name="outRight"></param>
        /// <param name="pi"></param>
        /// <param name="K"></param>
        private static void EncryptBlock(ref uint inRight, ref uint inLeft, ref uint outRight, ref uint outLeft, byte[,] pi, byte[] K)
        {
            uint m1 = inRight;
            uint m2 = inLeft;

            // Раунды
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 28));  // ---> X0
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 24));  // ---> X1
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 20));  // ---> X2
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 16));  // ---> X3
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 12));  // ---> X4
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 8));   // ---> X5
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 4));   // ---> X6
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 0));   // ---> X7

            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 28));  // ---> X0
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 24));  // ---> X1
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 20));  // ---> X2
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 16));  // ---> X3
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 12));  // ---> X4
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 8));   // ---> X5
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 4));   // ---> X6
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 0));   // ---> X7

            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 28));  // ---> X0
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 24));  // ---> X1
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 20));  // ---> X2
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 16));  // ---> X3
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 12));  // ---> X4
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 8));   // ---> X5
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 4));   // ---> X1
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 0));   // ---> X7

            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 0));   // ---> X7
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 4));   // ---> X6
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 8));   // ---> X5
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 12));  // ---> X4
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 16));  // ---> X3
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 20));  // ---> X2
            GostTransform(ref m1, ref m2, pi, Bytes2Dword(K, 24));  // ---> X1

            outRight = m1; // вычислили первую часть выходного блока
            outLeft = Pi(pi, m1 + Bytes2Dword(K, 28)); // последняя подстановка
            outLeft = (outLeft << 11) | (outLeft >> 21); // последний циклический сдвиг
            outLeft ^= m2; // вычислили вторую часть выходного блока
        }

        /// <summary>
        /// Функция итерационного процесса шифрования (на входе 2 блока по 32 бит, таблица подстановок и ключ)
        /// </summary>
        /// <param name="inBlockRight"></param>
        /// <param name="inBlockLeft"></param>
        /// <param name="pi"></param>
        /// <param name="k"></param>
        private static void GostTransform(ref uint inBlockRight, ref uint inBlockLeft, byte[,] pi, uint k)
        {
            uint outBlockRight = Pi(pi, inBlockRight + k); // начинаем подстановки, предварительно сложив по модулю 32 ЛЕВУЮ!!! часть блока и ключ (оба по 32 бита)
            outBlockRight = (outBlockRight << 11) | (outBlockRight >> 21); // выполняем циклический сдвиг полученного блока из 32 бит влево на 11 (образующая функция f)
            outBlockRight ^= inBlockLeft; // выходной ЛЕВЫЙ!!! блок = (ЛЕВЫЙ!!! [+] ключ) (+) ПРАВЫЙ!!! входной)
            uint outBlockLeft = inBlockRight; // выходной ПРАВЫЙ!!! блок = входному ЛЕВОМУ!!!
            //копируем все на выход
            inBlockLeft = outBlockRight; 
            inBlockRight = outBlockLeft; 
        }


        /// <summary>
        /// Функция производит подстановку строки из 32 бит блоками по 4 бита согласно таблице
        /// </summary>
        /// <param name="sBox"></param>
        /// <param name="inBlock"></param>
        /// <returns></returns>
        private static uint Pi(byte[,] sBox, uint inBlock) 
        {
            if (sBox == null) throw new ArgumentNullException("sBox");
            uint res = 0;
            res ^= sBox[0, (inBlock & 0x0000000f)]; // заменяем младшие 4 бита (8-ой блок)
            res ^= ((uint)sBox[1, ((inBlock & 0x000000f0) >> 4)] << 4);
            res ^= ((uint)sBox[2, ((inBlock & 0x00000f00) >> 8)] << 8);
            res ^= ((uint)sBox[3, ((inBlock & 0x0000f000) >> 12)] << 12);
            res ^= ((uint)sBox[4, ((inBlock & 0x000f0000) >> 16)] << 16);
            res ^= ((uint)sBox[5, ((inBlock & 0x00f00000) >> 20)] << 20);
            res ^= ((uint)sBox[6, ((inBlock & 0x0f000000) >> 24)] << 24);
            res ^= ((uint)sBox[7, ((inBlock & 0xf0000000) >> 28)] << 28);
            return res; // получили выходную строку 32 бита
        }

    }
}
