using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using esports.Models;
using esports.Repos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace esports.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        private MainDbRepository _DbRepository;

        public AccountController(MainDbRepository repository)
        {
            _DbRepository = repository;
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Validate(LoginData data)
        {
          return Json(new { status = false, message = "success" });
        }

        public IActionResult CreateAccount(User user)
        {
            _DbRepository.AddNewUser(user);
            return Json(new { status = false, message = "success" });
        }
    }

    public class LoginData
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
