using System.Numerics;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Lab5 : Form
    {
        public Lab5()
        {
            InitializeComponent();
            // public static BigInteger ModPow(BigInteger value, BigInteger exponent, BigInteger modulus)

            BigInteger value = 249;
            BigInteger exponent = 321;
            BigInteger modulus = 499;
            PowerMod.ModPow(value, exponent, modulus);
            PowerMod.Check(value, exponent, modulus);
        }
    }
}
