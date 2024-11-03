using System.ComponentModel.DataAnnotations;

namespace AutoDealerManager.Infra.CrossCutting.Identity.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
