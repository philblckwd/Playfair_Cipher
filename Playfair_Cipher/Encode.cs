using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Playfair_Cipher
{
    class Encode
    {
        keyTable kt = new keyTable();
        RandomCipher rand = new RandomCipher();
        MultiDArray multiD = new MultiDArray();

        public Encode()
        {
            
        }
        public string message = "I hid my love when young till I Couldn’t bear the buzzing of a fly I hid my love to my despite Till I could not bear to look at light I dare not gaze upon her face But left her memory in each place Where’er I saw a wild flower lie I kissed and bade my love good-bye.";
        List<string> splitMessage = new List<string>();
        string encodedMessage;

        public List<string> prepMessage(string sentence)
        {
            sentence = Regex.Replace(sentence, @"[^a-zA-Z]", "").ToUpper();

            for (int i = 0; i < sentence.Length; i++)
            {
                if (i == 0 || i % 2 == 0)
                {
                    if (i == (sentence.Length - 1))
                    {
                        sentence += "X";
                        splitMessage.Add(String.Format("{0}{1}", sentence[i], sentence[i + 1]));
                    }
                    else if (sentence[i] == sentence[i + 1])
                    {
                        sentence = sentence.Insert(i + 1, "X");
                        splitMessage.Add(String.Format("{0}{1}", sentence[i], sentence[i + 1]));
                    }
                    else
                    {
                        splitMessage.Add(String.Format("{0}{1}", sentence[i], sentence[i + 1]));
                    }
                }
            }
            return splitMessage;
        }

        public string encode(char[,] cipher, string sentence)
        {
            encodedMessage = "";
            splitMessage.Clear();
            prepMessage(sentence);

            for (int j=0; j<splitMessage.Count; j++)
            {
                char first = splitMessage.ElementAt(j)[0];
                char second = splitMessage.ElementAt(j)[1];
                char encodedFirst;
                char encodedSecond;
                int[] firstCoords = multiD.getIndex(cipher, first);
                int[] secondCoords = multiD.getIndex(cipher, second);

                if (firstCoords[0] == secondCoords[0])
                {
                    if (firstCoords[1]+1 >= cipher.GetLength(1))
                    {
                        encodedFirst = cipher[firstCoords[0], 0];
                    }
                    else
                    {
                        encodedFirst = cipher[firstCoords[0], firstCoords[1] + 1];
                    }
                    if (secondCoords[1]+1 >= cipher.GetLength(1))
                    {
                        encodedSecond = cipher[secondCoords[0], 0];
                    }
                    else
                    {
                        encodedSecond = cipher[secondCoords[0], secondCoords[1] + 1];
                    }
                    encodedMessage += String.Format("{0}{1}", encodedFirst, encodedSecond);
                }
                else if (firstCoords[1] == secondCoords[1])
                {
                    if (firstCoords[0] + 1 >= cipher.GetLength(0))
                    {
                        encodedFirst = cipher[0, firstCoords[1]];
                    }
                    else
                    {
                        encodedFirst = cipher[firstCoords[0] + 1, firstCoords[1]];
                    }
                    if (secondCoords[0] + 1 >= cipher.GetLength(0))
                    {
                        encodedSecond = cipher[0, secondCoords[1]];
                    }
                    else
                    {
                        encodedSecond = cipher[secondCoords[0] + 1, secondCoords[1]];
                    }
                    encodedMessage += String.Format("{0}{1}", encodedFirst, encodedSecond);
                }
                else
                {
                    encodedFirst = cipher[firstCoords[0], secondCoords[1]];
                    encodedSecond = cipher[secondCoords[0], firstCoords[1]];

                    encodedMessage += String.Format("{0}{1}", encodedFirst, encodedSecond);
                }
            }
            return encodedMessage;
        }
    }
}
