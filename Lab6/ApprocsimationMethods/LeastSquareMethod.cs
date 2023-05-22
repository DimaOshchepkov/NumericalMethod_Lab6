using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.ApprocsimationMethods
{
    class LeastSquareMethod : InterpolationMethod
    {
        Func<double, double> mapA;
        Func<double, double> mapB;

        Function func;
        LeastSquareMethod(Function f, Func<double, double> mapA, Func<double, double> mapB)
        {
            this.mapA = mapA;
            this.mapB = mapB;
            func = f;
        }

        public double GetValue(double x)
        {
            
        }
    }
}

