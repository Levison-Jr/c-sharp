﻿using MeuWepApp.Models;
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
            if (ModelState.IsValid)
            {
                _contatoRepositorio.Adicionar(contato);
                return RedirectToAction("Index");
            }

            return View(contato);
        }

        [HttpPost]
        public IActionResult Atualizar(ContatoModel contato)
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.Update(contato);
                return RedirectToAction("Index");
            }

            return View("Editar", contato);
        }

        public IActionResult Deletar(int id)
        {
            _contatoRepositorio.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
