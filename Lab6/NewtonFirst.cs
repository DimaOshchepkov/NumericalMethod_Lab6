using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class NewtonFirst : InterpolationMethod
    {
        public NewtonFirst(Function f) : base(f) { }
        private double[] GetTableOfDelta()
        {
            double[,] dy = new double[func.Length, func.Length];
            for(int i = 0; i < dy.GetLength(1); i++)
                dy[i, 0] = func.values[i];

            for (int i = 1; i < dy.GetLength(1); i++)
                for (int j = 0; j < dy.GetLength(1) - i; j++)
                    dy[j, i] = dy[j+1, i-1] - dy[j, i - 1];

            double[] ou = new double[dy.GetLength(0)];
            for (int i = 0; i < dy.GetLength(0); i++)
                ou[i] = dy[0, i];

            return ou;
        }

        public override double GetValue(double x)
        {
            double[] dy = GetTableOfDelta();
            double h = func.args.Max() - func.args.Min();
            double h_powered = 1;
            double n_fact = 1;

            double value = func.values[0];
            for (int i = 1; i < func.Length; i++)
            {
                n_fact *= i;
                h_powered *= h_powered;

                double mult = dy[i] / n_fact * h_powered;
                for (int j = 0; j < i; j++)
                    mult *= (x - func.args[j]);

                value += mult;
            }
            return value;
        }
    }
}
