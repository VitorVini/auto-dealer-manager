using FluentValidation;

namespace AutoDealerManager.Domain.Entities.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(e => e.Rua)
           .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
           .MaximumLength(150).WithMessage("A Rua deve ter no máximo 150 caracteres.");

            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
                .MaximumLength(100).WithMessage("A Cidade deve ter no máximo 100 caracteres.");

            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
                .Length(2).WithMessage("O Estado deve ter exatamente 2 caracteres.");

            RuleFor(e => e.Numero)
                .GreaterThanOrEqualTo(0).WithMessage("O Número deve ser um valor positivo.");

            RuleFor(e => e.CEP)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
                .Length(8).WithMessage("O CEP deve ter exatamente 8 caracteres.")
                .Matches(@"^\d{8}$").WithMessage("O CEP deve conter apenas números.");
        }
    }
}
