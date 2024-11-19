using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoDealerManager.MVC.ViewModels
{
    public class ConcessionariaVM
    {
        public ConcessionariaVM()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome da concessionária é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(15, ErrorMessage = "O telefone deve ter no máximo 15 caracteres.")]
        [Phone(ErrorMessage = "Telefone inválido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A capacidade máxima de veículos é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A capacidade deve ser um número positivo.")]
        [DisplayName("Capacidade máxima de veículos")]
        public int CapacidadeMaximaVeiculos { get; set; }

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
        [RegularExpression(@"^\d{8}$", ErrorMessage = "O CEP deve estar no formato 00000000.")]
        public string CEP { get; set; }

        public bool IsUpdate { get; set; }

        public string ObterEndereco()
        {
            return $"{Rua}, {Numero}, {Cidade} - {Estado}. CEP:{CEP}.";
        }
    }
}