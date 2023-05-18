using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    abstract class NewtonMethod
    {
        protected double[] GetTableOfDelta(Function func)
        {
            double[,] dy = new double[func.Length, func.Length];
            for (int i = 0; i < dy.GetLength(1); i++)
                dy[i, 0] = func.values[i];

            for (int i = 1; i < dy.GetLength(1); i++)
                for (int j = 0; j < dy.GetLength(1) - i; j++)
                    dy[j, i] = dy[j + 1, i - 1] - dy[j, i - 1];

            double[] ou = new double[dy.GetLength(0)];
            for (int i = 0; i < dy.GetLength(0); i++)
                ou[i] = dy[0, i];

            return ou;
        }
    }
}
