using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace Playfair_Cipher
{
    class PlainTextPool
    {

        public void create()
        {
            string text = "";
            using (StreamReader file = new StreamReader("Text.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    text += Regex.Replace(line, @"[^a-zA-Z]", "").ToUpper();
                }
            }
            using (StreamWriter write = new StreamWriter("plaintext.txt"))
            {
                write.WriteLine(text);
            }
        }

        public Dictionary<string, double> bigramFreq = new Dictionary<string, double>();
        
        public void reference()
        {
            string text = "";
            using (StreamReader read = new StreamReader("plaintext.txt"))
            {
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    text += line;
                }
            }

            List<string> bigrams = new List<string>();
            
            for (int i=0; i < text.Length; i++)
            {
                if (i == 0 || i % 2 == 0)
                {
                    if (i == (text.Length - 1))
                    {
                        text += "X";
                        bigrams.Add(String.Format("{0}{1}", text[i], text[i + 1]));
                        break;
                    }
                    else if (text[i] == text[i + 1])
                    {
                        text = text.Insert(i + 1, "X");
                    }
                }
                bigrams.Add(String.Format("{0}{1}", text[i], text[i + 1]));
            }

            for (int j=0; j<bigrams.Count; j++)
            {
                if (!(bigramFreq.ContainsKey(bigrams[j])))
                {
                    bigramFreq.Add(bigrams[j], 0);
                }
                else
                {
                    bigramFreq[bigrams[j]] += (1.0 / bigrams.Count);
                }
            }
        }
        
        public PlainTextPool()
        {

        }
    }
}
