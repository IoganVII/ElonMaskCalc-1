using System;
using System.Linq;

namespace EM.Calc.Core
{
    public class PowOperation : IOperation
    {
        public string Name => "pow";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public double? Execute()
        {
            Result = Operands.Aggregate((lhs, rhs) => Math.Pow(lhs, rhs));
            return Result;
        }
    }
}
