using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Lagrange
    {
        public Function func;
        public Lagrange(Function f)
        {
            func = f;
        }

        public double GetValue(double x)
        {
            try
            {
                double value = 0;
                for (int i = 0; i < func.Length; i++)
                {
                    double P = 1;
                    for (int j = 0; j < func.Length; j++)
                    {
                        if (i != j)
                            P *= (x - func.args[j]) / (func.args[i] - func.args[j]);
                    }
                    value += P * func.values[i];
                }
                return value;
            }
            catch (Exception e)
            {
                Console.WriteLine("Функция имела неверный формат");
                throw e;
            }
        }
    }
}
