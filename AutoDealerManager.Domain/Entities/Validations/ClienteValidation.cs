using AutoDealerManager.Domain.Core.Validations;
using FluentValidation;

namespace AutoDealerManager.Domain.Entities.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(c => c.Nome)
           .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
           .Length(1, 100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(c => c.CPF.Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo CPF precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

            RuleFor(c => CpfValidacao.Validar(c.CPF)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
                .Matches(@"^\(\d{2}\)\s\d{4,5}-\d{4}$").WithMessage("O campo {PropertyName} deve estar no formato (XX) XXXXX-XXXX.");
        }
    }
}
