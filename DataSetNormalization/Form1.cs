using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSetNormalization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Text = "";

        }
        private void TryToCreateDataSet() {
            if (GlobalVar.FilePath != null & GlobalVar.ConfingPath != null)
            {
                GlobalVar.Set = new DataSet(new List<Linia>(), null);
                if (checkBox1.Checked)
                {
                    try
                    {
                        GlobalVar.Set.OpenConfing(GlobalVar.ConfingPath);
                        GlobalVar.Set.OpenTxtVerdical(GlobalVar.FilePath);

                        return;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Otwierasz poziomo!! sprawdź czy podałeś dobre pliki", "Error 05", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                if (Path.GetExtension(GlobalVar.FilePath) == ".Json")
                {
                    GlobalVar.Set.OpenConfing(GlobalVar.ConfingPath);
                    GlobalVar.Set.OpenJson(GlobalVar.FilePath);
                }
                else
                {
                    GlobalVar.Set.OpenConfing(GlobalVar.ConfingPath);
                    GlobalVar.Set.OpenRaw(GlobalVar.FilePath);
                }

            }
            ///usunięcie kolumn i ustawienie usuwania kolumn
            if (GlobalVar.Set != null&&GlobalVar.Set.ConfingFile!=null) {
                numericUpDown1.Maximum = GlobalVar.Set.ConfingFile.DataStetSize-1;
                if (GlobalVar.Set.ConfingFile.ColumnsToDelete != null)
                {
                    for (int i = 0; i < GlobalVar.Set.ConfingFile.ColumnsToDelete.Length; i++)
                    {
                        GlobalVar.Set.DeleteColumn(GlobalVar.Set.ConfingFile.ColumnsToDelete[i]);
                    }
                }
            }

        }
        private void Load_File_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.ShowDialog();
            var path = openFileDialog1.FileName;
            GlobalVar.FilePath = path;
            File_name_label.Text = openFileDialog1.SafeFileName;
            TryToCreateDataSet();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

                var path = openFileDialog1.FileName;
                GlobalVar.ConfingPath = path;
                Config_File_Label.Text = openFileDialog1.SafeFileName;
                TryToCreateDataSet();
               
 


        }

        private void Acept_Click(object sender, EventArgs e)
        {
            if (GlobalVar.ConfingPath==null){ View_Data_Box.Text = "Nie Podano Pliku konfiguaryjnego"; }
            if (GlobalVar.FilePath==null){View_Data_Box.Text = "Nie Podano Pliku";}
            if (GlobalVar.Set!=null)
            {
                if (GlobalVar.Set.ListaLinii.Count == 0)
                {
                    View_Data_Box.Text = "Plik Konfiguracyjny nie pasuje do pliku, albo Plik jest pusty";
                }
                else
                {
                    View_Data_Box.Text = "";
                    var txt = "";
                    foreach (var item in GlobalVar.Set.ListaLinii)
                    {
                        txt += item.ToString(" ") + "\n";
                    }
                    View_Data_Box.Text = txt;
                }
            }
        }

        private void Normalize_butt_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Set!=null)
            {
                if (GlobalVar.Set.ConfingFile.IsNormalized&&GlobalVar.Set.ConfingFile.UpdatedConfig)
                {
                    DialogResult dialogResult= MessageBox.Show("Data-Set już znormalizowany, ponowne znormalizowanie moze zmienić dane w Pliku konfugaracyjnym.\n" +
                        "                             Czy chcesz zapisac plik?","Uwaga!!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                    if (dialogResult==DialogResult.Yes)
                    {
                        button2_Click(sender, e);
                    }
                }
                if (GlobalVar.Set.ListaLinii.Count != 0)
                {

                    GlobalVar.Set.Normalize();
                    Acept_Click(sender, e);
                    GlobalVar.Set.ConfingFile.UpdatedConfig = true;
                    label2.Text = "Wykryto zmiane, zalecane zapisanie pliku konfigracyjnego";
                }
            }
        }

        private void Save_butt_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files | *.txt| Json| *.Json|Txt Verdical| *.txt| Json in Line| *.Json";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.ShowDialog();
            var path = saveFileDialog1.FileName;
            var indexZapisu = saveFileDialog1.FilterIndex;
            if (path!="")
            {
                if (indexZapisu==1)
                {
                    GlobalVar.Set.SaveToTxt(path);
                }
                if (indexZapisu == 2)
                {
                    GlobalVar.Set.SaveToJson(path);
                }
                if (indexZapisu == 3)
                {
                    GlobalVar.Set.SaveToTxtVertical(path);

                }
                if (indexZapisu == 4)
                {
                    GlobalVar.Set.SaveToJsonInLine(path);

                }
            }

        }

        private void CreateConfig_Button_Click(object sender, EventArgs e)
        {
            var CreateConfigForm = new Form2();
            CreateConfigForm.Show();
        }

        private void Normalize_Ex_Butt_Click(object sender, EventArgs e)
        {
            var CreateConfigForm = new Form3();
            CreateConfigForm.Show();
            if (GlobalVar.Set.ConfingFile.UpdatedConfig)
            {
                label2.Text = "Wykryto zmiane, zalecane zapisanie pliku konfigracyjnego";
            }
        }

        private void Add_Linie_butt_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Set!=null)
            {
                var AddLineForm = new DodajWierszForm();
                AddLineForm.Show();
            }
            
        }

        private void Remove_col_butt_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Set!=null)
            {
                GlobalVar.Set.DeleteColumn(Convert.ToInt32(numericUpDown1.Value));
                Acept_Click(sender,e);
                GlobalVar.Set.ConfingFile.UpdatedConfig = true;
                label2.Text = "Wykryto zmiane, zalecane zapisanie pliku konfigracyjnego";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Set!=null)
            {
                saveFileDialog1.Filter = "Json| *.Json";
                saveFileDialog1.DefaultExt = "Json";
                saveFileDialog1.ShowDialog();
                var path = saveFileDialog1.FileName;
                if (path != "")
                    GlobalVar.Set.SaveConfing(path);
                label2.Text = "";
                GlobalVar.Set.ConfingFile.UpdatedConfig = false;
            }
        }

        private void Knn_button_Click(object sender, EventArgs e)
        {
            var count = 0.0;
            for (int i = 0; i < GlobalVar.Set.ListaLinii.Count; i++)
            {
                
                var odgl = Knn_algorithm.Klasyfikuj(GlobalVar.Set, GlobalVar.Set.ListaLinii[i], 7, Metryki.Ekulides);//GlobalVar.Set, GlobalVar.Set.ListaLinii[0]
                if (odgl == null || odgl != GlobalVar.Set.ListaLinii[i].Dane[GlobalVar.Set.ConfingFile.DecysionIndex])
                {
                    count++;
                }
            }
            MessageBox.Show((1-(count/GlobalVar.Set.ListaLinii.Count)).ToString());


            
        }
    }
}
