using System.ComponentModel.DataAnnotations;

namespace AutoDealerManager.Infra.CrossCutting.Identity.Models
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Numero")]
        public string Number { get; set; }
    }
}

