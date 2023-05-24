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
            mapX = x => { if (x < 0) throw new ArgumentException("x должно быть больше 0"); return Math.Log(x); };
            mapY = y => { if (y < 0) throw new ArgumentException("y должно быть больше 0"); return Math.Log(y); };
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
