using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateRentalAdmin.Data.DbContext;
using RealEstateRentalAdmin.Data.Interface;
using RealEstateRentalAdmin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateRentalAdmin.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        public readonly IDbHelper _dbHelper;


        public HomeController(/*ILogger<HomeController> logger*/ IDbHelper dbHelper)
        {
            //_logger = logger;
            _dbHelper = dbHelper;
        }

        public IActionResult Index()
        {
            ViewBag.Summary = _dbHelper.SummaryData();
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
