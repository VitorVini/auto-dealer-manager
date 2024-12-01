using FluentValidation;
using System;

namespace AutoDealerManager.Domain.Entities.Validations
{
    public class FabricanteValidation : AbstractValidator<Fabricante>
    {
        public FabricanteValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.PaisOrigem)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(3, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.AnoFundacao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("O campo {PropertyName} deve representar uma data no presente ou passado.");

            RuleFor(f => f.Website)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .MaximumLength(255).WithMessage("O campo {PropertyName} deve ter no máximo 255 caracteres.");
        }
    }
}
