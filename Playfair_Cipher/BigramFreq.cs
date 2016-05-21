using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playfair_Cipher
{
    class BigramFreq
    {
        public BigramFreq()
        {

        }

        string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        //public string[,] bigrams = new string[25, 25];
        public Dictionary<string, int> bigramDict = new Dictionary<string,int>();
        

        public void bigramsDict()
        {
            int a = 0;
            int b = 0;

            while (b < 625)
            {
                for (int c = 0; c < alphabet.Length; c++)
                {
                    bigramDict.Add(String.Format("{0}{1}", alphabet[a], alphabet[c]), 0);
                    b++;
                }
                a++;
            }
        }
        /*public void bigramsArray()
        {
            bigramsList();
            int n = 0;
            for (int i = 0; i < bigrams.GetLength(0); i++)
            {
                for (int j = 0; j < bigrams.GetLength(1); j++)
                {
                    if (n < bigramDict.Count)
                    {
                        bigrams[i, j] = bigramDict(n);
                        n++;
                    }
                }
            }
        }*/
    }
}
