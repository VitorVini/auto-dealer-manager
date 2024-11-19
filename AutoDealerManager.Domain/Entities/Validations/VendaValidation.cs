using FluentValidation;
using System;

namespace AutoDealerManager.Domain.Entities.Validations
{
    public class VendaValidation : AbstractValidator<Venda>
    {
        public VendaValidation()
        {
            RuleFor(v => v.Data)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data da venda não pode ser uma data futura.");

            RuleFor(v => v.Preco)
                .GreaterThan(0)
                .WithMessage("O preço da venda deve ser maior que zero.");

            RuleFor(v => v.ClienteId)
                .NotEmpty()
                .WithMessage("O cliente deve ser especificado para a venda.");

            RuleFor(v => v.VeiculoId)
                .NotEmpty()
                .WithMessage("O veículo deve ser especificado para a venda.");

            RuleFor(v => v.ConcessionariaId)
                .NotEmpty()
                .WithMessage("A concessionária deve ser especificada para a venda.");
        }
    }
}

