namespace WindowsFormsApp1
{
    partial class Labs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.LabBTN3 = new System.Windows.Forms.Button();
            this.LabBTN2 = new System.Windows.Forms.Button();
            this.LabBTN1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LabBTN4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LabBTN4);
            this.panel1.Controls.Add(this.LabBTN3);
            this.panel1.Controls.Add(this.LabBTN2);
            this.panel1.Controls.Add(this.LabBTN1);
            this.panel1.Location = new System.Drawing.Point(37, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 357);
            this.panel1.TabIndex = 0;
            // 
            // LabBTN3
            // 
            this.LabBTN3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabBTN3.Location = new System.Drawing.Point(0, 97);
            this.LabBTN3.Name = "LabBTN3";
            this.LabBTN3.Size = new System.Drawing.Size(349, 41);
            this.LabBTN3.TabIndex = 3;
            this.LabBTN3.Text = "Лаб N3";
            this.LabBTN3.UseVisualStyleBackColor = true;
            this.LabBTN3.Click += new System.EventHandler(this.LabBTN3_Click);
            // 
            // LabBTN2
            // 
            this.LabBTN2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabBTN2.Location = new System.Drawing.Point(0, 50);
            this.LabBTN2.Name = "LabBTN2";
            this.LabBTN2.Size = new System.Drawing.Size(349, 41);
            this.LabBTN2.TabIndex = 2;
            this.LabBTN2.Text = "Лаб N2";
            this.LabBTN2.UseVisualStyleBackColor = true;
            this.LabBTN2.Click += new System.EventHandler(this.LabBTN2_Click);
            // 
            // LabBTN1
            // 
            this.LabBTN1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabBTN1.Location = new System.Drawing.Point(0, 3);
            this.LabBTN1.Name = "LabBTN1";
            this.LabBTN1.Size = new System.Drawing.Size(349, 41);
            this.LabBTN1.TabIndex = 1;
            this.LabBTN1.Text = "Лаб N1";
            this.LabBTN1.UseVisualStyleBackColor = true;
            this.LabBTN1.Click += new System.EventHandler(this.LabBTN1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(75, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "ЛАБОРАТОРНЫЕ РАБОТЫ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(142, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "(вариант N3)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(33, 581);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(342, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "TODO: Внимание, запускаемая форма -\r\n текущая форма проекта";
            // 
            // LabBTN4
            // 
            this.LabBTN4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabBTN4.Location = new System.Drawing.Point(0, 144);
            this.LabBTN4.Name = "LabBTN4";
            this.LabBTN4.Size = new System.Drawing.Size(349, 41);
            this.LabBTN4.TabIndex = 4;
            this.LabBTN4.Text = "Лаб N4";
            this.LabBTN4.UseVisualStyleBackColor = true;
            // 
            // Labs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 643);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Labs";
            this.Text = "Labs";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button LabBTN1;
        private System.Windows.Forms.Button LabBTN2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LabBTN3;
        private System.Windows.Forms.Button LabBTN4;
    }
}