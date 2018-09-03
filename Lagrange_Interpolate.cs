using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество x и y");
            int size = Convert.ToInt32(Console.ReadLine());
            var xValues = new double[size];
            var yValues = new double[size];
            Console.WriteLine("Введите  x ");
            for (int i = 0; i < size; i++)
            {
                xValues[i] = Convert.ToInt32(Console.ReadLine());

            }
            Console.WriteLine("Введите  y ");
            for (int i = 0; i < size; i++)
            {
                yValues[i] = Convert.ToInt32(Console.ReadLine());

            }
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("x:" + i + " " + "y:" + InterpolateLagrangePolynomial(i, xValues, yValues, size));
            }
            Console.ReadKey();
        }

        static double InterpolateLagrangePolynomial(double x, double[] xValues, double[] yValues, int size)
        {
            double lagrangePol = 0;

            for (int i = 0; i < size; i++)
            {
                double basicsPol = 1;
                for (int j = 0; j < size; j++)
                {
                    if (j != i)
                    {
                        basicsPol *= (x - xValues[j]) / (xValues[i] - xValues[j]);
                    }
                }
                lagrangePol += basicsPol * yValues[i];
            }

            return lagrangePol;
        }

        static double TestF(double x)
        {
            return (x * x * x); // for example
        }

    }
}

