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
            mapY = y => { if (y == 0) throw new ArgumentException("y не должно быть равно 0"); return 1 / y; };
            mapA = a => a;
            mapB = b => b;
            linearFunctionLSM = new LinearFunctionLSM();
        }
        public override double Return(double x, double A, double B)
        {
            double a = mapA(A);
            double b = mapB(B);
            return 1/(a * x + b);
        }
    }
}
