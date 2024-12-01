using FluentValidation;

namespace AutoDealerManager.Domain.Entities.Validations
{
    public class ConcessionariaValidation : AbstractValidator<Concessionaria>
    {
        public ConcessionariaValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                .MaximumLength(100).WithMessage("O campo {PropertyName} deve ter no máximo 100 caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.");

            RuleFor(c => c.CapacidadeMaximaVeiculos)
                .GreaterThan(0).WithMessage("A capacidade máxima de veículos deve ser maior que zero.");

            RuleFor(e => e.Rua)
           .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
           .MaximumLength(255).WithMessage("A Rua deve ter no máximo 255 caracteres.");

            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                .MaximumLength(100).WithMessage("A Cidade deve ter no máximo 50 caracteres.");

            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                .MaximumLength(50).WithMessage("O Estado deve ter no máximo 50 caracteres.");

            RuleFor(e => e.Numero)
                .GreaterThanOrEqualTo(0).WithMessage("O Número deve ser um valor positivo.");

            RuleFor(e => e.CEP)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                .Length(8).WithMessage("O CEP deve ter exatamente 8 caracteres.");
        }
    }
}
