using MeuWepApp.Data;
using MeuWepApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeuWepApp.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel? BuscarPorId(int id)
        {
            UsuarioModel? usuario = _bancoContext.Usuarios.FirstOrDefault(option => option.Id == id);
            return usuario;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Update(UsuarioModel usuario)
        {
            UsuarioModel? usuarioAtualizar = BuscarPorId(usuario.Id);

            if (usuarioAtualizar != null)
            {
                usuarioAtualizar.Name = usuario.Name;
                usuarioAtualizar.Email = usuario.Email;
                usuarioAtualizar.Login = usuario.Login;
                usuarioAtualizar.Perfil = usuario.Perfil;
                usuarioAtualizar.DataUpdate = DateTime.Now;

                _bancoContext.Usuarios.Update(usuarioAtualizar);
                _bancoContext.SaveChanges();

                return usuario;
            }

            throw new Exception("Houve um erro na atualização do usuário!!!");
        }

        public UsuarioModel Delete(int id)
        {
            UsuarioModel? usuarioDeletar = BuscarPorId(id);
            
            if (usuarioDeletar != null)
            {
                _bancoContext.Usuarios.Remove(usuarioDeletar);
                _bancoContext.SaveChanges();

                return usuarioDeletar;
            }

            throw new Exception("Houve um erro ao tentar deletar o usuário!!!");
        }
    }
}
