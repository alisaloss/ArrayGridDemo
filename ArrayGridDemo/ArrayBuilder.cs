using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayGridDemo
{
    public static class ArrayBuilder
    {
        // Builds a sample 2D array of doubles
        public static double[,] BuildSampleArray(int rows, int cols)
        {
            var array = new double[rows, cols];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    array[r, c] = r * 100 + c;
            return array;
        }
    }

}
