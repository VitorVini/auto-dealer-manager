using AutoDealerManager.Domain.Enum;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoDealerManager.MVC.ViewModels
{
    public class VeiculoVM
    {
        public VeiculoVM()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "O modelo do veículo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O modelo deve ter no máximo 100 caracteres.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O ano de fabricação é obrigatório.")]
        [Range(1886, 2100, ErrorMessage = "Ano de fabricação inválido.")]
        [DisplayName("Ano de Fabricação")]
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(1, 1000000000, ErrorMessage = "O preço deve ser positivo e realista.")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O fabricante é obrigatório.")]
        [DisplayName("Fabricante")]
        public Guid FabricanteId { get; set; }

        [DisplayName("Fabricante")]
        public FabricanteVM Fabricante { get; set; }

        [DisplayName("Tipo de veículo")]
        [Required(ErrorMessage = "O tipo de veículo é obrigatório.")]
        public EnumVeiculo TipoVeiculo { get; set; }

        [DisplayName("Descrição")]
        [StringLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres.")]
        public string Descricao { get; set; }
        public bool IsUpdate { get; set; }
    }
}