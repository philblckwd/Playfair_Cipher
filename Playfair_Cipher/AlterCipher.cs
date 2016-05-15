using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playfair_Cipher
{
    class AlterCipher
    {
        int m = 1;

        public void alter(char[,] next, char[,] previous)
        {
            for (int a = 0; a < previous.GetLength(0); a++)
            {
                for (int b = 0; b < previous.GetLength(1); b++)
                {
                    if (m == 1)
                    {
                        if (b == 0 || b == 2 || b == 4)
                        {
                            if (!(b == previous.GetLength(1) - 1))
                            {
                                next[a, b] = previous[a, b + 2];
                            }
                            else
                            {
                                next[a, b] = previous[a, 0];
                            }
                        }
                        else
                        {
                            if (!(a == previous.GetLength(0) - 1))
                            {
                                next[a, b] = previous[a + 1, b];
                            }
                            else
                            {
                                next[a, b] = previous[0, b];
                            }
                        }
                    }
                    else if (m == 2)
                    {
                        if (b == 0 || b == 2 || b == 4)
                        {
                            if (!(a == 0))
                            {
                                next[a, b] = previous[a - 1, b];
                            }
                            else
                            {
                                next[a, b] = previous[previous.GetLength(0) - 1, b];
                            }
                        }
                        else
                        {
                            if (b == 1)
                            {
                                next[a, b] = previous[a, b + 2];
                            }
                            else
                            {
                                next[a, b] = previous[a, b - 2];
                            }
                        }
                    }
                    else
                    {
                        if (b == 0 || b == 1)
                        {
                            if (!(a == previous.GetLength(0) - 1))
                            {
                                next[a, b] = previous[a + 1, b];
                            }
                            else
                            {
                                next[a, b] = previous[0, b];
                            }
                        }
                        else
                        {
                            if (b == 2 || b == 3)
                            {
                                next[a, b] = previous[a, b + 1];
                            }
                            else
                            {
                                next[a, b] = previous[a, b - 2];
                            }
                        }
                    }
                }
            }
            if (m == 3)
            {
                m = 0;
            }
            m++;
        }
    }
}
