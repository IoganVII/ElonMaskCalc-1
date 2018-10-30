using System;
using System.Linq;

namespace EM.Calc.ConsoleApp
{
    class Program
    {
        // "1+1"
        // sum 12 32 34
        static void Main(string[] args)
        {
            double[] values;
            string operation;

            string[] operations = new[] { "sum", "sub", "piu", "new" };


            var calc = new Core.Calc();

            if(args.Length == 0)
            {
                Console.WriteLine("Список операций:");
                
                foreach (var item in operations)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Введите операцию: ");


                operation = Console.ReadLine();

                Console.WriteLine("Введите аргументы через пробел: ");
                var operands = Console.ReadLine();
                values = ConvertToDouble(
                    operands.Split(new[] { " ", ";" }, StringSplitOptions.RemoveEmptyEntries)
                );
            }
            else
            {
                operation = args[0].ToLower();
                values = ConvertToDouble(args, 1);
            }
            
            switch (operation)
            {
                case "sum":
                    Console.WriteLine(calc.Sum(values));
                    break;
                case "sub":
                    Console.WriteLine(calc.Sub(values));
                    break;
                case "pow":
                    Console.WriteLine(calc.Pow(values));
                    break;
                case "piu":
                    Console.WriteLine(calc.Piu(values));
                    break;
                case "new":
                    Console.WriteLine(calc.New(values));
                    break;
                default:
                    Console.WriteLine("Фатал еррор");
                    break;
            }
            Console.Read();
        }

        private static double[] ConvertToDouble(string[] args, int start = 0)
        {
            return args
                .Skip(start)
                .Select(Convert.ToDouble)
                .ToArray();
        }
    }
}
