using MeuWepApp.Models;

namespace MeuWepApp.Repositorio
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioModel> BuscarTodos();
        UsuarioModel? BuscarPorId(int id);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Update(UsuarioModel usuario);
        UsuarioModel Delete(int id);
    }
}
