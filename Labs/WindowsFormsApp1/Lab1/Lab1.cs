using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Lab1 : Form
    {
        public Lab1()
        {
            InitializeComponent();
         //   MessageBox.Show("Введите две строки, используя в качестве разделитепля пробел","Внимание!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gammirovanie p = new Gammirovanie(this);
            string str = textBox1.Text;
            if (str != "")
            p.ParcingString(ref str);

            str = textBox2.Text;
            if (str != "")
            p.ParcingString(ref str, false);

            p.Find();


        }
    }
}
