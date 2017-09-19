namespace View
{
    partial class ViewForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBox = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.tankBar = new System.Windows.Forms.TrackBar();
            this.appleBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appleBar)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.Color.Black;
            this.picBox.Location = new System.Drawing.Point(-1, -2);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(600, 600);
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(641, 224);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(118, 35);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "New Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // speedBar
            // 
            this.speedBar.Location = new System.Drawing.Point(641, 71);
            this.speedBar.Maximum = 3;
            this.speedBar.Minimum = 1;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(104, 45);
            this.speedBar.TabIndex = 3;
            this.speedBar.Value = 3;
            this.speedBar.Scroll += new System.EventHandler(this.speedBar_Scroll);
            // 
            // tankBar
            // 
            this.tankBar.Location = new System.Drawing.Point(641, 122);
            this.tankBar.Maximum = 5;
            this.tankBar.Name = "tankBar";
            this.tankBar.Size = new System.Drawing.Size(104, 45);
            this.tankBar.TabIndex = 4;
            this.tankBar.Value = 5;
            this.tankBar.Scroll += new System.EventHandler(this.tankBar_Scroll);
            // 
            // appleBar
            // 
            this.appleBar.Location = new System.Drawing.Point(641, 173);
            this.appleBar.Maximum = 5;
            this.appleBar.Minimum = 1;
            this.appleBar.Name = "appleBar";
            this.appleBar.Size = new System.Drawing.Size(104, 45);
            this.appleBar.TabIndex = 5;
            this.appleBar.Value = 5;
            this.appleBar.Scroll += new System.EventHandler(this.appleBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(651, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Очки: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(653, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Скорость игры:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(653, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Число танков: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(653, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Число яблок:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(624, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "нажмите клавишу SHIFT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(624, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Для просмотра статистики ";
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(872, 591);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.appleBar);
            this.Controls.Add(this.tankBar);
            this.Controls.Add(this.speedBar);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.picBox);
            this.Name = "ViewForm";
            this.Text = "Tanks";
            this.Shown += new System.EventHandler(this.ViewForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ViewForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appleBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.TrackBar tankBar;
        private System.Windows.Forms.TrackBar appleBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

