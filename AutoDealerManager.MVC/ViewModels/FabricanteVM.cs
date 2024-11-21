using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoDealerManager.MVC.ViewModels
{
    public class FabricanteVM
    {
        public FabricanteVM()
        {
            Id = Guid.NewGuid();
            IsUpdate = false;
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [DisplayName("País de origem")]
        [Required(ErrorMessage = "O campo País de Origem é obrigatório")]
        [StringLength(50, ErrorMessage = "O País de Origem deve ter no máximo 50 caracteres")]
        public string PaisOrigem { get; set; }

        [DisplayName("Ano de fundação")]
        [Required(ErrorMessage = "O campo Ano de Fundação é obrigatório")]
        [Range(1800, 9999, ErrorMessage = "O Ano de Fundação deve ser um valor válido")]
        public int AnoFundacao { get; set; }

        [Url(ErrorMessage = "O campo Website deve ser uma URL válida")]
        [Required(ErrorMessage = "O campo WebSite é obrigatório")]
        [StringLength(255, ErrorMessage = "O Website deve ter no máximo 255 caracteres")]
        public string Website { get; set; }

        public bool IsUpdate { get; set; }
    }
}