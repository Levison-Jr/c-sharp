using MeuWepApp.Models;
using Newtonsoft.Json;

namespace MeuWepApp.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public Sessao(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void CreateSessionUser(UsuarioModel user)
        {
            string userJson = JsonConvert.SerializeObject(user);
            _contextAccessor.HttpContext?.Session.SetString("sessaoUsuarioLogado", userJson);
        }

        public void RemoveSessionUser()
        {
            _contextAccessor.HttpContext?.Session.Remove("sessaoUsuarioLogado");
        }

        public UsuarioModel? SearchSessionUser()
        {
            string? sessaoUsuario = _contextAccessor.HttpContext?.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }
    }
}
