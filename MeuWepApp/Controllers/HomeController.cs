using MeuWepApp.Filters;
using MeuWepApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MeuWepApp.Controllers
{
    [PaginaParaUsuarioLogado]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string? sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return View(new UsuarioModel { });
            }
            
            UsuarioModel? usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
            return View(usuario);
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