using System;
using System.Numerics;

namespace WindowsFormsApp1
{
    static class PowerMod
    {
        static bool[] IsPrimes;
        static void Init()
        {
            IsPrimes = new bool[250];
            BigInteger value = 10 / 3;

        }

        public static BigInteger ModPow(BigInteger value, BigInteger exponent, BigInteger modulus)
        {
            Init();

            BigInteger result = 1;
            if (exponent == 0)
               return result;

            while (exponent != 0)
            {
                if (!exponent.IsEven) //текущее значение является нечетным (exponent% 2 == 1)
                {
                    result = (result * value) % modulus;
                    exponent = (exponent - 1) / (BigInteger)2;
                }
                else
                {
                    exponent = exponent / (BigInteger)2;
                }
                value = (value * value) % modulus;
            }
            Console.WriteLine("Result is = {0}", result.ToString());
            return result;
        }

        public static BigInteger Check(BigInteger value, BigInteger exponent, BigInteger modulus)
        {
            Random rnd = new Random();
            
            BigInteger result = 0;
          
            result = BigInteger.ModPow(value, exponent, modulus);
            Console.WriteLine("Checking Result is = {0}", result.ToString());
            return result;
        }




        //public static BigInteger ModPow(BigInteger value, BigInteger exponent, BigInteger modulus)
        //{


        //    int signRes = +1;
        //    int signVal = +1;
        //    int signMod = +1;
        //    bool expIsEven = exponent.IsEven;

        //    BigInteger regRes = BigInteger.One;
        //    BigInteger regVal = value;
        //    BigInteger regMod = modulus;

        //    BigInteger regTmp = 0;
        //    regRes = regRes % regMod;
        //   //BigIntegerBuilder regRes = new BigIntegerBuilder(BigInteger.One, ref signRes);
        //   // BigIntegerBuilder regVal = new BigIntegerBuilder(value, ref signVal);
        //   // BigIntegerBuilder regMod = new BigIntegerBuilder(modulus, ref signMod);
        //   // BigIntegerBuilder regTmp = new BigIntegerBuilder(regVal.Size);

        //    //  regRes.Mod(ref regMod);   // Handle special case of exponent=0, modulus=1

        //    if (BitConverter.GetBytes((uint)exponent) == null)
        //    {   // exponent fits into an Int32
        //        ModPowInner(BitConverter.ToUInt32(BitConverter.GetBytes((uint)exponent), 0), ref regRes, ref regVal, ref regMod, ref regTmp);
        //    }
        //    else
        //    {   // very large exponent
        //        int len = exponent.ToByteArray().Length;

        //        for (int i = 0; i < len - 1; i++)
        //        {
        //            uint exp = BitConverter.ToUInt32(BitConverter.GetBytes((uint)exponent), i); // exponent._bits[i];
        //            ModPowInner32(exp, ref regRes, ref regVal, ref regMod, ref regTmp);
        //        }
        //        ModPowInner(Convert.ToUInt32(exponent.ToByteArray().GetValue(len - 1)), ref regRes, ref regVal, ref regMod, ref regTmp);

        //    }

        //    return regRes.GetInteger(value._sign > 0 ? +1 : expIsEven ? +1 : -1);
        //}


        //private static void ModPowInner32(uint exp, ref BigInteger regRes, ref BigInteger regVal, ref BigInteger regMod, ref BigInteger regTmp)
        //{
        //    for (int i = 0; i < 32; i++)
        //    {
        //        if ((exp & 1) == 1)   // !(Exponent.IsEven)
        //        ModPowUpdateResult(ref regRes, ref regVal, ref regMod, ref regTmp);

        //        ModPowSquareModValue(ref regVal, ref regMod, ref regTmp);
        //        exp >>= 1;
        //    }
        //}


        //private static void ModPowInner(uint exp, ref BigInteger regRes, ref BigInteger regVal, ref BigInteger regMod, ref BigInteger regTmp)
        //{
        //    while (exp != 0)          // !(Exponent.IsZero)
        //    {
        //        if ((exp & 1) == 1)   // !(Exponent.IsEven)
        //            ModPowUpdateResult(ref regRes, ref regVal, ref regMod, ref regTmp);
        //        if (exp == 1)         // Exponent.IsOne - we can exit early
        //            break;
        //        ModPowSquareModValue(ref regVal, ref regMod, ref regTmp);
        //        exp >>= 1;

        //    }
        //}

        //private static void ModPowUpdateResult(ref BigInteger regRes, ref BigInteger regVal, ref BigInteger regMod, ref BigInteger regTmp)
        //{
        //    Swap(ref regRes, ref regTmp);
        //    regRes = regTmp * regVal;   // result = result * value;
        //    regRes = regRes % regMod;  // result = result % modulus;                       
        //}

        //private static void ModPowSquareModValue(ref BigInteger regVal, ref BigInteger regMod, ref BigInteger regTmp)
        //{
        //    Swap(ref regVal, ref regTmp);
        //    regVal= regTmp * regTmp;   // value = value * value;
        //    regVal %= regMod;          // value = value % modulus;
        //}

        //public static void Swap<T>(ref T a, ref T b)
        //{
        //    T tmp = a;
        //    a = b;
        //    b = tmp;
        //}

        //internal static int Length(uint[] rgu)
        //{
        //    int cu = rgu.Length;
        //    if (rgu[cu - 1] != 0)
        //        return cu;
        //    Contract.Assert(cu >= 2 && rgu[cu - 2] != 0);
        //    return cu - 1;
        //}

    }
}
