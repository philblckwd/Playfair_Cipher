using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Playfair_Cipher
{
    class keyTable
    {
        public keyTable()
        {
            createKeyTable();
        }

        public char[,] table = new char[5, 5];
        List<char> checkDuplicates = new List<char>();
        string key = "Playfair Example".ToUpper();
        
        public char[,] createKeyTable()
        {
            key = key.Replace(" ", String.Empty);
            //i=j for the sake of 5x5 square;
            string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            int n = 0;
            int m = 0;
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (n < key.Length)
                    {
                        if (!(checkDuplicates.Contains(key[n])))
                        {
                            table[i, j] = key[n];
                            checkDuplicates.Add(key[n]);
                        }
                        else
                        {
                            j--;
                        }
                        n++;
                    }
                    else if (m < alphabet.Length)
                    {
                        if (!(checkDuplicates.Contains(alphabet[m])))
                        {
                            table[i, j] = alphabet[m];
                            checkDuplicates.Add(alphabet[m]);
                        }
                        else
                        {
                            j--;
                        }
                        m++;
                    }
                }
            }
            return table;
        }
    }
}
