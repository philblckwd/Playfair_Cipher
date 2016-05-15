using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Playfair_Cipher
{
    class KnownBreak
    {
        Encode encode = new Encode();
        keyTable kt = new keyTable();
        public void keyBreak()
        {
            string plainText = encode.message;
            List<string> plainTextList = encode.prepMessage(plainText);
            string text = "";

            for (int a = 0; a < plainTextList.Count; a++)
            {
                text += plainTextList[a];
            }

            string cipherText = encode.encode(kt.table, plainText);

            MessageBox.Show(text);
            MessageBox.Show(cipherText);

            List<string> adjoiningDigrams = new List<string>();

            for (int i=0; i<text.Length; i+=2)
            {
                if (!(adjoiningDigrams.Contains(String.Format("{0}{1}{2}", text[i + 1], text[i], cipherText[i])) || adjoiningDigrams.Contains(String.Format("{0}{1}{2}", text[i], text[i + 1], cipherText[i + 1]))))
                {
                    if (text[i] == cipherText[i + 1])
                    {
                        adjoiningDigrams.Add(String.Format("{0}{1}{2}", text[i + 1], text[i], cipherText[i]));
                    }
                    else if (text[i + 1] == cipherText[i])
                    {
                        adjoiningDigrams.Add(String.Format("{0}{1}{2}", text[i], text[i + 1], cipherText[i + 1]));
                    }
                }
            }

            /*for (int j = 0; j < adjoiningDigrams.Count; j++)
            {
                if (adjoiningDigrams[j].Contains())
            }*/

            for (int b = 0; b < adjoiningDigrams.Count; b++)
            {
                MessageBox.Show(adjoiningDigrams[b].ToString());
            }
        }
    }
}
