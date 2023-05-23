using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class FractionllyIrrationalMapperLSE : IMapperXY
    {
        public FractionllyIrrationalMapperLSE()
        {
            mapX = x => 1 / x;
            mapY = y => 1 / y;
            mapA = a => a;
            mapB = b => b;
            linearFunctionLSM = new LinearFunctionLSM();
        }
        public override double Return(double x, double A, double B)
        {
            double a = mapA(A);
            double b = mapB(B);
            return x / (a * x + b);
        }
    }
}
