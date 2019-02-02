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
            var user = _DbRepository.GetUser(data.Username);
            var isValidUser = user.UserName == data.Username && user.Password == data.Password;
          return Json(new { status = isValidUser,message = isValidUser?"success":"wrong information" });
        }

        public IActionResult CreateAccount(User user)
        {
            _DbRepository.AddNewUser(user);
            return Json(new { status = false, message = "success" });
        }
    }
}
