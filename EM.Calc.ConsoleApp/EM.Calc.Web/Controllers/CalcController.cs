using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.Calc.Web.Models;

namespace EM.Calc.Web.Controllers
{
    public class CalcController : Controller
    {
        private Core.Calc calc;

        public CalcController()
        {
            calc = new Core.Calc(@"D:\temp");
        }

        // GET: Calc
        public ActionResult Execute(string oper, double[] args)
        {
            var model = Calc(oper, args);

            return View(model);
        }

        [HttpGet]
        public ActionResult Input()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Input(InputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!calc.Operations.Any(m => m.Name == model.Name))
            {
                ModelState.AddModelError("", "Такой операции нет");
                return View(model);
            }

            var result = Calc(model.Name, model.Args1);

            return View("Execute", result);
        }

        private OperationResult Calc(string oper, double[] args)
        {
            var result = calc.Execute(oper, args);

            return new OperationResult()
            {
                Name = oper,
                Result = result
            };
        }

    }
}