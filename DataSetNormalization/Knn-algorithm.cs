using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSetNormalization
{
    public delegate List<double[]> Metryka(DataSet DS, Linia Probka);
   public static class Knn_algorithm
    {
        static public string Klasyfikuj(DataSet DS, Linia Probka,int n, Metryka m)
        {
            List<double[]> odl = m(DS,Probka);
            odl=odl.OrderBy(arr => arr[0]).ToList();//odl(odległość,index wiersza)
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
            if (nirestnejbers.Values.Count>1)//ilość wystąpien danego klasyfikatora w n sąsiadach
            {
                var max = nirestnejbers.Values.Max();
                int howManyMax = 0;
                foreach (var item in nirestnejbers)
                {
                    if (item.Value == max) howManyMax++;
                    
                }
                if (howManyMax > 1) return null;//kiedy jest więcej niż 1 maximum
                var myKey = nirestnejbers.FirstOrDefault(x => x.Value == max).Key;
                return myKey;

            }
            return nirestnejbers.Keys.First();
        }


    }
    public class Metryki
    {
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
    }
}
