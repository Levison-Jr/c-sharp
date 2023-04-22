using System.ComponentModel.DataAnnotations;

namespace MeuWepApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o login!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a senha!")]
        public string Senha { get; set; }
        public LoginModel()
        {
            Login = string.Empty;
            Senha = string.Empty;
        }
    }
}
