using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataSetNormalization
{
    public partial class DodajWierszForm : Form
    {
        public DodajWierszForm()
        {
            InitializeComponent();
            label1.Text = "";
            ResetTextBox();
            if (GlobalVar.Set.ConfingFile.IsNormalized)
            {
                checkBox1.Enabled = true;
            }

        }
        private void ResetTextBox()
        {
            var stringbuild = "";
            for (int i = 0; i < GlobalVar.Set.ConfingFile.DataStetSize; i++)
            {
                if (Array.Exists(GlobalVar.Set.ConfingFile.SymbolicDataIndex, element => element == i))
                {
                    if (GlobalVar.Set.ConfingFile.IsNormalized && i!=GlobalVar.Set.ConfingFile.DecysionIndex)
                        stringbuild += GlobalVar.Set.ConfingFile.DiconaryOfNormalizedSymbols[i].Keys.First()+",";
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

        private void button1_Click(object sender, EventArgs e)
        {
            var tmp = textBox1.Text.Split(",");
            
            if (tmp.Length==GlobalVar.Set.ConfingFile.DataStetSize)
            {
                if (checkBox1.Checked) { NormalizeLine(tmp); }
                GlobalVar.Set.ListaLinii.Add(new Linia(tmp));
                label1.Text = "Sukces!";
            }
            else
            {
                label1.Text = "Coś poszło nie tak";
            }
            ResetTextBox();
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
                if (Array.Exists(GlobalVar.Set.ConfingFile.SymbolicDataIndex,element => element==i))
                {
                    //czy jest litera
                    float max = GlobalVar.Set.ConfingFile.DiconaryOfNormalizedSymbols[i].Count-1;//indexowanie zawsze od 0 czili count zwróci max value+1
                    //
                    if (GlobalVar.Set.ConfingFile.DiconaryOfNormalizedSymbols[i].ContainsKey(linia[i]))///jeśli dodana wartość jest w zbiorze
                    {
                        
                        GlobalVar.Set.ConfingFile.DiconaryOfNormalizedSymbols[i][linia[i]][1]++;
                        linia[i] = (GlobalVar.Set.ConfingFile.DiconaryOfNormalizedSymbols[i][linia[i]][0] / max).ToString("0.####");
                    }
                    else
                    {

                        //dodac do słwonika                       
                        GlobalVar.Set.ConfingFile.DiconaryOfNormalizedSymbols[i].Add(linia[i], new float[2]{ max+1, 1 });
                        linia[i] = ((max+1)/max).ToString("0.####");
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
                    if(float.TryParse(linia[i], out tmp))
                    {
                        tmp = (tmp - SetMin) / (SetMax - SetMin);                       
                        tmp = ((max - min) * tmp) + min;

                    }
                    linia[i] = tmp.ToString("0.####");
                }
            }
        }
    }
}
