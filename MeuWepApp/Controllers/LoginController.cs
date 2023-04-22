using Microsoft.AspNetCore.Mvc;

namespace MeuWepApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
