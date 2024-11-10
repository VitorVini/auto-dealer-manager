using System;
using System.ComponentModel.DataAnnotations;

namespace AutoDealerManager.MVC.ViewModels
{
    public class EnderecoVM
    {
        public EnderecoVM()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A rua é obrigatória.")]
        [StringLength(255, ErrorMessage = "A rua deve ter no máximo 255 caracteres.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(50, ErrorMessage = "A cidade deve ter no máximo 50 caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(50, ErrorMessage = "O estado deve ter no máximo 50 caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O número é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O número deve ser maior que zero.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP deve estar no formato 00000-000.")]
        public string CEP { get; set; }
    }
}