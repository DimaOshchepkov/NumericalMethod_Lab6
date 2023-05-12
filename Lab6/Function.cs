using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Function
    {
        public double[] args { get; private set; }
        public double[] values { get; private set; }

        public void SetFunc(double[] args, double[] values)
        {
            if (args.Length != values.Length)
                throw new ArgumentException("Wrong size of array");

            this.args = args;
            this.values = values;
        }
        public Function(double[] args, double[] values)
        {
            SetFunc(args, values);
        }

        public int Length 
        { 
            get
            {
               return args.Length;
            }
        }
    }
}
