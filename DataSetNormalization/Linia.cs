using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataSetNormalization
{
    class Linia
    {
        ///obiekt = Linia 
            public string[] Dane;

            public Linia(string[] dane)
            {
                Dane = dane;
            }

            public string ToString(string separator)
            {

                return String.Join(separator, Dane);
            }
        
    }
}
