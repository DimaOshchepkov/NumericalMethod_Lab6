﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    interface IFunctionApprocsimationLSM
    {
        (double a, double b) param { get; set; }
        (double a, double b) GetParams(Function f);
    }
}
