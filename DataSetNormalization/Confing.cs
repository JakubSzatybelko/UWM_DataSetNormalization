using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetNormalization
{
    class Confing
    {
        public char speparator;
        public int DataStetSize;
        public int[] SymbolicDataIndex;
        public  int[] RepeatingDataIndex;
        public Dictionary<int, int[]> MinMaxValues;

        public Confing(char speparator, int dataStetSize, int[] symbolicDataIndex, int[] repeatingDataIndex, Dictionary<int, int[]> minMaxValues)
        {
            this.speparator = speparator;
            DataStetSize = dataStetSize;
            SymbolicDataIndex = symbolicDataIndex;
            RepeatingDataIndex = repeatingDataIndex;
            MinMaxValues = minMaxValues;
        }
    }
}
