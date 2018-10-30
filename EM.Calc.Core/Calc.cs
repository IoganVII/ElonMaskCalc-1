using System;
using System.Linq;

namespace EM.Calc.Core
{
    public class Calc
    {
        public int Sum(int[] args)
        {
            return args.Sum();
        }

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
