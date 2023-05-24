using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class HyperbolicMapperLSE : IMapperXY
    {
        public HyperbolicMapperLSE()
        {
            mapX = x => { if (x == 0) throw new ArgumentException("x не должно быть равно 0"); return 1 / x; };
            mapY = y => y;
            mapA = a => a;
            mapB = b => b;
            linearFunctionLSM = new LinearFunctionLSM();
        }
        public override double Return(double x, double A, double B)
        {
            double a = mapA(A);
            double b = mapB(B);
            return a / x + b;
        }
    }
}
