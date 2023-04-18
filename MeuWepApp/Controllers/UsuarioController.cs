using Microsoft.AspNetCore.Mvc;

namespace MeuWepApp.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
