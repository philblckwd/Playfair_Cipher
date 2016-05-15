using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Playfair_Cipher
{
    class RandomCipher
    {
        public RandomCipher()
        {
            randCipher();
        }

        public char[,] randomCipher = new char[5, 5];
        List<char> alphabetList = new List<char>();

        public char[,] randCipher()
        {
            Random rand = new Random();
            int n = 0;
            string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            for (int f = 0; f < alphabet.Length; f++)
            {
                alphabetList.Add(alphabet[f]);
            }
            for (int i = 0; i < randomCipher.GetLength(0); i++)
            {
                for (int j = 0; j < randomCipher.GetLength(1); j++)
                {
                    int next = rand.Next(0, alphabetList.Count);
                    randomCipher[i, j] = alphabetList[next];
                    alphabetList.Remove(alphabetList[next]);
                }
            }
            return randomCipher;
        }
    }
}
