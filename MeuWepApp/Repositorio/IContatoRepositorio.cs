using MeuWepApp.Models;

namespace MeuWepApp.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BucarTodos();
        ContatoModel? BuscarPorId(int id);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Update(ContatoModel contato);
    }
}
