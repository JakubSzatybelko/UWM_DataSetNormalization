
namespace DataSetNormalization
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Load_File = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.View_Data_Box = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.Acept = new System.Windows.Forms.Button();
            this.Normalize_butt = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Save_butt = new System.Windows.Forms.Button();
            this.CreateConfig_Button = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.File_name_label = new System.Windows.Forms.Label();
            this.Config_File_Label = new System.Windows.Forms.Label();
            this.Normalize_Ex_Butt = new System.Windows.Forms.Button();
            this.Remove_col_butt = new System.Windows.Forms.Button();
            this.Add_Linie_butt = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.Knn_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // Load_File
            // 
            this.Load_File.Location = new System.Drawing.Point(24, 45);
            this.Load_File.Name = "Load_File";
            this.Load_File.Size = new System.Drawing.Size(97, 44);
            this.Load_File.TabIndex = 0;
            this.Load_File.Text = "Załaduj Plik";
            this.Load_File.UseVisualStyleBackColor = true;
            this.Load_File.Click += new System.EventHandler(this.Load_File_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 44);
            this.button2.TabIndex = 1;
            this.button2.Text = "Załaduj Plik Kofiguracyjny";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // View_Data_Box
            // 
            this.View_Data_Box.Location = new System.Drawing.Point(395, 45);
            this.View_Data_Box.Name = "View_Data_Box";
            this.View_Data_Box.Size = new System.Drawing.Size(565, 269);
            this.View_Data_Box.TabIndex = 2;
            this.View_Data_Box.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(606, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Podgląd";
            // 
            // Acept
            // 
            this.Acept.Location = new System.Drawing.Point(649, 320);
            this.Acept.Name = "Acept";
            this.Acept.Size = new System.Drawing.Size(97, 44);
            this.Acept.TabIndex = 4;
            this.Acept.Text = "Podgląd";
            this.Acept.UseVisualStyleBackColor = true;
            this.Acept.Click += new System.EventHandler(this.Acept_Click);
            // 
            // Normalize_butt
            // 
            this.Normalize_butt.Location = new System.Drawing.Point(395, 320);
            this.Normalize_butt.Name = "Normalize_butt";
            this.Normalize_butt.Size = new System.Drawing.Size(97, 44);
            this.Normalize_butt.TabIndex = 5;
            this.Normalize_butt.Text = "Normalizuj Szybko";
            this.Normalize_butt.UseVisualStyleBackColor = true;
            this.Normalize_butt.Click += new System.EventHandler(this.Normalize_butt_Click);
            // 
            // Save_butt
            // 
            this.Save_butt.Location = new System.Drawing.Point(24, 311);
            this.Save_butt.Name = "Save_butt";
            this.Save_butt.Size = new System.Drawing.Size(97, 46);
            this.Save_butt.TabIndex = 6;
            this.Save_butt.Text = "Zapisz";
            this.Save_butt.UseVisualStyleBackColor = true;
            this.Save_butt.Click += new System.EventHandler(this.Save_butt_Click);
            // 
            // CreateConfig_Button
            // 
            this.CreateConfig_Button.Location = new System.Drawing.Point(24, 145);
            this.CreateConfig_Button.Name = "CreateConfig_Button";
            this.CreateConfig_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CreateConfig_Button.Size = new System.Drawing.Size(97, 44);
            this.CreateConfig_Button.TabIndex = 7;
            this.CreateConfig_Button.Text = "Stwórz Plik Konfiguracyjny";
            this.CreateConfig_Button.UseVisualStyleBackColor = true;
            this.CreateConfig_Button.Click += new System.EventHandler(this.CreateConfig_Button_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(127, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 19);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Otwieranie Poziome";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // File_name_label
            // 
            this.File_name_label.AutoSize = true;
            this.File_name_label.Location = new System.Drawing.Point(128, 73);
            this.File_name_label.Name = "File_name_label";
            this.File_name_label.Size = new System.Drawing.Size(0, 15);
            this.File_name_label.TabIndex = 9;
            // 
            // Config_File_Label
            // 
            this.Config_File_Label.AutoSize = true;
            this.Config_File_Label.Location = new System.Drawing.Point(128, 123);
            this.Config_File_Label.Name = "Config_File_Label";
            this.Config_File_Label.Size = new System.Drawing.Size(0, 15);
            this.Config_File_Label.TabIndex = 10;
            // 
            // Normalize_Ex_Butt
            // 
            this.Normalize_Ex_Butt.Location = new System.Drawing.Point(498, 321);
            this.Normalize_Ex_Butt.Name = "Normalize_Ex_Butt";
            this.Normalize_Ex_Butt.Size = new System.Drawing.Size(97, 43);
            this.Normalize_Ex_Butt.TabIndex = 11;
            this.Normalize_Ex_Butt.Text = "Normalizuj Extended";
            this.Normalize_Ex_Butt.UseVisualStyleBackColor = true;
            this.Normalize_Ex_Butt.Click += new System.EventHandler(this.Normalize_Ex_Butt_Click);
            // 
            // Remove_col_butt
            // 
            this.Remove_col_butt.Location = new System.Drawing.Point(278, 220);
            this.Remove_col_butt.Name = "Remove_col_butt";
            this.Remove_col_butt.Size = new System.Drawing.Size(97, 44);
            this.Remove_col_butt.TabIndex = 12;
            this.Remove_col_butt.Text = "Usuń kolumnę";
            this.Remove_col_butt.UseVisualStyleBackColor = true;
            this.Remove_col_butt.Click += new System.EventHandler(this.Remove_col_butt_Click);
            // 
            // Add_Linie_butt
            // 
            this.Add_Linie_butt.Location = new System.Drawing.Point(278, 270);
            this.Add_Linie_butt.Name = "Add_Linie_butt";
            this.Add_Linie_butt.Size = new System.Drawing.Size(97, 44);
            this.Add_Linie_butt.TabIndex = 13;
            this.Add_Linie_butt.Text = "Dodaj wiersz";
            this.Add_Linie_butt.UseVisualStyleBackColor = true;
            this.Add_Linie_butt.Click += new System.EventHandler(this.Add_Linie_butt_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(235, 233);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(37, 23);
            this.numericUpDown1.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 46);
            this.button1.TabIndex = 15;
            this.button1.Text = "Zapisz Plik Konfiguracyjny";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Knn_button
            // 
            this.Knn_button.Location = new System.Drawing.Point(804, 318);
            this.Knn_button.Name = "Knn_button";
            this.Knn_button.Size = new System.Drawing.Size(97, 46);
            this.Knn_button.TabIndex = 16;
            this.Knn_button.Text = "K-nn";
            this.Knn_button.UseVisualStyleBackColor = true;
            this.Knn_button.Click += new System.EventHandler(this.Knn_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 369);
            this.Controls.Add(this.Knn_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.Add_Linie_butt);
            this.Controls.Add(this.Remove_col_butt);
            this.Controls.Add(this.Normalize_Ex_Butt);
            this.Controls.Add(this.Config_File_Label);
            this.Controls.Add(this.File_name_label);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.CreateConfig_Button);
            this.Controls.Add(this.Save_butt);
            this.Controls.Add(this.Normalize_butt);
            this.Controls.Add(this.Acept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.View_Data_Box);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Load_File);
            this.Name = "Form1";
            this.Text = "Najlepszy Program Do normalizacji Danych";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Load_File;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox View_Data_Box;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Acept;
        private System.Windows.Forms.Button Normalize_butt;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Save_butt;
        private System.Windows.Forms.Button CreateConfig_Button;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label File_name_label;
        private System.Windows.Forms.Label Config_File_Label;
        private System.Windows.Forms.Button Normalize_Ex_Butt;
        private System.Windows.Forms.Button Remove_col_butt;
        private System.Windows.Forms.Button Add_Linie_butt;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Knn_button;
    }
}

