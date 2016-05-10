using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Playfair_Cipher
{
    class Encode
    {
        keyTable kt = new keyTable();
        MultiDArray multiD = new MultiDArray();
        public Encode()
        {
            
        }
        string message = "Can you please encode this for me";
        List<string> splitMessage = new List<string>();
        string encodedMessage = "";

        string encode()
        {
            message = message.Replace(" ", String.Empty).ToUpper();
            for (int i = 0; i < message.Length; i+=2)
            {
                if (i == (message.Length -1))
                {
                    //to make sure the last character is part of a digram by appending "X" to the end. Cipher cannot have monograms
                    splitMessage.Add(String.Format("{0}X", message[i]));
                }
                else
                {
                    splitMessage.Add(String.Format("{0}{1}", message[i], message[i + 1]));
                }
            }

            for (int j=0; j<splitMessage.Count; j++)
            {
                char first = splitMessage.ElementAt(j)[0];
                char second = splitMessage.ElementAt(j)[1];
                char encodedFirst;
                char encodedSecond;
                int[] firstCoords = multiD.getIndex(kt.table, first);
                int[] secondCoords = multiD.getIndex(kt.table, second);

                if (firstCoords[0] == secondCoords[0])
                {
                    if (firstCoords[1]+1 >= kt.table.GetLength(1))
                    {
                        encodedFirst = kt.table[firstCoords[0], 0];
                    }
                    else
                    {
                        encodedFirst = kt.table[firstCoords[0], firstCoords[1] + 1];
                    }
                    if (secondCoords[1]+1 >= kt.table.GetLength(1))
                    {
                        encodedSecond = kt.table[secondCoords[0], 0];
                    }
                    else
                    {
                        encodedSecond = kt.table[secondCoords[0], secondCoords[1] + 1];
                    }
                    encodedMessage += String.Format("{0}{1}", encodedFirst, encodedSecond);
                }
                else if (firstCoords[1] == secondCoords[1])
                {
                    if (firstCoords[0] + 1 >= kt.table.GetLength(0))
                    {
                        encodedFirst = kt.table[0, firstCoords[1]];
                    }
                    else
                    {
                        encodedFirst = kt.table[firstCoords[0] + 1, firstCoords[1]];
                    }
                    if (secondCoords[0] + 1 >= kt.table.GetLength(0))
                    {
                        encodedSecond = kt.table[0, secondCoords[1]];
                    }
                    else
                    {
                        encodedSecond = kt.table[secondCoords[0] + 1, secondCoords[1]];
                    }
                    encodedMessage += String.Format("{0}{1}", encodedFirst, encodedSecond);
                }
                else
                {
                    encodedFirst = kt.table[firstCoords[0], secondCoords[1]];
                    encodedSecond = kt.table[secondCoords[0], firstCoords[1]];

                    encodedMessage += String.Format("{0}{1}", encodedFirst, encodedSecond);
                }
            }
            return encodedMessage;
        }
    }
}
