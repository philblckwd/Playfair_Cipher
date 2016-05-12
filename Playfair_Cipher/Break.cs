using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Playfair_Cipher
{
    class Break
    {
        public Break()
        {

        }
        Random rand = new Random();
        MultiDArray multiD = new MultiDArray();
        RandomCipher randCipher = new RandomCipher();
        Decode decode = new Decode();
        keyTable kt = new keyTable();

        //using encoded message of original string and key/Cipher I use in encode.cs and keytable.cs.
        string encodedMessage = "DLQLNVLAXMDEOMRODNODZBMKASEIXM"; //make into user input.
        List<string> splitMessage = new List<string>();
        string decodedMessage;

        int n = 0;
        int m = 0;
        int score = 0;
        int prevScore = 0;

        void alterCipher(char[,] next, char[,] previous)
        {
            for (int a=0; a<previous.GetLength(0); a++)
            {
                for (int b=0; b<previous.GetLength(1); b++)
                {
                    if (m == 0 || m % 2 == 0)
                    {
                        if (!(a == previous.GetLength(0) - 1))
                        {
                            next[a,b] = previous[a + 1,b];
                        }
                        else
                        {
                            next[a, b] = previous[0, b];
                        }
                    }
                    else
                    {
                        if (!(b == previous.GetLength(1) -1))
                        {
                            next[a, b] = previous[a, b + 1];
                        }
                        else
                        {
                            next[a, b] = previous[a, 0];
                        }
                    }
                }
            }
            m++;
        }

        public string currDecoded;

        public void breakLoop()
        {
            List<string> duplicates = new List<string>();
            char[,] originalCipher = randCipher.randCipher();
            char[,] alteredCipher = new char[5, 5];
            int total = 0;
            char[,] test = new char[5,5];
            while (n < 5)
            {
                prevScore = score;
                if (n == 0)
                {
                    decode.decode(originalCipher, encodedMessage);
                    currDecoded = decode.decodedMessage;
                }
                else
                {
                    alterCipher(alteredCipher, originalCipher);
                    decode.decode(alteredCipher, encodedMessage);
                    currDecoded = decode.decodedMessage;
                }
                for (int k = 0; k < currDecoded.Length; k += 2)
                {
                    if (!(duplicates.Contains(String.Format("{0}{1}", currDecoded[k], currDecoded[k + 1])) || duplicates.Contains(String.Format("{0}{1}", currDecoded[k + 1], currDecoded[k]))))
                    {
                        duplicates.Add(String.Format("{0}{1}", currDecoded[k], currDecoded[k + 1]));
                    }
                    else
                    {
                        total += 1;
                    }
                }

                score = total;
                total = 0;
                if (score > prevScore)
                {
                    originalCipher = alteredCipher;
                    alteredCipher = new char[5,5];
                }
                duplicates.Clear();
                n++;
                //testing if the method works, currently not.
                MessageBox.Show(score.ToString());
                MessageBox.Show(currDecoded);
            }
        }
    }
}
