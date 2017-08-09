namespace Tanks
{
    partial class StartForm
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
            this.numericUpDownTanks = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownApples = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSpeed = new System.Windows.Forms.NumericUpDown();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTanks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownApples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownTanks
            // 
            this.numericUpDownTanks.Location = new System.Drawing.Point(120, 39);
            this.numericUpDownTanks.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTanks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTanks.Name = "numericUpDownTanks";
            this.numericUpDownTanks.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownTanks.TabIndex = 0;
            this.numericUpDownTanks.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDownApples
            // 
            this.numericUpDownApples.Location = new System.Drawing.Point(120, 77);
            this.numericUpDownApples.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownApples.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownApples.Name = "numericUpDownApples";
            this.numericUpDownApples.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownApples.TabIndex = 1;
            this.numericUpDownApples.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDownSpeed
            // 
            this.numericUpDownSpeed.Location = new System.Drawing.Point(120, 116);
            this.numericUpDownSpeed.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSpeed.Name = "numericUpDownSpeed";
            this.numericUpDownSpeed.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownSpeed.TabIndex = 2;
            this.numericUpDownSpeed.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Location = new System.Drawing.Point(76, 164);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(75, 23);
            this.buttonStartGame.TabIndex = 3;
            this.buttonStartGame.Text = "Start game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of tanks:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of apples:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Speed:";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 230);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.numericUpDownSpeed);
            this.Controls.Add(this.numericUpDownApples);
            this.Controls.Add(this.numericUpDownTanks);
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.Text = "Tanks";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTanks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownApples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownTanks;
        private System.Windows.Forms.NumericUpDown numericUpDownApples;
        private System.Windows.Forms.NumericUpDown numericUpDownSpeed;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}