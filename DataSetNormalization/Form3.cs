using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataSetNormalization
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            SetUpContent();
        }
        private void SetUpContent()
        {
            if (GlobalVar.ConfingPath == null) { richTextBox1.Text = "Nie Podano Pliku konfiguaryjnego"; }
            if (GlobalVar.FilePath == null) { richTextBox1.Text = "Nie Podano Pliku"; }
            if (GlobalVar.Set != null)
            {
                if (GlobalVar.Set.ListaLinii.Count == 0)
                {
                    richTextBox1.Text = "Plik Konfiguracyjny nie pasuje do pliku, albo Plik jest pusty";
                }
                else
                {

                    for (int i = 0; i < GlobalVar.Set.ConfingFile.DataStetSize; i++)
                    {
                        checkedListBox1.Items.Add(i);
                    }
                    
                    Normalize_Extended_button.Enabled = true;

                }
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.Items.Count != 0)
            {
                if (checkBox3.Checked)
                {
                    //zaznacza wszyskie
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }

                else {
                    //odzancza
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                    checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void Normalize_Extended_button_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count==0)
            {
                return;
            }
            var min = decimal.ToInt32(numericUpDown1.Value);
            var max = decimal.ToInt32(numericUpDown2.Value);
            if (min < max)
            {
                var i = 0;
                string save = JsonConvert.SerializeObject(GlobalVar.Set.ConfingFile);
                GlobalVar.Set.ConfingFile.RepeatingDataIndex = new int[checkedListBox1.Items.Count-checkedListBox1.CheckedItems.Count];
                foreach (var item in checkedListBox1.Items)
                {
                    if (!checkedListBox1.CheckedItems.Contains(item))
                    {
                        GlobalVar.Set.ConfingFile.RepeatingDataIndex[i] = int.Parse(item.ToString());
                        i++;
                    }
                }
                GlobalVar.Set.Normalize(min, max);
                GlobalVar.Set.ConfingFile = JsonConvert.DeserializeObject<Confing>(save);
                RefreshPreview();
            }
        }
        private void RefreshPreview()
        {
            richTextBox1.Text = "";
            var txt = "";
            foreach (var item in GlobalVar.Set.ListaLinii)
            {
                txt += item.ToString("-") + "\n";
            }
            richTextBox1.Text = txt;
        }

    }
}
