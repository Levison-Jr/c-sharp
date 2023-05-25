using MeuWepApp.Helper;
using MeuWepApp.Models;
using MeuWepApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace MeuWepApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if (_sessao.SearchSessionUser() != null)
            {
                return RedirectToAction("Index", "Home");
            }
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
                            _sessao.CreateSessionUser(usuario);
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

        public IActionResult Sair()
        {
            _sessao.RemoveSessionUser();
            return RedirectToAction("Index", "Login");
        }
    }
}
