namespace WindowsFormsApp1
{
    class MD5
    {
    
        enum Rounds { eOne, eTwo, eTree, eFour}

        public MD5()
        {
            m_cashedElems = new uint[16];
        }
        
        // Шаг 3. Инициализация буфера
        private static uint[] MD5Const =
        {
            0x67452301,
            0xEFCDAB89,
            0x98BADCFE,
            0x10325476
        };

        //Определим таблицу констант  T[1...64] — 64-элементная таблица данных
        private static uint[] T =
        {
            0xd76aa478,0xe8c7b756,0x242070db,0xc1bdceee,
            0xf57c0faf,0x4787c62a,0xa8304613,0xfd469501,
            0x698098d8,0x8b44f7af,0xffff5bb1,0x895cd7be,
            0x6b901122,0xfd987193,0xa679438e,0x49b40821,
            0xf61e2562,0xc040b340,0x265e5a51,0xe9b6c7aa,
            0xd62f105d,0x2441453,0xd8a1e681,0xe7d3fbc8,
            0x21e1cde6,0xc33707d6,0xf4d50d87,0x455a14ed,
            0xa9e3e905,0xfcefa3f8,0x676f02d9,0x8d2a4c8a,
            0xfffa3942,0x8771f681,0x6d9d6122,0xfde5380c,
            0xa4beea44,0x4bdecfa9,0xf6bb4b60,0xbebfbc70,
            0x289b7ec6,0xeaa127fa,0xd4ef3085,0x4881d05,
            0xd9d4d039,0xe6db99e5,0x1fa27cf8,0xc4ac5665,
            0xf4292244,0x432aff97,0xab9423a7,0xfc93a039,
            0x655b59c3,0x8f0ccc92,0xffeff47d,0x85845dd1,
            0x6fa87e4f,0xfe2ce6e0,0xa3014314,0x4e0811a1,
            0xf7537e82,0xbd3af235,0x2ad7d2bb,0xeb86d391
        };

        private delegate void MD5HashDelegate(ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i, uint[] cashedElems);

        private MD5HashDelegate[] rounds =
        {
            
            delegate(ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i, uint[] cashedElems) { a = b + Operations.lshift((a + ((b & c) | (~(b) & d)) + cashedElems[k] + T[i - 1]), s);},
            delegate(ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i, uint[] cashedElems) { a = b + Operations.lshift((a + ((b & d) | (c & ~d)) + cashedElems[k] + T[i - 1]), s);},
            delegate(ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i, uint[] cashedElems) { a = b + Operations.lshift((a + (b ^ c ^ d) + cashedElems[k] + T[i - 1]), s);},
            delegate(ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i, uint[] cashedElems) { a = b + Operations.lshift((a + (c ^ (b | ~d)) + cashedElems[k] + T[i - 1]), s);}
        };

        private byte[] m_sourceBytes;
        private uint[] m_cashedElems;
       
        public string calculate(string value)
        {
            m_sourceBytes = new byte[value.Length];
            for (int i = 0; i < value.Length; i++)
                m_sourceBytes[i] = (byte)value[i];

            string output = performCalculation();

            m_sourceBytes = null;
            m_cashedElems = null;
            return output;
        }

        private string performCalculation()
        {
            uint[] vals = new uint[] { MD5Const[0], MD5Const[1], MD5Const[2], MD5Const[3] };

            byte[] bMsg = setAfterPadding();

            uint intsCount = (uint)(bMsg.Length * 8) / 32;
            for (int i = 0; i < intsCount / 16; i++)
            {
                copyDataBlock(bMsg, i);
                performRounds(ref vals[0], ref vals[1], ref vals[2], ref vals[3], m_cashedElems);
            }
            return Operations.ToDigitsString(vals);
        }

