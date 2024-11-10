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

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(255, ErrorMessage = "O endereço deve ter no máximo 255 caracteres.")]
        [DisplayName("Endereço")]
        public string Endereco { get; set; }

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
    }
}