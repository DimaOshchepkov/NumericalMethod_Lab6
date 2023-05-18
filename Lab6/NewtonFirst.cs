﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class NewtonFirst : NewtonInterpolation
    {
        Function func;
        public NewtonFirst(Function f){
            func = f;
        }

        public override double GetValue(double x)
        {
            double[,] dy = GetTableOfDelta(this.func);
            double h = (func.args.Max() - func.args.Min()) / (func.Length - 1);
            double n_fact = 1;

            double value = func.values[0];
            for (int i = 1; i < func.Length; i++)
            {
                n_fact *= i;

                double mult = dy[0, i] / n_fact;
                for (int j = 0; j < i; j++)
                    mult *= (x - func.args[j])/h;

                value += mult;
            }
            return value;
        }
    }
}
