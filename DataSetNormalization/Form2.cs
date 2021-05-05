using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataSetNormalization
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox1.MaxLength = 1;
            Save_butt.Enabled = false;
            numericUpDown2.Maximum = 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                checkedListBox1.Items.Add(i.ToString());
                checkedListBox2.Items.Add(i.ToString());
                checkedListBox3.Items.Add(i.ToString());
            }
            numericUpDown2.Maximum = numericUpDown1.Value-1;
            if (numericUpDown1.Value>=1) Save_butt.Enabled = true;
            else Save_butt.Enabled = false;
        }

        private void Save_butt_Click(object sender, EventArgs e)
        {
            
            var CheckedItemsCount = checkedListBox1.CheckedItems.Count;
            var SkipItemsCount = checkedListBox2.CheckedItems.Count;
            var DeleteItemsCount = checkedListBox3.CheckedItems.Count;

            ///////////////////Syobliczne Wartości
            int[] Symbolic = new int[CheckedItemsCount];
            for (int i = 0; i < CheckedItemsCount; i++)
            {                
                Symbolic[i] = int.Parse(checkedListBox1.CheckedItems[i].ToString());
            }
            ////////Skipowane watrosci
            int[] Skip = new int[SkipItemsCount];
            for (int i = 0; i < SkipItemsCount; i++)
            {
                Skip[i] = int.Parse(checkedListBox2.CheckedItems[i].ToString());
            }
            ////////Usuwane Wartosci
            int[] Delete = new int[DeleteItemsCount];
            for (int i = 0; i < DeleteItemsCount; i++)
            {
                Delete[i] = int.Parse(checkedListBox3.CheckedItems[i].ToString());
            }
            //////////sprawdzanie Sepratora

            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                saveFileDialog1.Filter = "Json| *.Json";
                saveFileDialog1.DefaultExt = "Json";
                saveFileDialog1.ShowDialog();
                var path = saveFileDialog1.FileName;
                if (path != "")
                {
                    char Separator = char.Parse(textBox1.Text);
                    Confing con = new Confing(Separator, checkedListBox1.Items.Count, Symbolic, Skip, Decimal.ToInt32(numericUpDown2.Value));
                    con.ColumnsToDelete = Delete;
                    var Tmp = new DataSet(new List<Linia>(), con);
                    Tmp.SaveConfing(path);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Nie Podano Separatora", "Error 03", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
