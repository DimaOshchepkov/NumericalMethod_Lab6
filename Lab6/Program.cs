using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

        }
        static void Main(string[] args)
        {
            Task2();

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
            Console.ReadKey();
        }
    }
}
