using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public abstract class IMapperXY
    {
        protected Func<double, double> mapX { get; set; }
        protected Func<double, double> mapY { get; set; }
        protected Func<double, double> mapA { get; set; }
        protected Func<double, double> mapB { get; set; }
        protected LinearFunctionLSM linearFunctionLSM { get; set; }
        public (double a, double b) param;
        
        public Function Map(Function f)
        {
            double[] a = (double[])f.args.Clone();
            double[] b = (double[])f.values.Clone();
            a = a.Select(x => mapX(x)).ToArray<double>();
            b = b.Select(y => mapY(y)).ToArray<double>(); 

            return new Function(a, b);
        }
        public abstract double Return(double x, double a, double b);
        
    }
}
