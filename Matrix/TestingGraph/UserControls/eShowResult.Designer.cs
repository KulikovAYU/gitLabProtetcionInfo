namespace TestingGraph.UserControls
{
    partial class eShowResult
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.setkaOK = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TextBox = new System.Windows.Forms.RichTextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.setkaOK);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.Reset);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Location = new System.Drawing.Point(509, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 444);
            this.panel2.TabIndex = 42;
            // 
            // setkaOK
            // 
            this.setkaOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setkaOK.Location = new System.Drawing.Point(43, 31);
            this.setkaOK.Margin = new System.Windows.Forms.Padding(4);
            this.setkaOK.Name = "setkaOK";
            this.setkaOK.Size = new System.Drawing.Size(202, 28);
            this.setkaOK.TabIndex = 35;
            this.setkaOK.Text = "Ребра";
            this.setkaOK.UseVisualStyleBackColor = true;
            this.setkaOK.Click += new System.EventHandler(this.setkaOK_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(43, 67);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(202, 28);
            this.button4.TabIndex = 37;
            this.button4.Text = "Смежности";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Reset
            // 
            this.Reset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Reset.Location = new System.Drawing.Point(43, 259);
            this.Reset.Margin = new System.Windows.Forms.Padding(4);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(202, 35);
            this.Reset.TabIndex = 36;
            this.Reset.Text = "Назад";
            this.Reset.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(43, 103);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(202, 28);
            this.button5.TabIndex = 38;
            this.button5.Text = "Инцидентности";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.TextBox);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 444);
            this.panel1.TabIndex = 41;
            // 
            // TextBox
            // 
            this.TextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.Location = new System.Drawing.Point(0, 0);
            this.TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox.Name = "TextBox";
            this.TextBox.ReadOnly = true;
            this.TextBox.Size = new System.Drawing.Size(500, 444);
            this.TextBox.TabIndex = 16;
            this.TextBox.Text = "";
            this.TextBox.Visible = false;
            // 
            // eShowResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "eShowResult";
            this.Size = new System.Drawing.Size(800, 450);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button setkaOK;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox TextBox;
    }
}
