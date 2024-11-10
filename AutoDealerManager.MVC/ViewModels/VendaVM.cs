using System;
using System.ComponentModel.DataAnnotations;

namespace AutoDealerManager.MVC.ViewModels
{
    public class VendaVM
    {
        public VendaVM()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O veículo é obrigatório.")]
        public int VeiculoID { get; set; }

        [Required(ErrorMessage = "A concessionária é obrigatória.")]
        public int ConcessionariaID { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatório.")]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "A data da venda é obrigatória.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida.")]
        [Display(Name = "Data da Venda")]
        public DateTime DataVenda { get; set; }

        [Required(ErrorMessage = "O preço de venda é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
        [Display(Name = "Preço da Venda")]
        public decimal PrecoVenda { get; set; }

        [Required(ErrorMessage = "O protocolo de venda é obrigatório.")]
        [StringLength(20, ErrorMessage = "O protocolo deve ter no máximo 20 caracteres.")]
        public string ProtocoloVenda { get; set; }

        // Relacionamentos
        public VeiculoVM Veiculo { get; set; }
        public ConcessionariaVM Concessionaria { get; set; }
        public ClienteVM Cliente { get; set; }
    }
}