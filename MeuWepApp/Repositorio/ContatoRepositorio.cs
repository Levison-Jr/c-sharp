using MeuWepApp.Data;
using MeuWepApp.Models;

namespace MeuWepApp.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ContatoModel> BucarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel? BuscarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            // Gravar no banco de dados
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public ContatoModel Update(ContatoModel contato)
        {
            ContatoModel? contatoAtualizar = BuscarPorId(contato.Id);

            if (contatoAtualizar != null)
            {
                contatoAtualizar.Name = contato.Name;
                contatoAtualizar.Email = contato.Email;
                contatoAtualizar.Celular = contato.Celular;

                _bancoContext.Contatos.Update(contatoAtualizar);
                _bancoContext.SaveChanges();

                return contatoAtualizar;
            }

            throw new Exception("Houve um erro na atualização do contato!!!");
        }

        public ContatoModel Delete(int id)
        {
            ContatoModel? contatoDeletar = BuscarPorId(id);

            if (contatoDeletar  != null)
            {
                _bancoContext.Contatos.Remove(contatoDeletar);
                _bancoContext.SaveChanges();

                return contatoDeletar;
            }

            throw new Exception("Houve um erro ao tentar deletar o contato!!!");
        }

    }
}
