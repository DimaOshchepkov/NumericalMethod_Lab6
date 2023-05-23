using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.ApprocsimationMethods
{
    class LeastSquareMethod : InterpolationMethod
    {
        (double a, double b) param;
        IMapperXY mapper;
        public LeastSquareMethod(Function f, IFunctionApprocsimationLSM funcAppr)
        {
            param = funcAppr.GetParams(f);
        }

        public LeastSquareMethod(Function f, IFunctionApprocsimationLSM funcAppr, IMapperXY mapper)
        {
            this.mapper = mapper;
            Function func = mapper.Map(f);
            param = funcAppr.GetParams(func);
        }

        public double GetValue(double x)
        {
            if (mapper == null)
                return param.a * x + param.b;

            return mapper.Return(x, param.a, param.b);
        }
    }
}

