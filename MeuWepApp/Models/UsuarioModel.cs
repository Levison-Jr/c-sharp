using MeuWepApp.Enums;

namespace MeuWepApp.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataUpdate { get; set; }
        public UsuarioModel()
        {
            Name = string.Empty;
            Login = string.Empty;
            Email = string.Empty;
            Senha = string.Empty;
        }
    }
}
