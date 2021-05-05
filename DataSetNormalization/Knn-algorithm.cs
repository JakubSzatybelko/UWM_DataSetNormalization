using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSetNormalization
{
    public delegate List<double[]> Metryka(DataSet DS, Linia Probka);
    public delegate string Wariant(DataSet DS, List<double[]> odl, int n);
    public static class Knn_algorithm
    {
        static public string Klasyfikuj(DataSet DS, Linia Probka,int n, Metryka m,Wariant w)
        {
            List<double[]> odl = m(DS,Probka);
            odl=odl.OrderBy(arr => arr[0]).ToList();//odl(odległość,index wiersza)
            return w(DS, odl, n);
        }

    }
    public class Metryki
    {
        public static int p=1;
        static public List<double[]> Ekulides(DataSet DS, Linia Probka)
        {
            List<double[]> odleglosci = new List<double[]>();
            double counter = 0;
            foreach (var item in DS.ListaLinii)
            {
                
                double suma = 0;
                for (int i = 0; i < item.Dane.Length; i++)
                {
                    

                    if (Array.Exists(DS.ConfingFile.SkipValuesIndex, element => element == i)||DS.ConfingFile.DecysionIndex==i)
                    {
                        continue;
                    }

                    var liczba = double.Parse(item.Dane[i].Replace(".", ","));
                    var liczbaProbki = double.Parse(Probka.Dane[i].Replace(".", ","));
                    suma += Math.Pow((liczba - liczbaProbki), 2);
                }
                
                odleglosci.Add(new double[2] {(Math.Sqrt(suma)),counter});
                counter++;
            }
            return odleglosci;
        }
        static public List<double[]> Manhattan(DataSet DS, Linia Probka)
        {
            List<double[]> odleglosci = new List<double[]>();
            double counter = 0;
            foreach (var item in DS.ListaLinii)
            {

                double suma = 0;
                for (int i = 0; i < item.Dane.Length; i++)
                {


                    if (Array.Exists(DS.ConfingFile.SkipValuesIndex, element => element == i) || DS.ConfingFile.DecysionIndex == i)
                    {
                        continue;
                    }

                    var liczba = double.Parse(item.Dane[i].Replace(".", ","));
                    var liczbaProbki = double.Parse(Probka.Dane[i].Replace(".", ","));
                    suma += Math.Abs(liczba - liczbaProbki);
                }

                odleglosci.Add(new double[2] { suma, counter });
                counter++;
            }
            return odleglosci;
        }
        static public List<double[]> Czebyszewa(DataSet DS, Linia Probka)
        {
            List<double[]> odleglosci = new List<double[]>();
            double counter = 0;
            foreach (var item in DS.ListaLinii)
            {

                List<double> tab = new List<double>();
                for (int i = 0; i < item.Dane.Length; i++)
                {

                    
                    if (Array.Exists(DS.ConfingFile.SkipValuesIndex, element => element == i) || DS.ConfingFile.DecysionIndex == i)
                    {
                        continue;
                    }

                    var liczba = double.Parse(item.Dane[i].Replace(".", ","));
                    var liczbaProbki = double.Parse(Probka.Dane[i].Replace(".", ","));
                    tab.Add(Math.Abs(liczba - liczbaProbki));
                }

                odleglosci.Add(new double[2] {tab.Max(), counter });
                counter++;
            }
            return odleglosci;
        }
        static public List<double[]> Logaritmiczna(DataSet DS, Linia Probka)
        {
            List<double[]> odleglosci = new List<double[]>();
            double counter = 0;
            foreach (var item in DS.ListaLinii)
            {

                double suma = 0;
                for (int i = 0; i < item.Dane.Length; i++)
                {


                    if (Array.Exists(DS.ConfingFile.SkipValuesIndex, element => element == i) || DS.ConfingFile.DecysionIndex == i)
                    {
                        continue;
                    }

                    var liczba = double.Parse(item.Dane[i].Replace(".", ","));
                    var liczbaProbki = double.Parse(Probka.Dane[i].Replace(".", ","));
                    suma += Math.Abs(Math.Log(liczba) - Math.Log(liczbaProbki));
                }

                odleglosci.Add(new double[2] { suma, counter });
                counter++;
            }
            return odleglosci;
        }
        static public List<double[]> Minkowskiego(DataSet DS, Linia Probka)
        {
            List<double[]> odleglosci = new List<double[]>();
            double counter = 0;
            foreach (var item in DS.ListaLinii)
            {

                double suma = 0;
                for (int i = 0; i < item.Dane.Length; i++)
                {


                    if (Array.Exists(DS.ConfingFile.SkipValuesIndex, element => element == i) || DS.ConfingFile.DecysionIndex == i)
                    {
                        continue;
                    }

                    var liczba = double.Parse(item.Dane[i].Replace(".", ","));
                    var liczbaProbki = double.Parse(Probka.Dane[i].Replace(".", ","));
                    suma += Math.Pow((liczba - liczbaProbki), p);
                }

                odleglosci.Add(new double[2] { (Math.Pow(suma,1/p)), counter });
                counter++;
            }
            return odleglosci;
        }
    }
    public class Warianty {
        static public string Pierwszy(DataSet DS, List<double[]> odl, int n)
        {

            ///// okazuje się że ten sposób jest nawet do 104x szybszy niż z wykorzystaniem linq!!!!!

            Dictionary<string, int> nirestnejbers = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)//count uniqe wystąpiena danej warosci dezyzyjnej
            {
                if (nirestnejbers.ContainsKey(DS.ListaLinii[(int)(odl[i][1])].Dane[DS.ConfingFile.DecysionIndex]))//jeżeli dana warość decyzyjna juz jest
                {
                    nirestnejbers[DS.ListaLinii[(int)(odl[i][1])].Dane[DS.ConfingFile.DecysionIndex]]++;
                }
                else//kiedy nie ma wartosci decyzyjnej w słowniku
                {
                    nirestnejbers.Add(DS.ListaLinii[(int)(odl[i][1])].Dane[DS.ConfingFile.DecysionIndex], 1);
                }
            }
            if (nirestnejbers.Values.Count > 1)//ilość wystąpien uniqalnych klasyfikatorów w n sąsiadach
            {
                var max = nirestnejbers.Values.Max();
                int howManyMax = 0;///sprawdzanie czy istnieje jedno maximum
                foreach (var item in nirestnejbers)
                {
                    if (item.Value == max) howManyMax++;
                }
                if (howManyMax > 1) return null;//kiedy jest więcej niż 1 maximum
                var myKey = nirestnejbers.FirstOrDefault(x => x.Value == max).Key;//pozyskanie wartosci która występuje najczęściej
                return myKey;

            }
            return nirestnejbers.Keys.First();
    }
        static public string Drugi(DataSet DS, List<double[]> odl, int n)
        {

            HashSet<string> uniqe = new HashSet<string>();//unikalne wartości występujące w datasecie
            foreach (var item in DS.ListaLinii)
            {
                uniqe.Add(item.Dane[DS.ConfingFile.DecysionIndex]);
            }
            Dictionary<int, string> Przypisz = new Dictionary<int, string>();//indexowanie unikalnych warosci
            var counter = 0;// słowniki i hashsety nie są indexowalne więc niestety foreach i counter :C
            foreach (var item in uniqe)
            {
                Przypisz.Add(counter, item);
                counter++;
            }
            List<List<double>> OdlegloscSubSets = new List<List<double>>();//odleglość poszczególnych wartosci decyzyjnych
            for (int i = 0; i < Przypisz.Count; i++)//po każdym unikalnym ze słownika
            {
                OdlegloscSubSets.Add(new List<double>());
                for (int j = 0; j < odl.Count; j++)//po wszytkich odległosciach
                {
                    if (DS.ListaLinii[(int)odl[j][1]].Dane[DS.ConfingFile.DecysionIndex]==Przypisz[i])//sprawdzamy jaka jest warość kolejnych odległosci
                    {
                        OdlegloscSubSets[i].Add(odl[j][0]);
                        if (OdlegloscSubSets[i].Count>=n){break;}//ucinam szukanie jeśli juz mamy n odległosci (jest posotrowane więc nie trzeba calosci)
                    }
                   
                }
            }
            
            List<double> SumyOdleglosci=new List<double>();
            foreach (var item in OdlegloscSubSets)
            {
                double suma = 0;
                for (int i = 0; i < item.Count; i++)//może być mniej niż n dlatego tak a nie inaczej
                {
                    suma += item[i];
                }
                SumyOdleglosci.Add(suma);
            }
            if (SumyOdleglosci.Where(s => s == SumyOdleglosci.Min()).Count()>1)//
            {
                return null;
            }
            var indexToReturn =SumyOdleglosci.IndexOf(SumyOdleglosci.Min());

            return Przypisz[indexToReturn];

        }

    }
}
