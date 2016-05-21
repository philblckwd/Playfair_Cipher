using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playfair_Cipher
{
    class AlterCipher
    {
        int m = 0;
        int n = 0;
        int x = 0;

        public void alter(char[,] next, char[,] previous)
        {
            if (x == 0 || x % 2 == 0)
            {
                for (int i=0; i<previous.GetLength(0); i++)
                {
                    for (int j=0; j<previous.GetLength(1); j++)
                    {
                        if (i == m)
                        {
                            if (!(i == previous.GetLength(0) - 1))
                            {
                                next[i, j] = previous[i + 1, j];

                            }
                            else
                            {
                                next[i, j] = previous[0, j];
                            }
                        }
                        else if (i-1 == m)
                        {
                            next[i, j] = previous[i - 1, j];
                        }
                        else
                        {
                            next[i, j] = previous[i, j];
                        }
                    }
                }
                if (m == previous.GetLength(0) - 1)
                {
                    m = 0;
                }
                else
                {
                    m++;
                }
            }
            else
            {
                for (int i=0; i<previous.GetLength(0); i++)
                {
                    for (int j=0; j<previous.GetLength(1); j++)
                    {
                        if (j == n)
                        {
                            if (!(j == previous.GetLength(1) - 1))
                            {
                                next[i, j] = previous[i, j + 1];
                            }
                            else
                            {
                                next[i, j] = previous[i, 0];
                            }
                        }
                        else if (j - 1 == n)
                        {
                            next[i, j] = previous[i, j-1];
                        }
                        else
                        {
                            next[i, j] = previous[i, j];
                        }
                    }
                }
                if (n == previous.GetLength(1) - 1)
                {
                    n = 0;
                }
                else
                {
                    n++;
                }
            }
            x++;
        }
    }
}
