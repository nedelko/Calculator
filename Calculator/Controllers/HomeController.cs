using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Calculator.Models;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private CalculatorContext db;
        public HomeController(CalculatorContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<CalculatorResult> GetCalculatorResults()
        {
            return db.CalculatorResults;
        }

        [HttpPost]
        public void CreateCalculatorResult([FromBody]CalculatorResult calculatorResult)
        {
            db.CalculatorResults.Add(calculatorResult);
            db.SaveChanges();
        }
        [HttpDelete]
        public void DeleteResults()
        {
            var rows = from result in db.CalculatorResults
                       select result;
            foreach (var row in rows)
            {
                db.CalculatorResults.Remove(row);
            }
            db.SaveChanges();
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
