using System;
using System.ComponentModel.DataAnnotations;

namespace ErrorCentral.AppDomain.Models
{
    public class User : IUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do usuário é obrigatório.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email do usuário é obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha do usuário é obrigatória.")]
        public string Password { get; set; }
    }
}
