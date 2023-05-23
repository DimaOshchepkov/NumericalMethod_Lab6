using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Lab6.ApprocsimationMethods;

namespace Lab6
{
    class Program
    {
        static void Task2()
        {
            double val = 4.8;
            double[] arg = { 2.6, 3.3, 4.7, 6.1, 7.5, 8.2, 9.6 };
            double[] value = { 2.1874, 2.8637, 3.8161, 3.8524, 3.1905, 2.8409, 2.6137 };

            Function func = new Function(arg, value);

            Lagrange lagrange = new Lagrange(func);
            Console.WriteLine(lagrange.GetValue(val));

            Bitmap bitmap = new Bitmap(1000, 800, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            // Начальная графика из растрового изображения
            Graphics graphics = Graphics.FromImage(bitmap);

            // Определите перо для рисования
            Pen penBlue = new Pen(Color.Blue, 2);
            Pen penRed = new Pen(Color.Red, 2);

            Func<double, double> f = x => 1.7 * Math.Pow(x, 1 / 3.0) - Math.Cos(0.4 - 0.7 * x);

            int countPoint = 100;
            int scale = 80;
            List<PointF> approximation = new List<PointF>();
            double max = 10, min = 0;
            int shiftX = (int)min + 20, shiftY = 400;
            for (double i = min; i < max; i += (max - min) / countPoint)
            {
                var pointApr = new Point((int)(i * scale + shiftX), (int)(lagrange.GetValue(i) * scale + shiftY));
                var pointReal = new Point((int)(i * scale + shiftX), (int)(f(i) * scale + shiftY));
                graphics.DrawRectangle(penBlue, new Rectangle(pointApr, new Size(1, 1)));
                graphics.DrawEllipse(penRed, new Rectangle(pointReal, new Size(1, 1)));
            }
            bitmap.Save("Curves.png");
        }
        static void Task3()
        {
            Console.WriteLine("Как вы хотите считать файл?\n1. Консоль\n2. Файл");
            int ans = -1;
            while (!int.TryParse(Console.ReadLine(), out ans) || ans <= 0 || ans > 2)
                Console.WriteLine("Неправальный ввод, попробуйте снова");

            ReaderFunction r = new ConsoleReader();
            Function f;
            double x;
            if (ans == 1)
                r = new ConsoleReader();
            else if (ans == 2)
                r = new FileReader();

            (f, x) = r.Read();
            Lagrange lagrange = new Lagrange(f);
            Console.WriteLine($"Значение в точке {x} = {lagrange.GetValue(x)}");
        }

        static void Task4()
        {
            Console.WriteLine("Как вы хотите считать файл?\n1. Консоль\n 2. Файл");
            string input = Console.ReadLine();
            ReaderFunction fr = new FileReader();
            if (input == "1")
                fr = new ConsoleReader();
            var (f, x) = fr.Read();

            Console.WriteLine("Введите погрешность");
            double eps = double.Parse(Console.ReadLine());

            NewtonInterpolation newton1 = new NewtonFirst(f, eps);
            NewtonInterpolation newton2 = new NewtonSecond(f, eps);
            Console.WriteLine($"Значение функции в точке {x} = {newton1.GetValue(x)}");
            Console.WriteLine($"Значение функции в точке {x} = {newton2.GetValue(x)}");
        }

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            //Task2();
            //Task3();
            //Task4();

            Console.WriteLine("Как вы хотите считать файл?\n1. Консоль\n2. Файл");
            string input = Console.ReadLine();
            ReaderFunction fr = new FileReader();
            if (input == "1")
                fr = new ConsoleReader();
            var (f, x) = fr.Read();

            var LSM = new LeastSquareMethod(f, new LinearFunctionLSM());
            Console.WriteLine($"Значение линейной функции в точке {x} = {LSM.GetValue(x)}");

            LSM.SetMapper(new PoweredMapperLSM());
            Console.WriteLine($"Значение степенной функции в точке {x} = {LSM.GetValue(x)}");

            LSM.SetMapper(new ExpFunctionMapperLSE());
            Console.WriteLine($"Значение экспонециальной функции в точке {x} = {LSM.GetValue(x)}");

            LSM.SetMapper(new ReverseLinearMapperLSE());
            Console.WriteLine($"Значение обратно-линейной функции в точке {x} = {LSM.GetValue(x)}");

            LSM.SetMapper(new FractionllyIrrationalMapperLSE());
            Console.WriteLine($"Значение дробно-иррациональной функции в точке {x} = {LSM.GetValue(x)}");

            LSM.SetMapper(new LogMapperLSE());
            Console.WriteLine($"Значение логарифмической функции в точке {x} = {LSM.GetValue(x)}");

            LSM.SetMapper(new HyperbolicMapperLSE());
            Console.WriteLine($"Значение гиперболической функции в точке {x} = {LSM.GetValue(x)}");


            Console.ReadKey();
        }
    }
}
