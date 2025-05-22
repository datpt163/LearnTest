using Microsoft.AspNetCore.Mvc;

namespace Product.Controllers.Account
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string a)
        {
            return View();
        }
    }
}
