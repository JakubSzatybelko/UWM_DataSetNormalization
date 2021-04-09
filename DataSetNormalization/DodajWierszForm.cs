using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        }
        private void ResetTextBox()
        {
            var stringbuild = "";
            for (int i = 0; i < GlobalVar.Set.ConfingFile.DataStetSize; i++)
            {
                if (Array.Exists(GlobalVar.Set.ConfingFile.SymbolicDataIndex, element => element == i))
                {
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
                GlobalVar.Set.ListaLinii.Add(new Linia(tmp));
                label1.Text = "Sukces!";
            }
            else
            {
                label1.Text = "Coś poszło nie tak";
            }
            ResetTextBox();
        }
    }
}
