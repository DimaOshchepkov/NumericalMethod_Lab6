using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class NewtonSecond : NewtonInterpolation
    {
        Function func;
        double eps;
        public NewtonSecond(Function f, double eps = 0)
        {
            this.eps = eps;
            func = f;
        }

        public override double GetValue(double x)
        {
            List<List<double>> dy = GetTableOfDelta(this.func, eps);
            double h = (func.args.Max() - func.args.Min()) / (func.Length - 1);
            double n_fact = 1;

            double value = func.values[dy.Count - 1];
            for (int i = dy.Count - 1; i > dy.Count - dy[0].Count; i--)
            {
                n_fact *= (func.Length - i);

                double mult = dy[i - 1][dy.Count - i] / n_fact;
                for (int j = func.Length - 1; j >= i; j--)
                    mult *= (x - func.args[j]) / h;

                value += mult;
            }
            return value;
        }
    }
}
