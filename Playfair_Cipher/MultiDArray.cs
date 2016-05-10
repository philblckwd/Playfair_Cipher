using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playfair_Cipher
{
    class MultiDArray
    {
        public int[] getIndex(char[,] matrix, char value)
        {
            int[] matrixCoords = new int[2];
            int r = matrix.GetLength(0); // row
            int c = matrix.GetLength(1); // column

            for (int x = 0; x < r; x++)
            {
                for (int y = 0; y < c; y++)
                {
                    if (matrix[x, y].Equals(value))
                    {
                        matrixCoords[0] = x;
                        matrixCoords[1] = y;
                    }   
                }
            }
            return matrixCoords;
        }
    }
}
