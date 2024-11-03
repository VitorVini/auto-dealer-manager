using System.ComponentModel.DataAnnotations;

namespace AutoDealerManager.Infra.CrossCutting.Identity.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
