using MeuWepApp.Models;
using MeuWepApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace MeuWepApp.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BucarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel? contato = _contatoRepositorio.BuscarPorId(id);
            return View(contato);
        }

        public IActionResult Excluir(int id)
        {
            ContatoModel? contato = _contatoRepositorio.BuscarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"ERRO: Não foi possível cadastrar o contato, tente novamente. => {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Update(contato);
                    TempData["MensagemSucesso"] = "Informações alteradas com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"ERRO: Não foi possível alterar o contato, tente novamente. => {error.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                _contatoRepositorio.Delete(id);
                TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"ERRO: Não foi possível apagar o contato, tente novamente. => {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
