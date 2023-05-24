using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class LinearFunctionLSM : IFunctionApprocsimationLSM
    {
        public (double a, double b) param { get; set; }
        public (double a, double b) GetParams(Function f)
        {
            double sum_x = 0;
            double sum_y = 0;
            double sum_x_powered = 0;
            double sum_xy = 0;

            for (int i = 0; i < f.Length; i++)
            {
                sum_x += f.args[i];
                sum_y += f.values[i];
                sum_xy += f.args[i] * f.values[i];
                sum_x_powered += f.args[i] * f.args[i];
            }
            double det = sum_x_powered * f.Length - sum_x * sum_x;
            double det1 = sum_xy * f.Length - sum_y * sum_x;
            double det2 = sum_x_powered * sum_y - sum_x * sum_xy;
            double a = det1 / det, b = det2 / det;
            param = (a, b);
            return (a, b);   
        }

        public override string ToString() => $"{param.a} * x + {param.b}";
    }
}
