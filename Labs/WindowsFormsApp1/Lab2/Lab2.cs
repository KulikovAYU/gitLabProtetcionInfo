﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Lab2 : Form
    {
      

        private Tyrma tyrma;

       public Lab2()
       {
            InitializeComponent();
            tyrma = new Tyrma(this);
       }

        private void button1_Click(object sender, EventArgs e)
        {
            tyrma.CreateCodeFile("Code");
            button2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
       {
            Process.Start(tyrma.GetPathName());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tyrma.CreateCodeFile("UnCode");
        }
    }
}