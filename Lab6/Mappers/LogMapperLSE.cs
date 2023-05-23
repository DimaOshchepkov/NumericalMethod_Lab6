﻿using System;
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
            mapX = x => Math.Log(x);
            mapY = y => y;
            mapA = a => a;
            mapB = b => b;
            linearFunctionLSM = new LinearFunctionLSM();
        }
        public override double Return(double x, double A, double B)
        {
            double a = mapA(A);
            double b = mapB(B);
            return a * Math.Log(x) + b;
        }
    }
}
