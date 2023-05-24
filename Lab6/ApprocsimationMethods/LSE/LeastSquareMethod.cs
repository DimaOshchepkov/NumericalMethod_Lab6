using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.ApprocsimationMethods
{
    class LeastSquareMethod : InterpolationMethod
    {
        public (double A, double B) param { get; private set; }
        IMapperXY mapper;
        Function func;
        IFunctionApprocsimationLSM funcAppr;
        public LeastSquareMethod(Function f, IFunctionApprocsimationLSM funcAppr)
        {
            this.func = f;
            this.funcAppr = funcAppr;
            param = funcAppr.GetParams(f);
        }

        public LeastSquareMethod(Function f, LinearFunctionLSM funcAppr, IMapperXY mapper)
        {
            this.func = f;
            this.mapper = mapper;
            this.funcAppr = funcAppr;

            Function func = mapper.Map(this.func);
            param = funcAppr.GetParams(func);

            
            
        }

        public void SetMapper(IMapperXY mapperXY)
        {
            this.mapper = mapperXY;

            Function func = mapper.Map(this.func);
            param = this.funcAppr.GetParams(func);
        }

        public double GetValue(double x)
        {
            if (mapper == null)
                return param.A * x + param.B;

            return mapper.Return(x, param.A, param.B);
        }

        public double GetRRS()
        {
            double sum = 0;
            for (int i = 0; i < this.func.Length; i++)
                sum += Math.Pow(func.values[i] - GetValue(func.args[i]), 2);

            return sum;
        }

        public override string ToString()
        {
            if (mapper == null)
                return funcAppr.ToString();

            return mapper.ToString();
        }
    }
}

