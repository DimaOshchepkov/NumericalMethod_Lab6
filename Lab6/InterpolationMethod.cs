using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    abstract class InterpolationMethod
    {
        public Function func;
        public InterpolationMethod(Function f)
        {
            func = f;
        }
        public abstract double GetValue(double x);
    }
}
