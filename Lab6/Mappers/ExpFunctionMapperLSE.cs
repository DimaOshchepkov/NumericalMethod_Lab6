using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class ExpFunctionMapperLSE : IMapperXY
    {
        public ExpFunctionMapperLSE()
        {
            mapX = x => x;
            mapY = (y) => { if (y < 0) throw new ArgumentException("у должно быть больше 0"); return Math.Log(y); };
            mapA = a => Math.Exp(a);
            mapB = b => b;
            linearFunctionLSM = new LinearFunctionLSM();
        }
        public override double Return(double x, double A, double B)
        {
            double a = mapA(B);
            double b = mapB(A);
            param = (a, b);
            return a * Math.Exp(x * b);
        }

        public override string ToString() => $"{param.a} * e^{param.b}";
    }
}
