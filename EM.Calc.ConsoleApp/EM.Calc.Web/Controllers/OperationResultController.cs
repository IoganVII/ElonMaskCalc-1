using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.Calc.DB;

namespace EM.Calc.Web.Controllers
{
    public class OperationResultController : Controller
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\ElonMaskCalc\EM.Calc.ConsoleApp\EM.Calc.Web\App_Data\ElonMusk.mdf;Integrated Security=True";

        OperationResultRepository OperationResultRepository;

        public OperationResultController()
        {
            OperationResultRepository = new OperationResultRepository(connString);
        }

        // GET: OperationResult
        public ActionResult Index()
        {
            var all = OperationResultRepository.GetAll();

            return View(all);
        }
    }
}