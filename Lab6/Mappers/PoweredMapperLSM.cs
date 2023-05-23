using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class PoweredMapperLSM : IMapperXY
    {
        public PoweredMapperLSM()
        {
            mapX = x => Math.Log(x);
            mapY = y => Math.Log(y);
            mapA = a => Math.Exp(a);
            mapB = b => b;
            linearFunctionLSM = new LinearFunctionLSM();
        }
        public override double Return(double x, double A, double B)
        {
            double a = mapA(B);
            double b = mapB(A);
            return a * Math.Pow(x, b);
        }
    }
}
