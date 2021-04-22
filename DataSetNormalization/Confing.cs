using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetNormalization
{
    public class Confing
    {
        ///^^^^^^^^ MUST HAVE
        public char Speparator;
        public int DataStetSize;
        public int[] SymbolicDataIndex;
        public int[] SkipValuesIndex;
        public int DecysionIndex;
        public int[] ColumnsToDelete;
        ///Po normalizacji
        public bool IsNormalized;
        public Dictionary<string, float[]>[] DiconaryOfNormalizedSymbols;
        public float[,] AfterNormalizationNumberInfo;
        public float[,] BeforeNormalizationNumberInfo;
        public bool UpdatedConfig = false;
        public Confing(char speparator, int dataStetSize, int[] symbolicDataIndex, int[] skipValuesIndex, int decysionIndex)
        {
            Speparator = speparator;
            DataStetSize = dataStetSize;
            SymbolicDataIndex = symbolicDataIndex;
            SkipValuesIndex = skipValuesIndex;
            DecysionIndex = decysionIndex;
        }

        



    }
}
