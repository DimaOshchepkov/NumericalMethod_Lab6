using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    class ConsoleReader : ReaderFunction
    {
        (Function f, double x) ReaderFunction.Read()
        {
            try
            {
                Console.WriteLine("Введите N");
                int n = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите x");
                int x = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите N узлов в строку");
                double[] arg = Array.ConvertAll(Console.ReadLine().Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries), Double.Parse);
                Console.WriteLine("Введите N значений узлов в строку");
                double[] values = Array.ConvertAll(Console.ReadLine().Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries), Double.Parse);

                Function func = new Function(arg, values);
                return (func, x);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка при считывании файла\n {e}");
                throw e;
            }
        }
    }
}
