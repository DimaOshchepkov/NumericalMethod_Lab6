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
        public NewtonSecond(Function f)
        {
            func = f;
        }

        public override double GetValue(double x)
        {
            double[,] dy = GetTableOfDelta(this.func);
            double h = (func.args.Max() - func.args.Min()) / (func.Length - 1);
            double n_fact = 1;

            double value = func.values[func.Length - 1];
            for (int i = func.Length - 1; i > 0; i--)
            {
                n_fact *= (func.Length - i);

                double mult = dy[i - 1, dy.GetLength(0) - i] / n_fact;
                for (int j = func.Length - 1; j >= i; j--)
                    mult *= (x - func.args[j]) / h;

                value += mult;
            }
            return value;
        }
    }
}
