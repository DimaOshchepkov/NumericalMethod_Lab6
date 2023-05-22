using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class PoweredFunctionLSM : LinearFunctionLSM
    {

        public override (double a, double b) GetParams(Function f)
        {
            var (a, b, _) = base.GetParams(f);
            return (Math.Exp(b), a, (x) => Math.Exp(x));
        }
    }
}
