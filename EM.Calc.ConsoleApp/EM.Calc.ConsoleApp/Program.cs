using System;

namespace EM.Calc.ConsoleApp
{
    class Program
    {
        // "1+1"
        // sum 12 32 34
        static void Main(string[] args)
        {
            double[] mass = ConvertToDouble(args);
            var calc = new Core.Calc();

            var oper = args[0].ToLower();

            switch (oper)
            {
                case "sum":
                    Console.WriteLine(calc.Sum(mass));
                    break;
                case "sub":
                    Console.WriteLine(calc.Sub(mass));
                    break;
                case "pow":
                    Console.WriteLine(calc.Pow(mass));
                    break;
                case "piu":
                    Console.WriteLine(calc.Piu(mass));
                    break;
                default:
                    Console.WriteLine("Фатал еррор");
                    break;
            }
            Console.Read();
        }

        private static double[] ConvertToDouble(string[] args)
        {
            double[] mass = new double[args.Length - 1];
            int j = 0;
            for (int i = 1; i < args.Length; i++, j++)
            {
                mass[j] = Convert.ToDouble(args[i]);
            }
            return mass;
        }
    }
}
