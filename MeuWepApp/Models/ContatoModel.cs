using System.ComponentModel.DataAnnotations;

namespace MeuWepApp.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do contato!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do contato!")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o celular do contato!")]
        [Phone(ErrorMessage = "O celular digitado não é válido!")]
        public string Celular { get; set; }

        public ContatoModel()
        {
            Name = string.Empty;
            Email = string.Empty;
            Celular = string.Empty;
        }
    }
}
