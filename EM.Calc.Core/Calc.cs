using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EM.Calc.Core
{
    public class Calc
    {
        /// <summary>
        /// Операции
        /// </summary>
        public IList<IOperation> Operations { get; set; }

        public Calc()
        {
            Operations = new List<IOperation>();
            
            // получить текущую сборку
            var asm = Assembly.GetExecutingAssembly();
            
            // загрузить все типы из сборки
            var types = asm.GetTypes();

            // перебираем все классы в сборке
            foreach (var item in types)
            {
                // если класс реализаует заданный интерфейс
                if(item.GetInterface("IOperation") != null)
                {
                    //добавляем в операции экземпляр данного класса
                    var instance = Activator.CreateInstance(item);

                    var operation = instance as IOperation;
                    if (operation != null)
                    {
                        Operations.Add(operation);
                    }
                }
            }
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
