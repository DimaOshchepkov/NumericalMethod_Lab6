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
        
        public Function Map(Function f)
        {
            double[] a = (f.args.Clone() as double[]);
            double[] b = f.values.Clone() as double[];
            a = a.Select(x => mapX(x)) as double[];
            b = b.Select(y => mapY(y)) as double[];

            return new Function(a, b);
        }
        public abstract double Return(double x, double a, double b);
        
    }
}
