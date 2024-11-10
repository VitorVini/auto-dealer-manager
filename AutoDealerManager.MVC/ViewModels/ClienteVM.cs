using System;
using System.ComponentModel.DataAnnotations;

namespace AutoDealerManager.MVC.ViewModels
{
    public class ClienteVM
    {
        public ClienteVM()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter exatamente 11 caracteres.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF inválido. O CPF deve conter apenas números.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(15, ErrorMessage = "O telefone deve ter no máximo 15 caracteres.")]
        [Phone(ErrorMessage = "Telefone inválido.")]
        public string Telefone { get; set; }
    }
}