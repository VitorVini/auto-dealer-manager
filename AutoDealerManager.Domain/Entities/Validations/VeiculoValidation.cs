using FluentValidation;
using System;

namespace AutoDealerManager.Domain.Entities.Validations
{
    public class VeiculoValidation : AbstractValidator<Veiculo>
    {
        public VeiculoValidation()
        {
            RuleFor(v => v.Modelo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .MaximumLength(100).WithMessage("O campo {PropertyName} precisa ter entre 1 e {MaxLength} caracteres");

            RuleFor(v => v.AnoFabricacao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("O ano de fabricação não pode ser no futuro.");

            RuleFor(v => v.Preco)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .GreaterThan(0).WithMessage("O preço deve ser um valor numérico positivo.");

            RuleFor(v => v.TipoVeiculo)
                .IsInEnum().WithMessage("Tipo de veículo inválido.");

            RuleFor(v => v.Descricao)
                .MaximumLength(500).WithMessage("O campo {PropertyName} não pode ter mais que 500 caracteres.");
        }
    }
}
