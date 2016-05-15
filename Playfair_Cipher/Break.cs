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
        RandomCipher randCipher = new RandomCipher();
        Decode decode = new Decode();
        AlterCipher alterCipher = new AlterCipher();

        //using encoded message of original string and key/Cipher I use in encode.cs and keytable.cs.
        string encodedMessage = "MBEBXFANADZGROAQLUBWRPPRDNLRCOPKDEIUDMCTWMTMQCSAYPAFMBEBXFANADVKXFODKFBPIVRPPRDNLRCOKVDILEVKANQNPVPRHBPBOEEXOQWBFVRVAKSCXEPYDRCTUPMAZBXEIXESXLRKDEDBLALDXVDMEXXEMKYVYVRPHAANVXCRRXBTMKOMOEOCDPODXFANADDQVOGPXM"; 
        List<string> splitMessage = new List<string>();
        string decodedMessage;

        int n = 0;
        int score = 0;
        int prevScore = 0;

        string currDecoded;
        List<string> duplicates = new List<string>();

        public void breakLoop()
        {
            char[,] originalCipher = randCipher.randCipher();
            char[,] alteredCipher = new char[5, 5];
            int total = 0;

            while (n < 5)
            {
                total = 0;

                if (n == 0)
                {
                    currDecoded = decode.decode(originalCipher, encodedMessage);
                }
                else if (n == 1)
                {
                    prevScore = score;
                    alterCipher.alter(alteredCipher, originalCipher);
                    currDecoded = decode.decode(alteredCipher, encodedMessage);
                }
                else
                {
                    if (score > prevScore)
                    {
                        originalCipher = alteredCipher;
                        prevScore = score;
                    }

                    alterCipher.alter(alteredCipher, originalCipher);
                    currDecoded = decode.decode(alteredCipher, encodedMessage);
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

                MessageBox.Show(duplicates.Count.ToString());
                duplicates.Clear();
                n++;
                MessageBox.Show(currDecoded.Length.ToString());
                MessageBox.Show(currDecoded);
                MessageBox.Show(score.ToString());
            }
        }
    }
}
