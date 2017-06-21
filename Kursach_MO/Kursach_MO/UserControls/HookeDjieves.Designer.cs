namespace Kursach_MO.UserControls
{
    partial class HookeDjieves
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
            this.E_TB = new System.Windows.Forms.TextBox();
            this.dx_TB = new System.Windows.Forms.TextBox();
            this.x0_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnImg = new System.Windows.Forms.Panel();
            this.clc_Button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Xopt_TB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.Yopt_TB = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.y0_TB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(336, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(214, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "Метод Хука-Дживса";
            // 
            // E_TB
            // 
            this.E_TB.Location = new System.Drawing.Point(50, 104);
            this.E_TB.Name = "E_TB";
            this.E_TB.Size = new System.Drawing.Size(100, 20);
            this.E_TB.TabIndex = 70;
            this.E_TB.Text = "0,1";
            // 
            // dx_TB
            // 
            this.dx_TB.Location = new System.Drawing.Point(50, 78);
            this.dx_TB.Name = "dx_TB";
            this.dx_TB.Size = new System.Drawing.Size(100, 20);
            this.dx_TB.TabIndex = 69;
            this.dx_TB.Text = "2";
            // 
            // x0_TB
            // 
            this.x0_TB.Location = new System.Drawing.Point(185, 49);
            this.x0_TB.Name = "x0_TB";
            this.x0_TB.Size = new System.Drawing.Size(29, 20);
            this.x0_TB.TabIndex = 68;
            this.x0_TB.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(16, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 20);
            this.label3.TabIndex = 67;
            this.label3.Text = "Ԑ=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(16, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 66;
            this.label2.Text = "Δx=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 65;
            this.label1.Text = "Начальная точка";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(13, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 20);
            this.label10.TabIndex = 64;
            this.label10.Text = "Исходные данные";
            // 
            // pnImg
            // 
            this.pnImg.Location = new System.Drawing.Point(324, 68);
            this.pnImg.Name = "pnImg";
            this.pnImg.Size = new System.Drawing.Size(600, 400);
            this.pnImg.TabIndex = 71;
            this.pnImg.Paint += new System.Windows.Forms.PaintEventHandler(this.pnImg_Paint);
            // 
            // clc_Button
            // 
            this.clc_Button.Location = new System.Drawing.Point(20, 255);
            this.clc_Button.Name = "clc_Button";
            this.clc_Button.Size = new System.Drawing.Size(108, 49);
            this.clc_Button.TabIndex = 72;
            this.clc_Button.Text = "Расчет";
            this.clc_Button.UseVisualStyleBackColor = true;
            this.clc_Button.Click += new System.EventHandler(this.clc_Button_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(13, 358);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 20);
            this.label8.TabIndex = 77;
            this.label8.Text = "Результаты расчета";
            // 
            // Xopt_TB
            // 
            this.Xopt_TB.Location = new System.Drawing.Point(131, 395);
            this.Xopt_TB.Name = "Xopt_TB";
            this.Xopt_TB.Size = new System.Drawing.Size(100, 20);
            this.Xopt_TB.TabIndex = 75;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(27, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 73;
            this.label6.Text = "Xopt=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(13, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 78;
            this.label4.Text = "Тестовые функции";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(17, 175);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(119, 24);
            this.radioButton1.TabIndex = 79;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "F=x1^2+x2^2";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.Location = new System.Drawing.Point(17, 199);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(223, 24);
            this.radioButton2.TabIndex = 80;
            this.radioButton2.Text = "F=100*(x2-x1^2)^2+(1-x1)^2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(27, 461);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 74;
            this.label5.Text = "Func(Xopt)=";
            this.label5.Visible = false;
            // 
            // Yopt_TB
            // 
            this.Yopt_TB.Location = new System.Drawing.Point(131, 461);
            this.Yopt_TB.Name = "Yopt_TB";
            this.Yopt_TB.Size = new System.Drawing.Size(100, 20);
            this.Yopt_TB.TabIndex = 76;
            this.Yopt_TB.Visible = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton3.Location = new System.Drawing.Point(17, 225);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(287, 24);
            this.radioButton3.TabIndex = 81;
            this.radioButton3.Text = "F=x1^4+x2^4+2*(x1^2)*(x2^2)-4*x1+3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // y0_TB
            // 
            this.y0_TB.Location = new System.Drawing.Point(239, 49);
            this.y0_TB.Name = "y0_TB";
            this.y0_TB.Size = new System.Drawing.Size(29, 20);
            this.y0_TB.TabIndex = 82;
            this.y0_TB.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(220, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 20);
            this.label7.TabIndex = 83;
            this.label7.Text = ";";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(168, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 20);
            this.label11.TabIndex = 84;
            this.label11.Text = "(";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(274, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 20);
            this.label12.TabIndex = 85;
            this.label12.Text = ")";
            // 
            // HookeDjieves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.y0_TB);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Yopt_TB);
            this.Controls.Add(this.Xopt_TB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.clc_Button);
            this.Controls.Add(this.pnImg);
            this.Controls.Add(this.E_TB);
            this.Controls.Add(this.dx_TB);
            this.Controls.Add(this.x0_TB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Name = "HookeDjieves";
            this.Size = new System.Drawing.Size(950, 570);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox E_TB;
        private System.Windows.Forms.TextBox dx_TB;
        private System.Windows.Forms.TextBox x0_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnImg;
        private System.Windows.Forms.Button clc_Button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Xopt_TB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Yopt_TB;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.TextBox y0_TB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}
