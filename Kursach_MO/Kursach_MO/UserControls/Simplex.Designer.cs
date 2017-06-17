namespace Kursach_MO.UserControls
{
    partial class Simplex
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
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.x0_TB = new System.Windows.Forms.TextBox();
            this.y0_TB = new System.Windows.Forms.TextBox();
            this.E_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.clc_Button = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Graph_BT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(322, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(215, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "Симплексный поиск";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(31, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 67;
            this.label1.Text = "x0=";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(28, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 20);
            this.label10.TabIndex = 66;
            this.label10.Text = "Исходные данные";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(31, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 68;
            this.label2.Text = "y0=";
            // 
            // x0_TB
            // 
            this.x0_TB.Location = new System.Drawing.Point(71, 86);
            this.x0_TB.Name = "x0_TB";
            this.x0_TB.Size = new System.Drawing.Size(100, 20);
            this.x0_TB.TabIndex = 69;
            this.x0_TB.Text = "1";
            // 
            // y0_TB
            // 
            this.y0_TB.Location = new System.Drawing.Point(71, 126);
            this.y0_TB.Name = "y0_TB";
            this.y0_TB.Size = new System.Drawing.Size(100, 20);
            this.y0_TB.TabIndex = 70;
            this.y0_TB.Text = "1";
            // 
            // E_TB
            // 
            this.E_TB.Location = new System.Drawing.Point(71, 171);
            this.E_TB.Name = "E_TB";
            this.E_TB.Size = new System.Drawing.Size(100, 20);
            this.E_TB.TabIndex = 71;
            this.E_TB.Text = "0,001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(31, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 20);
            this.label3.TabIndex = 72;
            this.label3.Text = "Ԑ=";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton3.Location = new System.Drawing.Point(35, 292);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(287, 24);
            this.radioButton3.TabIndex = 85;
            this.radioButton3.Text = "F=x1^4+x2^4+2*(x1^2)*(x2^2)-4*x1+3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.Location = new System.Drawing.Point(35, 266);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(223, 24);
            this.radioButton2.TabIndex = 84;
            this.radioButton2.Text = "F=100*(x2-x1^2)^2+(1-x1)^2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(35, 242);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(119, 24);
            this.radioButton1.TabIndex = 83;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "F=x1^2+x2^2";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(31, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 82;
            this.label4.Text = "Тестовые функции";
            // 
            // clc_Button
            // 
            this.clc_Button.Location = new System.Drawing.Point(35, 340);
            this.clc_Button.Name = "clc_Button";
            this.clc_Button.Size = new System.Drawing.Size(108, 49);
            this.clc_Button.TabIndex = 86;
            this.clc_Button.Text = "Расчет";
            this.clc_Button.UseVisualStyleBackColor = true;
            this.clc_Button.Click += new System.EventHandler(this.clc_Button_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(381, 42);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(517, 491);
            this.textBox3.TabIndex = 87;
            // 
            // Graph_BT
            // 
            this.Graph_BT.Location = new System.Drawing.Point(35, 418);
            this.Graph_BT.Name = "Graph_BT";
            this.Graph_BT.Size = new System.Drawing.Size(108, 49);
            this.Graph_BT.TabIndex = 88;
            this.Graph_BT.Text = "Графика";
            this.Graph_BT.UseVisualStyleBackColor = true;
            this.Graph_BT.Click += new System.EventHandler(this.Graph_BT_Click);
            // 
            // Simplex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Graph_BT);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.clc_Button);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.E_TB);
            this.Controls.Add(this.y0_TB);
            this.Controls.Add(this.x0_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Name = "Simplex";
            this.Size = new System.Drawing.Size(950, 570);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox x0_TB;
        private System.Windows.Forms.TextBox y0_TB;
        private System.Windows.Forms.TextBox E_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button clc_Button;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button Graph_BT;
    }
}
