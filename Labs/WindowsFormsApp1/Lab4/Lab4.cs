using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Lab4 : Form
    {
        public Lab4()
        {
            InitializeComponent();
            richTextBox1.Text = new MD5().calculate(textBox1.Text);
        }
    
        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
           richTextBox1.Text = new MD5().calculate(textBox1.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ru.wikipedia.org/wiki/MD5");
        }
    }
}
