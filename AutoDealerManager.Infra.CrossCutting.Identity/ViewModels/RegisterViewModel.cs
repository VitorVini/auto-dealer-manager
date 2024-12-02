using AutoDealerManager.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace AutoDealerManager.Infra.CrossCutting.Identity.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não combinam.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Nível de acesso")]
        public EnumNivelAcesso NivelAcesso { get; set; }
    }
}
