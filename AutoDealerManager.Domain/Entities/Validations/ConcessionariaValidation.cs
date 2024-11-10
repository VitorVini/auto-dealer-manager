using FluentValidation;

namespace AutoDealerManager.Domain.Entities.Validations
{
    public class ConcessionariaValidation : AbstractValidator<Concessionaria>
    {
        public ConcessionariaValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
                .MaximumLength(100).WithMessage("O campo {PropertyName} deve ter no máximo 100 caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
                .EmailAddress().WithMessage("Informe um email válido.");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
                .Matches(@"^\(\d{2}\)\s\d{4,5}-\d{4}$").WithMessage("O campo {PropertyName} deve estar no formato (XX) XXXXX-XXXX.");

            RuleFor(c => c.CapacidadeMaximaVeiculos)
                .GreaterThan(0).WithMessage("A capacidade máxima de veículos deve ser maior que zero.");
        }
    }
}
