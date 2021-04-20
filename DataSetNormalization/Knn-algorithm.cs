using System;
using System.Collections.Generic;
using System.Text;

namespace DataSetNormalization
{
   public static class Knn_algorithm
    {

        static public List<double> CalculateDistaneEuqides(DataSet DS,Linia Probka)
        {
            List<double> odleglosci = new List<double>();

            foreach (var item in DS.ListaLinii)
            {
                double suma =0;
                for (int i = 0; i < item.Dane.Length; i++)
                {

                    if (Array.Exists(DS.ConfingFile.RepeatingDataIndex, element => element == i))
                    {
                        continue;
                    }

                    var liczba= double.Parse(item.Dane[i].Replace(".",","));
                    var liczbaProbki = double.Parse(Probka.Dane[i].Replace(".", ","));
                    suma += Math.Pow((liczba - liczbaProbki),2);
                }

                odleglosci.Add(Math.Sqrt(suma));
            }

            return odleglosci;
        }

    }
}
