using MeuWepApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeuWepApp.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o email do usuário!")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Selecione o perfil do usuário!")]
        public PerfilEnum? Perfil { get; set; }

        public UsuarioSemSenhaModel()
        {
            Name = string.Empty;
            Login = string.Empty;
            Email = string.Empty;
        }
    }
}
