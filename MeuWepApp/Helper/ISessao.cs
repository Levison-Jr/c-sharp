using MeuWepApp.Models;

namespace MeuWepApp.Helper
{
    public interface ISessao
    {
        void CreateSessionUser(UsuarioModel user);
        void RemoveSessionUser();
        UsuarioModel? SearchSessionUser();
    }
}
