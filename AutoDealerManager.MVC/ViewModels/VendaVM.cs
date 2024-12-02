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
        public Guid VeiculoId { get; set; }

        [Required(ErrorMessage = "A concessionária é obrigatória.")]
        public Guid ConcessionariaId { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatório.")]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "A data da venda é obrigatória.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O preço de venda é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        public long Protocolo { get; set; }
        public string NomeVeiculo { get; set; }

        [Display(Name = "Concessionaria")]
        public string NomeConcessionaria { get; set; }

        // Relacionamentos
        public VeiculoVM Veiculo { get; set; }
        public ConcessionariaVM Concessionaria { get; set; }
        [Display(Name = "Informações do Cliente")]
        public ClienteVM Cliente { get; set; }
    }
}