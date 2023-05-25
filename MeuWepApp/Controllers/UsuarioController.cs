using MeuWepApp.Filters;
using MeuWepApp.Models;
using MeuWepApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace MeuWepApp.Controllers
{
    [PaginaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio) 
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuario = _usuarioRepositorio.BuscarTodos();
            return View(usuario);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Excluir(int id)
        {
            UsuarioModel? usuario = _usuarioRepositorio.BuscarPorId(id);
            return View(usuario);
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel? usuario = _usuarioRepositorio.BuscarPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"ERRO: Não foi possível cadastrar o usuário, tente novamente. => {error.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Atualizar(UsuarioSemSenhaModel usuarioSemSenha)
        {
            try
            {
                UsuarioModel usuario = new UsuarioModel();

                if (ModelState.IsValid)
                {
                    usuario = new()
                    {
                        Id = usuarioSemSenha.Id,
                        Name = usuarioSemSenha.Name,
                        Login = usuarioSemSenha.Login,
                        Email = usuarioSemSenha.Email,
                        Perfil = usuarioSemSenha.Perfil
                    };

                    _usuarioRepositorio.Update(usuario);
                    TempData["MensagemSucesso"] = "Informações do usuário atualizadas com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", usuario);
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"ERRO: Não foi possível atualizar as informações, tente novamente. => {error.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                _usuarioRepositorio.Delete(id);
                TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"ERRO: Não foi possível apagar o usuário, tente novamente. => {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
