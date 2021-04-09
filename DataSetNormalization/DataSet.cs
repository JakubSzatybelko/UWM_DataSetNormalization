using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace DataSetNormalization
{
    class DataSet
    {
        public List<Linia> ListaLinii;
        public Confing ConfingFile;

        public DataSet(List<Linia> listaLinii, Confing confingFile)
        {
            ListaLinii = listaLinii;
            ConfingFile = confingFile;
        }

        /// Uładnić KOD!!!!!!!!!!!!!!!!!!!
        //Open+
        //Normalize Rzutowanie zakresu Normalizacji

        public void Normalize(int min=0,int max=1)
        {
            List<float[]> ListaKolumn = new List<float[]>();
            //lista lini zmaien na liste kolumn i stringi na floaty

            for (int i = 0; i < ConfingFile.DataStetSize; i++)
            {
                if (ConfingFile.RepeatingDataIndex.Contains(i)){continue;}

                float[] Kolumna = new float[ListaLinii.Count];
                Dictionary<string, float> przypisz = new Dictionary<string, float>();
                
                if (ConfingFile.SymbolicDataIndex.Contains(i)) {
                    przypisz = GenerateDiconary(i);
                }

                for (int j = 0; j < ListaLinii.Count; j++)
                {
                    var AtualnaWartosc = ListaLinii[j].Dane[i];
                    float liczba = 0;
                    if (AtualnaWartosc.Contains(".")) { AtualnaWartosc = AtualnaWartosc.Replace('.', ','); }
                    if (ConfingFile.SymbolicDataIndex.Contains(i)) { liczba = przypisz[AtualnaWartosc]; }
                    else {
                        try
                        {
                            liczba = float.Parse(AtualnaWartosc);
                        }
                        catch (System.FormatException)
                        {
                            MessageBox.Show("Plik konfiguracyjny podaje złe indexy danych symbolicznych", "Error 04",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return;
                        }
                        
                    }

                    Kolumna[j] = liczba;                    
                }
                ListaKolumn.Add(Kolumna);
            }
            foreach (var item in ListaKolumn)
            {
                var SetMax = item.Max();
                var SetMin = item.Min();
                for (int i = 0; i < item.Length; i++)
                {           
                    item[i] = (item[i] - SetMin) / (SetMax - SetMin);
                    //extended
                    item[i] = ((max - min) * item[i]) + min;
                }
            }
            ColumnsToLines(ListaKolumn);
        }

        private void ColumnsToLines(List<float[]> ListaKolumn)
        {
            for (int i = 0; i < ListaLinii.Count; i++)
            {
                var licznik = 0;
                for (int j = 0; j < ConfingFile.DataStetSize; j++)
                {
                    if (ConfingFile.RepeatingDataIndex.Contains(j)) { continue; }
                    
                    ListaLinii[i].Dane[j] = ListaKolumn[licznik][i].ToString("0.####");
                    licznik++;
                }
            }
        }
        private Dictionary<string, float> GenerateDiconary(int indexKolumny)
        {
            Dictionary<string, float> przypisz = new Dictionary<string, float>();
            HashSet<string> hash = new HashSet<string>();

            for (int p = 0; p < ListaLinii.Count; p++)
            {
                hash.Add(ListaLinii[p].Dane[indexKolumny]);
            }
            //generowanie słownika do zamiany charów na float
            float licznik = 0;
            foreach (var item in hash)
            {
                przypisz.Add(item, licznik);
                licznik++;
            }
            return przypisz;
        }
        public void SaveConfing(string path)
        {
            string json = JsonConvert.SerializeObject(ConfingFile);
            File.WriteAllText(path+".json", json);
        }
        public void OpenConfing(string path) {
            string json = File.ReadAllText(path);
            try
            {
                ConfingFile = JsonConvert.DeserializeObject<Confing>(json);
            }
            catch (Exception)
            {

                MessageBox.Show("Fortmat Pliku jest nie odpowiedni", "Error 00", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public void OpenRaw(string path)
        {
            if (ConfingFile!=null)
            {
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    if (!line.Contains("?") & line.Split(ConfingFile.speparator).Length == ConfingFile.DataStetSize)
                    {
                        ListaLinii.Add(new Linia(line.Split(ConfingFile.speparator)));
                    }

                }
            }

            
        }
        public void OpenJson(string path)
        {
            string json = File.ReadAllText(path);
            try
            {
                ListaLinii = JsonConvert.DeserializeObject<List<Linia>>(json);
            }
            catch (Newtonsoft.Json.JsonSerializationException)
            {

                MessageBox.Show("Fortmat Pliku jest nie odpowiedni", "Error 00", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void OpenTxtVerdical(string path)
        {
            if (ConfingFile != null)
            {
                var lines = File.ReadAllLines(path);
                var ListaKolumn= new List<List<String[]>>();////Big brain Time XD 
                foreach (var line in lines)
                {
                    List<string[]> kolumna = new List<string[]>();
                    if (!line.Contains("?") & lines.Length == ConfingFile.DataStetSize)
                    {
                        kolumna.Add(line.Split(ConfingFile.speparator));
                    }
                    ListaKolumn.Add(kolumna);
                }
                //Przpisanie kolumn na wiersze
                for (int i = 0; i < ListaKolumn[0][0].Length-1; i++)
                {
                    //690x
                    string[] tmp = new string[ConfingFile.DataStetSize];
                    for (int j = 0; j < tmp.Length; j++)
                    {
                        tmp[j] = ListaKolumn[j][0][i];
                    }
                    ListaLinii.Add(new Linia(tmp));
                }
                
                
            }
        }
        public void SaveToJson(string path)
        {
            string json = JsonConvert.SerializeObject(ListaLinii, Formatting.Indented);
            File.WriteAllText(path, json);
        }
        public void SaveToTxt(string path)
        {
            var sw = File.AppendText(path);
            foreach (var item in ListaLinii)
            {
                sw.WriteLine(item.ToString(ConfingFile.speparator.ToString()));
            }
            sw.Close();
        }
        public void SaveToJsonInLine(string path)
        {
            string json = JsonConvert.SerializeObject(ListaLinii);
            File.WriteAllText(path, json);
        }
        public void SaveToTxtVertical(string path)
        {
            var sw = File.AppendText(path);
            for (int i = 0; i < ConfingFile.DataStetSize; i++)
            {
                string StringBuild = "";
                for (int j = 0; j < ListaLinii.Count; j++)
                {
                    StringBuild += ListaLinii[j].Dane[i].ToString();
                    StringBuild += ConfingFile.speparator.ToString();
                }
                sw.WriteLine(StringBuild);
            }
            sw.Close();
        }
        
    }
}
