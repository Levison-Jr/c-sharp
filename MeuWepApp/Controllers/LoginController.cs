using MeuWepApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeuWepApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"ERRO: Não foi possível cadastrar o usuário, tente novamente. => {error.Message}";
                return View("Index");
            }
        }
    }
}
