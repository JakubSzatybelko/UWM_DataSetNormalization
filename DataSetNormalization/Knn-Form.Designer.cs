
namespace DataSetNormalization
{
    partial class Knn_Form
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VsReszta_butt = new System.Windows.Forms.Button();
            this.Klacyfiy_butt = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Find_Best_butt = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(62, 59);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(243, 59);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Metryka";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wariant Klasyfikatora";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(414, 59);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "K";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 189);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 23);
            this.textBox1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nowy Wiersz";
            // 
            // VsReszta_butt
            // 
            this.VsReszta_butt.Location = new System.Drawing.Point(562, 44);
            this.VsReszta_butt.Name = "VsReszta_butt";
            this.VsReszta_butt.Size = new System.Drawing.Size(100, 51);
            this.VsReszta_butt.TabIndex = 8;
            this.VsReszta_butt.Text = "1 VS Reszta";
            this.VsReszta_butt.UseVisualStyleBackColor = true;
            this.VsReszta_butt.Click += new System.EventHandler(this.VsReszta_butt_Click);
            // 
            // Klacyfiy_butt
            // 
            this.Klacyfiy_butt.Location = new System.Drawing.Point(116, 236);
            this.Klacyfiy_butt.Name = "Klacyfiy_butt";
            this.Klacyfiy_butt.Size = new System.Drawing.Size(100, 51);
            this.Klacyfiy_butt.TabIndex = 9;
            this.Klacyfiy_butt.Text = "Klasyfikuj Wiersz";
            this.Klacyfiy_butt.UseVisualStyleBackColor = true;
            this.Klacyfiy_butt.Click += new System.EventHandler(this.Klacyfiy_butt_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(289, 189);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(180, 19);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Normalizuj Przed Klasyfikacją";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Find_Best_butt
            // 
            this.Find_Best_butt.Location = new System.Drawing.Point(562, 126);
            this.Find_Best_butt.Name = "Find_Best_butt";
            this.Find_Best_butt.Size = new System.Drawing.Size(100, 60);
            this.Find_Best_butt.TabIndex = 11;
            this.Find_Best_butt.Text = "Znajdź Najlepsze Parametry";
            this.Find_Best_butt.UseVisualStyleBackColor = true;
            this.Find_Best_butt.Click += new System.EventHandler(this.Find_Best_butt_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(562, 192);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(62, 112);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown2.TabIndex = 13;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "P";
            // 
            // Knn_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 321);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Find_Best_butt);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Klacyfiy_butt);
            this.Controls.Add(this.VsReszta_butt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "Knn_Form";
            this.Text = "Knn_Form";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button VsReszta_butt;
        private System.Windows.Forms.Button Klacyfiy_butt;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button Find_Best_butt;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label5;
    }
}