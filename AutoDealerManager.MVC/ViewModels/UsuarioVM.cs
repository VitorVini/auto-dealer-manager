using AutoDealerManager.Domain.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoDealerManager.MVC.ViewModels
{
    public class UsuarioVM
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome do usuário")]
        [Required(ErrorMessage = "O campo {0} é requirido")]
        [StringLength(50, ErrorMessage = "O nome de usuário deve ter no máximo 50 caracteres.")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é requirido")]
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "A senha deve ter no máximo 255 caracteres.")]
        public string Senha { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo {0} é requirido")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        public string Email { get; set; }

        [DisplayName("Nível de acesso")]
        [Required(ErrorMessage = "O campo {0} é requirido")]
        [EnumDataType(typeof(EnumNivelAcesso), ErrorMessage = "Nível de acesso inválido.")]
        public EnumNivelAcesso NivelAcesso { get; set; }
    }
}