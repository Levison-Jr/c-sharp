using Microsoft.AspNetCore.Mvc;

namespace MeuWepApp.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
