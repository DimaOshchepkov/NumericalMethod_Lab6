using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    class FileReader : ReaderFunction
    {
        (Function f, double x) ReaderFunction.Read()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                try
                {
                    openFileDialog.InitialDirectory = Environment.CurrentDirectory;
                    if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                        return (null, 0);

                    string filename = openFileDialog.FileName;
                    string[] fileText = System.IO.File.ReadAllText(filename).Split(new char[] { '\n', '\r' }, 
                            StringSplitOptions.RemoveEmptyEntries);
                    string[] n_x = fileText[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    int n = int.Parse(n_x[0]);
                    double x = double.Parse(n_x[1]);
                    double[] arg = Array.ConvertAll(fileText[1].Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries), Double.Parse);
                    double[] values = Array.ConvertAll(fileText[2].Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries), Double.Parse);

                    return (new Function(arg, values), x);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Файл имел неверный формат");
                    Console.WriteLine($"Ошибка {e}");
                    throw e;
                }
            }
        }
    }
}
