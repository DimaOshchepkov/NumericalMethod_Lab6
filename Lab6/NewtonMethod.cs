using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    abstract class NewtonInterpolation : InterpolationMethod
    {
        protected List<List<double>> GetTableOfDelta(Function func, double eps = 0)
        {
            List<List<double>> dy = new List<List<double>>();
            for (int i = 0; i < func.Length; i++) 
                dy.Add(new List<double>());

            for (int i = 0; i < func.Length; i++)
                dy[i].Add(func.values[i]);

            for (int i = 1; i < func.Length; i++)
                for (int j = 0; j < func.Length - i; j++)
                {
                    double d = dy[j + 1][i - 1] - dy[j][i - 1];
                    if (Math.Abs(d) < eps)
                    {
                        for (int k = 0; k < j; k++)
                            dy[k].RemoveAt(dy[k].Count - 1);

                        return dy;
                    }
                    dy[j].Add(d);
                }

            return dy;
        }
        abstract public double GetValue(double x);
    }
}
