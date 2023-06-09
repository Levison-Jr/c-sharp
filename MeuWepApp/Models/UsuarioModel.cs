﻿using MeuWepApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeuWepApp.Models
{
    public class UsuarioModel
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

        [Required(ErrorMessage = "Digite a senha do usuário!")]
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
