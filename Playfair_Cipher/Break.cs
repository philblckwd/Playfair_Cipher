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
        BigramFreq freq = new BigramFreq();
        PlainTextPool reference = new PlainTextPool();

        //using encoded message of original string and key/Cipher I use in encode.cs and keytable.cs.
        string encodedMessage = "MBEBXFANADZGROAQLUBWRPPRDNLRCOPKDEIUDMCTWMTMQCSAYPAFMBEBXFANADVKXFODKFBPIVRPPRDNLRCOKVDILEVKANQNPVPRHBPBOEEXOQWBFVRVAKSCXEPYDRCTUPMAZBXEIXESXLRKDEDBLALDXVDMEXXEMKYVYVRPHAANVXCRRXBTMKOMOEOCDPODXFANADDQVOGPXM"; 
        List<string> splitMessage = new List<string>();

        int n = 0;
        double total = 0;
        public double score = 0;
        public double prevScore = 0;
        public double final;

        public string currDecoded;
        List<string> duplicates = new List<string>();
        List<string> decryptedBigrams = new List<string>();

        public void breakLoop()
        {
            char[,] originalCipher = randCipher.randCipher();
            char[,] alteredCipher = new char[5, 5];
            reference.reference();

            while (n < 30)
            {
                total = 0;
                decryptedBigrams.Clear();

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
                    decryptedBigrams.Add(String.Format("{0}{1}", currDecoded[k], currDecoded[k + 1]));
                }

                foreach (string item in decryptedBigrams)
                {
                    if (reference.bigramFreq.ContainsKey(item))
                    {
                        total += reference.bigramFreq[item];
                    }
                }
                score = total;

                n++;
            }
            if (score > prevScore)
            {
                final = score;
            }
            else
            {
                final = prevScore;
            }
        }
    }
}
