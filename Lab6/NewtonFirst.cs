using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class NewtonFirst : NewtonInterpolation
    {
        Function func;
        double eps;
        public NewtonFirst(Function f, double eps = 0){
            func = f;
            this.eps = eps;
        }

        public override double GetValue(double x)
        {
            List<List<double>> dy = GetTableOfDelta(this.func, eps);
            Console.WriteLine($"Многочлен степени {dy[0].Count}");
            double h = (func.args.Max() - func.args.Min()) / (func.Length - 1);
            double n_fact = 1;

            double value = func.values[0];
            for (int i = 1; i < dy[0].Count; i++)
            {
                n_fact *= i;

                double mult = dy[0][i] / n_fact;
                for (int j = 0; j < i; j++)
                    mult *= (x - func.args[j])/h;

                value += mult;
            }
            return value;
        }
    }
}
