using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrudOperationsWithExistingDb.Models;

namespace CrudOperationsWithExistingDb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SampleCoreDBContext _context;

        public HomeController(ILogger<HomeController> logger,SampleCoreDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //using(SampleCoreDBContext db=new SampleCoreDBContext())
            //{

            //    //Linq
            //   var data= db.Employee.Where(x=>x.PkemployeeId==1).ToList();

            //    var qry = (from emp in db.Employee
            //               join dep in db.Department
            //               on emp.FkdeptId equals dep.PkdepartmentId
            //              where emp.PkemployeeId==1
            //              select emp);
            //}

          // var data= _context.Employee.ToList();

            return View();
        }

        public IActionResult Privacy()
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
