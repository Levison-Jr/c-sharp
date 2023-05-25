using MeuWepApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeuWepApp.ViewComponents
{
    public class Menu : ViewComponent
    {
        public IViewComponentResult? Invoke()
        {
            string? sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }

            UsuarioModel? usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

            return View(usuario);
        }
    }
}
