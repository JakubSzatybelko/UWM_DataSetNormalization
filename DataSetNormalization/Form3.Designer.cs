
namespace DataSetNormalization
{
    partial class Form3
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Normalize_Extended_button = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(361, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(427, 182);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(21, 33);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 23);
            this.numericUpDown1.TabIndex = 1;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(194, 33);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(75, 23);
            this.numericUpDown2.TabIndex = 2;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dolna Wartość Przedziału";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Górna Wartość Przedziału";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(21, 100);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(98, 94);
            this.checkedListBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Wybierz Kolumny Do Normalizacji";
            // 
            // Normalize_Extended_button
            // 
            this.Normalize_Extended_button.Enabled = false;
            this.Normalize_Extended_button.Location = new System.Drawing.Point(150, 151);
            this.Normalize_Extended_button.Name = "Normalize_Extended_button";
            this.Normalize_Extended_button.Size = new System.Drawing.Size(119, 43);
            this.Normalize_Extended_button.TabIndex = 10;
            this.Normalize_Extended_button.Text = "Normalizuj";
            this.Normalize_Extended_button.UseVisualStyleBackColor = true;
            this.Normalize_Extended_button.Click += new System.EventHandler(this.Normalize_Extended_button_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(21, 201);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(118, 19);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.Text = "Zaznacz Wszyskie";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(125, 126);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(219, 19);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Nie Zmieniaj Pliku Konfiguracyjnego";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 253);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.Normalize_Extended_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Normalize_Extended_button;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}