using MeuWepApp.Models;

namespace MeuWepApp.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BucarTodos();
        ContatoModel Adicionar(ContatoModel contato);
    }
}
