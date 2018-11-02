using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EM.Calc.Core;

namespace EM.Calc.Web.Models
{
    public class InputModel
    {

        [Display(Name = "Операция")]
        [Required(ErrorMessage = "Нам обязательно нужно знать операцию")]
        public string Name { get; set; }

        [Display(Name = "Параметры1")]
        public double[] Args1 { get; set; }

        [Display(Name = "Параметры2")]
        [Required]
        public string Args2 { get; set; }

        public IList<IOperation> Operations { get; set; }
    }
}