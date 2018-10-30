using System;
using System.Linq;

namespace EM.Calc.Core
{
    public class Calc
    {
        /// <summary>
        /// Операции
        /// </summary>
        public IOperation[] Operations { get; set; }

        public Calc()
        {
            Operations = new IOperation[]
            {
                new SumOperation(),
                new NewOperation()
            };
        }

        public double? Execute(string operName, double[] values)
        {
            foreach (var item in Operations)
            {
                if (item.Name == operName)
                {
                    item.Operands = values;

                    item.Execute();

                    return item.Result;
                }
            }

            return null;
        }


        public int Sum(int[] args)
        {
            return args.Sum();
        }

        [Obsolete("Не используйте это, есть же Execute")]
        public double Sum(double[] args)
        {
            return args.Sum();
        }

        public double Pow(double[] args)
        {
            return args.Aggregate((a, b) => Math.Pow(a, b));
        }

        public double Sub(double[] args)
        {
            return args.Aggregate((a, b) => a - b);
        }

        public double Piu(double[] args)
        {
            return args.Aggregate((a, b) => a * b);
        }

        public double New(double[] args)
        {
            return Double.PositiveInfinity;
        }
    }
}
