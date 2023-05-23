using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class ReverseLinearMapperLSE : IMapperXY
    {
        public ReverseLinearMapperLSE()
        {
            mapX = x => x;
            mapY = y => 1/y;
            mapA = a => a;
            mapB = b => b;
            linearFunctionLSM = new LinearFunctionLSM();
        }
        public override double Return(double x, double A, double B)
        {
            double a = mapA(B);
            double b = mapB(A);
            return a * x + b;
        }
    }
}
