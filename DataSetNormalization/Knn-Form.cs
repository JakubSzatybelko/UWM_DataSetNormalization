using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace DataSetNormalization
{
    public partial class Knn_Form : Form
    {
        public Knn_Form()
        {
            InitializeComponent();
            SetUpContent();
        }
        public void SetUpContent()
        {
            ResetTextBox();
            //
            if (!GlobalVar.Set.ConfingFile.IsNormalized)
            {
                checkBox1.Enabled = false;
            }
            
            //
            numericUpDown2.Visible = false;
            label5.Visible = false;
            //
            var metody = typeof(Metryki).GetMethods().Where(a => a.ReturnType == typeof(List<double[]>));
            comboBox1.DataSource = metody.ToList();
            comboBox1.DisplayMember = "Name";
            //
            var metody2 = typeof(Warianty).GetMethods().Where(a => a.ReturnType == typeof(string) &&  a.GetParameters().Length==3);
            comboBox2.DataSource = metody2.ToList();
            comboBox2.DisplayMember = "Name";
        }
        public Wariant GetSelectedWariant()
        {
            Wariant WybranyWariant = Warianty.Pierwszy;
            foreach (var method in typeof(Warianty).GetMethods())
            {
                if (method.Name == comboBox2.SelectedValue)
                {
                    WybranyWariant = (Wariant)Delegate.CreateDelegate(typeof(Wariant), method);
                }
            }
            return WybranyWariant;
        }
        public Metryka GetSelectedMetrka()
        {
            Metryka WybarnaMetryka = Metryki.Ekulides;
            foreach (var method in typeof(Warianty).GetMethods())
            {
                if (method.Name == comboBox1.SelectedValue)
                {
                    WybarnaMetryka = (Metryka)Delegate.CreateDelegate(typeof(Metryka), method);
                }
            }
            return WybarnaMetryka;
        }

        private void VsReszta_butt_Click(object sender, EventArgs e)
        {
            var Wynik=VsReszta(GlobalVar.Set, (int)numericUpDown1.Value, GetSelectedMetrka(), GetSelectedWariant());
            MessageBox.Show("Pokrycie:" + Wynik[0].ToString("0.##") + "%\n" + "Skuteczność:" + Wynik[1].ToString("0.##") + "%");
        }
        private void ResetTextBox()
        {
            var stringbuild = "";
            for (int i = 0; i < GlobalVar.Set.ConfingFile.DataStetSize; i++)
            {
                if (i == GlobalVar.Set.ConfingFile.DecysionIndex) continue;
                if (Array.Exists(GlobalVar.Set.ConfingFile.SymbolicDataIndex, element => element == i))
                {
                    if (GlobalVar.Set.ConfingFile.IsNormalized && i != GlobalVar.Set.ConfingFile.DecysionIndex)
                        stringbuild += GlobalVar.Set.ConfingFile.DiconaryOfNormalizedSymbols[i].Keys.First() + ",";
                    else
                        stringbuild += "a,";

                }
                else
                {
                    stringbuild += "0,";
                }
            }
            stringbuild = stringbuild.Remove(stringbuild.Length - 1);//ostatni przecinek out

            textBox1.Text = stringbuild;

        }
        private void NormalizeLine(string[] linia)
        {
            for (int i = 0; i < linia.Length; i++)
            {
                ///skip
                if (Array.Exists(GlobalVar.Set.ConfingFile.SkipValuesIndex, element => element == i))
                {
                    continue;
                }
                if (Array.Exists(GlobalVar.Set.ConfingFile.SymbolicDataIndex, element => element == i))
                {
                    //czy jest litera
                    float max = GlobalVar.Set.ConfingFile.DiconaryOfNormalizedSymbols[i].Count - 1;//indexowanie zawsze od 0 czili count zwróci max value+1
                    //
                    if (GlobalVar.Set.ConfingFile.DiconaryOfNormalizedSymbols[i].ContainsKey(linia[i]))///jeśli dodana wartość jest w zbiorze
                    {

                        GlobalVar.Set.ConfingFile.DiconaryOfNormalizedSymbols[i][linia[i]][1]++;
                        linia[i] = (GlobalVar.Set.ConfingFile.DiconaryOfNormalizedSymbols[i][linia[i]][0] / max).ToString("0.####");
                    }
                    else
                    {

                        //dodac do słwonika                       
                        GlobalVar.Set.ConfingFile.DiconaryOfNormalizedSymbols[i].Add(linia[i], new float[2] { max + 1, 1 });
                        linia[i] = ((max + 1) / max).ToString("0.####");
                    }

                }
                else
                {
                    //czy jest liczba
                    float SetMin = GlobalVar.Set.ConfingFile.BeforeNormalizationNumberInfo[i, 0];
                    float SetMax = GlobalVar.Set.ConfingFile.BeforeNormalizationNumberInfo[i, 1];
                    float min = GlobalVar.Set.ConfingFile.AfterNormalizationNumberInfo[i, 1];
                    float max = GlobalVar.Set.ConfingFile.AfterNormalizationNumberInfo[i, 2];
                    float tmp;
                    //
                    if (float.TryParse(linia[i], out tmp))
                    {
                        tmp = (tmp - SetMin) / (SetMax - SetMin);
                        tmp = ((max - min) * tmp) + min;

                    }
                    linia[i] = tmp.ToString("0.####");
                }
            }
        }
        public double[] VsReszta(DataSet DS, int n, Metryka m, Wariant w)
        {
            var Pokrycie = 0.0;
            var Skutecznosc = 0.0;
            for (int i = 0; i < GlobalVar.Set.ListaLinii.Count; i++)
            {
                
                var aktualnieTestwanaPróbka= DS.ListaLinii[i];
                DS.ListaLinii.RemoveAt(i);
                var wynikKlasyfikatora = Knn_algorithm.Klasyfikuj(DS, aktualnieTestwanaPróbka, n,m, w);
                if (wynikKlasyfikatora != null)
                {
                    Pokrycie++;
                }
                if (wynikKlasyfikatora != aktualnieTestwanaPróbka.Dane[DS.ConfingFile.DecysionIndex])
                {
                    Skutecznosc++;
                }
                DS.ListaLinii.Insert(i, aktualnieTestwanaPróbka);
                
            }
            
            return new double[2] { (Pokrycie / DS.ListaLinii.Count) * 100, (1 - (Skutecznosc / Pokrycie)) * 100 } ;
        }

        private void Klacyfiy_butt_Click(object sender, EventArgs e)
        {

            var tmp = textBox1.Text.Split(",");
            if (tmp.Length == GlobalVar.Set.ConfingFile.DataStetSize-1) { 
            
                if (checkBox1.Checked) { NormalizeLine(tmp); }
                else {
                    if (GlobalVar.Set.ConfingFile.SymbolicDataIndex.Length != 0) { 
                        MessageBox.Show("Znormalizuj Wiersz!!!!");
                        return;
                    } 
                }

                Linia probka = new Linia(tmp);
                var wynik=Knn_algorithm.Klasyfikuj(GlobalVar.Set, probka, (int)numericUpDown1.Value, GetSelectedMetrka(), GetSelectedWariant());
                DialogResult dialogResult = MessageBox.Show("Wynik to "+wynik+" Czy Dodać próbkę do DataSetu?", "Wynik", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Array.Resize(ref tmp,tmp.Length+1);
                        tmp[tmp.Length-1] = wynik;
                        probka = new Linia(tmp);
                        GlobalVar.Set.ListaLinii.Add(probka);
                    }
            }
        }

        private void Find_Best_butt_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            string BestN = "";
            string BestWariant="";
            string BestMetryka="";
              
            var Best = 0.0;
            for (int i = 1; i < 10; i++)
            {
                foreach (var item in comboBox1.Items)
                {
                    foreach (var item2 in comboBox2.Items)
                    {
                        comboBox1.SelectedItem = item;
                        comboBox2.SelectedItem = item2;
                        var tmp= VsReszta(GlobalVar.Set, i, GetSelectedMetrka(), GetSelectedWariant());
                        if (tmp[1] > Best) { 
                            Best = tmp[1];
                            BestN = i.ToString();
                            BestMetryka = comboBox1.GetItemText(comboBox1.SelectedItem);
                            BestWariant = comboBox2.GetItemText(comboBox2.SelectedItem);

                        }
                        progressBar1.Value += 1;
                        if (tmp[1] == 100) goto Foo;
                    }
                    
                }
            }
            Foo:
            progressBar1.Value = 0;
            MessageBox.Show("Najlepsza Skuteczność: "+Best.ToString("0.##")+"%"+ " Dla Parametrów:\n" +
                "K:"+BestN+"\n"+
                "Wariant:"+BestWariant + "\n" +
                "Metryka:"+BestMetryka);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==4)
            {
                label5.Visible = true;
                numericUpDown2.Visible = true;
            }
            else
            {
                label5.Visible = false;
                numericUpDown2.Visible = false;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Metryki.p = (int)numericUpDown1.Value;
        }
    }

    }
