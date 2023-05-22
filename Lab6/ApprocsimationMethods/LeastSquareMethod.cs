using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.ApprocsimationMethods
{
    class LeastSquareMethod : InterpolationMethod
    {
        (double a, double b, Func<double, double> mapX) param;
        public LeastSquareMethod(Function f, IFunctionApprocsimationLSM funcAppr)
        {
            param = funcAppr.GetParams(f);
        }

        public double GetValue(double x)
        {
            x = param.mapX(x);
            return param.a * Math.Pow(x, param.b);
        }
    }
}

