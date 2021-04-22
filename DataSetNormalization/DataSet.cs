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
   public class DataSet
    {
        public List<Linia> ListaLinii;
        public Confing ConfingFile;

        public DataSet(List<Linia> listaLinii, Confing confingFile)
        {
            ListaLinii = listaLinii;
            ConfingFile = confingFile;
        }


        public void Normalize(int min = 0, int max = 1)
        {
                //Knn Extended
            var SlownikWystapien = new List<Dictionary<string, float[]>>();
            //tworzenie słownika wystąpien
            var DanePoNormalizacji = new float[ConfingFile.DataStetSize, 3];
            //dane liczbowych po normalizacji
            var DanePrzedNormalizacja = new float[ConfingFile.DataStetSize, 2];
            //dane liczbowych PRZED normalizacja



            //basic
            List<float[]> ListaKolumn = new List<float[]>();
            //lista lini zmaien na liste kolumn i stringi na floaty

            for (int i = 0; i < ConfingFile.DataStetSize; i++)
            {
                if (ConfingFile.SkipValuesIndex.Contains(i)){continue;}

                float[] Kolumna = new float[ListaLinii.Count];
                Dictionary<string, float[]> przypisz = new Dictionary<string, float[]>();
                
                if (ConfingFile.SymbolicDataIndex.Contains(i)) {
                    przypisz = GenerateDiconary(i);
                }

                for (int j = 0; j < ListaLinii.Count; j++)
                {
                    var AktualnaWartosc = ListaLinii[j].Dane[i];
                    float liczba = 0;
                    
                    if (ConfingFile.SymbolicDataIndex.Contains(i)& przypisz.ContainsKey(AktualnaWartosc)) { 
                        liczba = przypisz[AktualnaWartosc][0];
                        przypisz[AktualnaWartosc][1]++;//większamy licznik wystąpień
                    }
                    else {
                        try
                        {
                            if (AktualnaWartosc.Contains(".")) { AktualnaWartosc = AktualnaWartosc.Replace('.', ','); }
                            liczba = float.Parse(AktualnaWartosc);
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
                ///info danych przed normalizacja
                if (!ConfingFile.SkipValuesIndex.Contains(i) && !ConfingFile.SymbolicDataIndex.Contains(i))
                {                   
                    DanePrzedNormalizacja[i, 0] = Kolumna.Min();
                    DanePrzedNormalizacja[i, 1] = Kolumna.Max();
                }

                ///
                SlownikWystapien.Add(przypisz);
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
            //info danych po noramlizacji
            for (int i = 0; i < ListaKolumn.Count; i++)
            {
                if (!ConfingFile.SkipValuesIndex.Contains(i) && !ConfingFile.SymbolicDataIndex.Contains(i))
                {
                    DanePoNormalizacji[i, 0] = ListaKolumn[i].Average();
                    DanePoNormalizacji[i, 1] = ListaKolumn[i].Min();
                    DanePoNormalizacji[i, 2] = ListaKolumn[i].Max();
                }
            }
            //
            ColumnsToLines(ListaKolumn);
            ConfingFile.IsNormalized = true;
            ConfingFile.DiconaryOfNormalizedSymbols = SlownikWystapien.ToArray();
            ConfingFile.AfterNormalizationNumberInfo = DanePoNormalizacji;
            ConfingFile.BeforeNormalizationNumberInfo = DanePrzedNormalizacja;
        }

        private void ColumnsToLines(List<float[]> ListaKolumn)
        {
            for (int i = 0; i < ListaLinii.Count; i++)
            {
                var licznik = 0;
                for (int j = 0; j < ConfingFile.DataStetSize; j++)
                {
                    if (ConfingFile.SkipValuesIndex.Contains(j)) { continue; }
                    
                    ListaLinii[i].Dane[j] = ListaKolumn[licznik][i].ToString("0.####").Replace(",", ".");
                    licznik++;
                }
            }
        }
        private Dictionary<string, float[]> GenerateDiconary(int indexKolumny)
        {
            Dictionary<string, float[]> przypisz = new Dictionary<string, float[]>();
            HashSet<string> hash = new HashSet<string>();

            for (int p = 0; p < ListaLinii.Count; p++)
            {
                hash.Add(ListaLinii[p].Dane[indexKolumny]);
            }
            //generowanie słownika do zamiany charów na float
            float licznik = 0;
            foreach (var item in hash)
            {
                przypisz.Add(item, new float[2] { licznik, 0 }) ;
                licznik++;
            }
            return przypisz;
        }
        public void SaveConfing(string path)
        {
            string json = JsonConvert.SerializeObject(ConfingFile);
            File.WriteAllText(path, json);
        }
        public void OpenConfing(string path) {
            
            try
            {
                string json = File.ReadAllText(path);
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
                    if (!line.Contains("?") & line.Split(ConfingFile.Speparator).Length == ConfingFile.DataStetSize)
                    {
                        ListaLinii.Add(new Linia(line.Split(ConfingFile.Speparator)));
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
                        kolumna.Add(line.Split(ConfingFile.Speparator));
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
                sw.WriteLine(item.ToString(ConfingFile.Speparator.ToString()));
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
                    StringBuild += ListaLinii[j].Dane[i];
                    StringBuild += ConfingFile.Speparator.ToString();
                }
                sw.WriteLine(StringBuild);
            }
            sw.Close();
        }
        public void DeleteColumn(int index)
        {
            if (ListaLinii[0].Dane.Length==1) return;
             var ListaKolumn = new List<List<string>>();
            for (int j = 0; j < ConfingFile.DataStetSize; j++)
            {
                List<string> kolumna = new List<string>();
                for (int i = 0; i < ListaLinii.Count; i++)
                {
                    kolumna.Add(ListaLinii[i].Dane[j]);                    
                }
                ListaKolumn.Add(kolumna);
            }
            ListaKolumn.RemoveAt(index);
            ListaLinii = new List<Linia>();
            for (int i = 0; i < ListaKolumn[0].Count; i++)
            {
                string[] tmp = new string[ConfingFile.DataStetSize-1];
                for (int j = 0; j < tmp.Length; j++)
                {
                    tmp[j] = ListaKolumn[j][i];
                }
                ListaLinii.Add(new Linia(tmp));
            }

            //update confinga
            ConfingFile.DataStetSize--;
            ConfingFile.DecysionIndex--;
            var tmp2 =ConfingFile.SkipValuesIndex.ToList();///Są lepsze sposoby ale albo dają 1 linijke mniej albo są podatne na błędy
            tmp2.Remove(index);
            ConfingFile.SkipValuesIndex = tmp2.ToArray();

            var tmp1 = ConfingFile.SymbolicDataIndex.ToList();
            tmp1.Remove(index);
            ConfingFile.SymbolicDataIndex = tmp1.ToArray();

            for (int i = 0; i < ConfingFile.SymbolicDataIndex.Length; i++)
            {
                if (ConfingFile.SymbolicDataIndex[i] > index) { ConfingFile.SymbolicDataIndex[i]--; }

            }

            for (int i = 0; i < ConfingFile.SkipValuesIndex.Length; i++)
            {
                if (ConfingFile.SkipValuesIndex[i] > index) { ConfingFile.SkipValuesIndex[i]--; }
            }
        }
    }
}
