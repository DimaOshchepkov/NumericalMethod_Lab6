using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    interface ReaderFunction
    {
        (Function f, double x) Read();
    }
}
