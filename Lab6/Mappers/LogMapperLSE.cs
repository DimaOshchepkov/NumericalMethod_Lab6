using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class LogMapperLSE : IMapperXY
    {
        public LogMapperLSE()
        {
            mapX = x => { if (x < 0) throw new ArgumentException("x должно быть больше 0"); return Math.Log(x); };
            mapY = y => y;
            mapA = a => a;
            mapB = b => b;
            linearFunctionLSM = new LinearFunctionLSM();
        }
        public override double Return(double x, double A, double B)
        {
            double a = mapA(A);
            double b = mapB(B);
            param = (a, b);
            return a * Math.Log(x) + b;
        }

        public override string ToString() => $"{param.a} * ln(x) + {param.b}";
    }
}
