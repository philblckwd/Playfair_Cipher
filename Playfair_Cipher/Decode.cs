using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Playfair_Cipher
{
    class Decode
    {
        public Decode()
        {

        }

        keyTable kt = new keyTable();
        MultiDArray multiD = new MultiDArray();

        /*string encodedMessage = "DLQLNVLAXMDEOMRODNODZBMKASEIXM";*/
        public string decodedMessage = "";

        public void decode(char[,] cipher, string encoded)
        {
            List<string> splitMessage = new List<string>();

            for (int i=0; i< encoded.Length; i+=2)
            {
                splitMessage.Add(String.Format("{0}{1}", encoded[i], encoded[i + 1]));
            }
            for (int j = 0; j < splitMessage.Count; j++)
            {
                char first = splitMessage.ElementAt(j)[0];
                char second = splitMessage.ElementAt(j)[1];
                char decodedFirst;
                char decodedSecond;
                int[] firstCoords = multiD.getIndex(kt.table, first);
                int[] secondCoords = multiD.getIndex(kt.table, second);

                if (firstCoords[0] == secondCoords[0])
                {
                    if (firstCoords[1] == 0)
                    {
                        decodedFirst = cipher[firstCoords[0], (cipher.GetLength(1)-1)];
                    }
                    else
                    {
                        decodedFirst = cipher[firstCoords[0], firstCoords[1] - 1];
                    }
                    if (secondCoords[1] == 0)
                    {
                        decodedSecond = cipher[secondCoords[0], (cipher.GetLength(1)-1)];
                    }
                    else
                    {
                        decodedSecond = cipher[secondCoords[0], secondCoords[1] - 1];
                    }
                    decodedMessage += String.Format("{0}{1}", decodedFirst, decodedSecond);
                }
                else if (firstCoords[1] == secondCoords[1])
                {
                    if (firstCoords[0] == 0)
                    {
                        decodedFirst = cipher[(cipher.GetLength(0) -1), firstCoords[1]];
                    }
                    else
                    {
                        decodedFirst = cipher[firstCoords[0] - 1, firstCoords[1]];
                    }
                    if (secondCoords[0] == 0)
                    {
                        decodedSecond = cipher[(cipher.GetLength(0) -1), secondCoords[1]];
                    }
                    else
                    {
                        decodedSecond = cipher[secondCoords[0] - 1, secondCoords[1]];
                    }
                    decodedMessage += String.Format("{0}{1}", decodedFirst, decodedSecond);
                }
                else
                {
                    decodedFirst = cipher[firstCoords[0], secondCoords[1]];
                    decodedSecond = cipher[secondCoords[0], firstCoords[1]];

                    decodedMessage += String.Format("{0}{1}", decodedFirst, decodedSecond);
                }
            }
        }

    }
}