        #region Вычисления в цикле
        /* 
        * Ссылка на материал Википедии: https://ru.wikipedia.org/wiki/MD5
        Этап 1
        * [ABCD  0  7  1]  [DABC  1 12  2]  [CDAB  2 17  3]  [BCDA  3 22  4]
        * [ABCD  4  7  5]  [DABC  5 12  6]  [CDAB  6 17  7]  [BCDA  7 22  8]
        * [ABCD  8  7  9]  [DABC  9 12 10]  [CDAB 10 17 11]  [BCDA 11 22 12]
        * [ABCD 12  7 13]  [DABC 13 12 14]  [CDAB 14 17 15]  [BCDA 15 22 16]
        Этап 2
        * [ABCD  1  5 17]  [DABC  6  9 18]  [CDAB 11 14 19]  [BCDA  0 20 20]
        * [ABCD  5  5 21]  [DABC 10  9 22]  [CDAB 15 14 23]  [BCDA  4 20 24]
        * [ABCD  9  5 25]  [DABC 14  9 26]  [CDAB  3 14 27]  [BCDA  8 20 28]
        * [ABCD 13  5 29]  [DABC  2  9 30]  [CDAB  7 14 31]  [BCDA 12 20 32]
        Этап 3
        * [ABCD  5  4 33]  [DABC  8 11 34]  [CDAB 11 16 35]  [BCDA 14 23 36]
        * [ABCD  1  4 37]  [DABC  4 11 38]  [CDAB  7 16 39]  [BCDA 10 23 40]
        * [ABCD 13  4 41]  [DABC  0 11 42]  [CDAB  3 16 43]  [BCDA  6 23 44]
        * [ABCD  9  4 45]  [DABC 12 11 46]  [CDAB 15 16 47]  [BCDA  2 23 48]
        Этап 4
        * [ABCD  0  6 49]  [DABC  7 10 50]  [CDAB 14 15 51]  [BCDA  5 21 52]
        * [ABCD 12  6 53]  [DABC  3 10 54]  [CDAB 10 15 55]  [BCDA  1 21 56]
        * [ABCD  8  6 57]  [DABC 15 10 58]  [CDAB  6 15 59]  [BCDA 13 21 60]
        * [ABCD  4  6 61]  [DABC 11 10 62]  [CDAB  2 15 63]  [BCDA  9 21 64]
        */
        #endregion
        private void performRounds(ref uint A, ref uint B, ref uint C, ref uint D, uint[] cashedElems)
        {
         
            uint AA = A, BB = B, CC = C, DD = D;

            int STAGE = 0;

            // Этап 1
            /* [abcd k s i] a = b + ((a + F(b,c,d) + X[k] + T[i]) <<< s). */
            STAGE = (int)Rounds.eOne;
            rounds[STAGE](ref A, B, C, D, 0, 7, 1, cashedElems);   rounds[STAGE](ref D, A, B, C, 1, 12, 2,   cashedElems); rounds[STAGE](ref C, D, A, B, 2, 17, 3,  cashedElems);  rounds[STAGE](ref B, C, D, A, 3, 22, 4, cashedElems);
            rounds[STAGE](ref A, B, C, D, 4, 7, 5, cashedElems);   rounds[STAGE](ref D, A, B, C, 5, 12, 6,   cashedElems); rounds[STAGE](ref C, D, A, B, 6, 17, 7,  cashedElems);  rounds[STAGE](ref B, C, D, A, 7, 22, 8, cashedElems);
            rounds[STAGE](ref A, B, C, D, 8, 7, 9, cashedElems);   rounds[STAGE](ref D, A, B, C, 9, 12, 10,  cashedElems); rounds[STAGE](ref C, D, A, B, 10, 17, 11, cashedElems); rounds[STAGE](ref B, C, D, A, 11, 22, 12, cashedElems);
            rounds[STAGE](ref A, B, C, D, 12, 7, 13, cashedElems); rounds[STAGE](ref D, A, B, C, 13, 12, 14, cashedElems); rounds[STAGE](ref C, D, A, B, 14, 17, 15, cashedElems); rounds[STAGE](ref B, C, D, A, 15, 22, 16, cashedElems);

            // Этап 2
            /* [abcd k s i] a = b + ((a + G(b,c,d) + X[k] + T[i]) <<< s). */
            STAGE = (int)Rounds.eTwo;
            rounds[STAGE](ref A, B, C, D, 1, 5, 17, cashedElems);  rounds[STAGE](ref D, A, B, C, 6, 9, 18,  cashedElems); rounds[STAGE](ref C, D, A, B, 11, 14, 19, cashedElems); rounds[STAGE](ref B, C, D, A, 0, 20, 20, cashedElems);
            rounds[STAGE](ref A, B, C, D, 5, 5, 21, cashedElems);  rounds[STAGE](ref D, A, B, C, 10, 9, 22, cashedElems); rounds[STAGE](ref C, D, A, B, 15, 14, 23, cashedElems); rounds[STAGE](ref B, C, D, A, 4, 20, 24, cashedElems);
            rounds[STAGE](ref A, B, C, D, 9, 5, 25, cashedElems);  rounds[STAGE](ref D, A, B, C, 14, 9, 26, cashedElems); rounds[STAGE](ref C, D, A, B, 3, 14, 27, cashedElems);  rounds[STAGE](ref B, C, D, A, 8, 20, 28, cashedElems);
            rounds[STAGE](ref A, B, C, D, 13, 5, 29, cashedElems); rounds[STAGE](ref D, A, B, C, 2, 9, 30,  cashedElems); rounds[STAGE](ref C, D, A, B, 7, 14, 31,  cashedElems); rounds[STAGE](ref B, C, D, A, 12, 20, 32, cashedElems);

            // Этап 3
            /* [abcd k s i] a = b + ((a + H(b,c,d) + X[k] + T[i]) <<< s). */
            STAGE = (int)Rounds.eTree;
            rounds[STAGE](ref A, B, C, D, 5, 4, 33, cashedElems);  rounds[STAGE](ref D, A, B, C, 8, 11, 34,  cashedElems); rounds[STAGE](ref C, D, A, B, 11, 16, 35, cashedElems); rounds[STAGE](ref B, C, D, A, 14, 23, 36, cashedElems);
            rounds[STAGE](ref A, B, C, D, 1, 4, 37, cashedElems);  rounds[STAGE](ref D, A, B, C, 4, 11, 38,  cashedElems); rounds[STAGE](ref C, D, A, B, 7, 16, 39,  cashedElems); rounds[STAGE](ref B, C, D, A, 10, 23, 40, cashedElems);
            rounds[STAGE](ref A, B, C, D, 13, 4, 41, cashedElems); rounds[STAGE](ref D, A, B, C, 0, 11, 42,  cashedElems); rounds[STAGE](ref C, D, A, B, 3, 16, 43,  cashedElems); rounds[STAGE](ref B, C, D, A, 6, 23, 44,  cashedElems);
            rounds[STAGE](ref A, B, C, D, 9, 4, 45, cashedElems);  rounds[STAGE](ref D, A, B, C, 12, 11, 46, cashedElems); rounds[STAGE](ref C, D, A, B, 15, 16, 47, cashedElems); rounds[STAGE](ref B, C, D, A, 2, 23, 48,  cashedElems);

            // Этап 4
            /* [abcd k s i] a = b + ((a + I(b,c,d) + X[k] + T[i]) <<< s). */
            STAGE = (int)Rounds.eFour;
            rounds[STAGE](ref A, B, C, D, 0, 6, 49, cashedElems);  rounds[STAGE](ref D, A, B, C, 7, 10, 50,  cashedElems); rounds[STAGE](ref C, D, A, B, 14, 15, 51, cashedElems); rounds[STAGE](ref B, C, D, A, 5, 21, 52,  cashedElems);
            rounds[STAGE](ref A, B, C, D, 12, 6, 53, cashedElems); rounds[STAGE](ref D, A, B, C, 3, 10, 54,  cashedElems); rounds[STAGE](ref C, D, A, B, 10, 15, 55, cashedElems); rounds[STAGE](ref B, C, D, A, 1, 21, 56,  cashedElems);
            rounds[STAGE](ref A, B, C, D, 8, 6, 57, cashedElems);  rounds[STAGE](ref D, A, B, C, 15, 10, 58, cashedElems); rounds[STAGE](ref C, D, A, B, 6, 15, 59, cashedElems);  rounds[STAGE](ref B, C, D, A, 13, 21, 60, cashedElems);
            rounds[STAGE](ref A, B, C, D, 4, 6, 61, cashedElems);  rounds[STAGE](ref D, A, B, C, 11, 10, 62, cashedElems); rounds[STAGE](ref C, D, A, B, 2, 15, 63, cashedElems);  rounds[STAGE](ref B, C, D, A, 9, 21, 64,  cashedElems);

            //Суммируем с результатом предыдущего цикла:
            A = A + AA; B = B + BB; C = C + CC; D = D + DD;
        }

        
        private byte[] setAfterPadding()
        {
            //Шаг 1. Выравнивание потока
            int pt = 448 - (m_sourceBytes.Length * 8) % 512;
            int padding = (pt + 512) % 512;
            padding = padding != 0 ? padding : 512;
            int msgBuff = (m_sourceBytes.Length) + (padding / 8) + 8;
            long msgSize = m_sourceBytes.Length * 8;
            byte[] message = new byte[msgBuff];
            for (int i = 0; i < m_sourceBytes.Length; i++)
                message[i] = m_sourceBytes[i];
            message[m_sourceBytes.Length] |= 0x80;
            for (int i = 8; i > 0; i--)
                message[msgBuff - i] = (byte)(msgSize >> ((8 - i) * 8) & 0x00000000000000ff);
            return message;
        }

        private void copyDataBlock(byte[] message, int blockNum)
        {

            blockNum = blockNum << 6;
            for (int j = 0; j < 61; j += 4)
            {
                m_cashedElems[j >> 2] = (((uint)message[blockNum + (j + 3)]) << 24) |
                        (((uint)message[blockNum + (j + 2)]) << 16) |
                        (((uint)message[blockNum + (j + 1)]) << 8) |
                        (((uint)message[blockNum + (j)]));
            }
        }
    }

}

