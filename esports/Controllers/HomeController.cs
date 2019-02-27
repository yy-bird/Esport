using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using esports.Models;
using esports.Repos;

namespace esports.Controllers
{
    public class HomeController : Controller
    {
        private MainDbRepository _DbRepository;

        public HomeController(MainDbRepository repository)
        {
            _DbRepository = repository;
        }

        public IActionResult Index()
        {
            var json = _DbRepository.GetJson();
            return View("Index", json);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
