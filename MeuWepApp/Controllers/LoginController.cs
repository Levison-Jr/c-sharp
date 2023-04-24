using MeuWepApp.Models;
using MeuWepApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace MeuWepApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

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
                    UsuarioModel? usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (loginModel.Senha == usuario.Senha)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemError"] = $"Senha incorreta! Por favor, tente novamente.";
                    }
                    else
                    {
                        TempData["MensagemError"] = $"Login e/ou senha incorreto(s)! Por favor, tente novamente.";
                    }
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
