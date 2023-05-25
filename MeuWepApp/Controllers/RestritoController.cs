using MeuWepApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MeuWepApp.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
