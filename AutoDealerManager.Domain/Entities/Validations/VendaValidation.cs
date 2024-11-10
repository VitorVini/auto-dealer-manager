using FluentValidation;
using System;

namespace AutoDealerManager.Domain.Entities.Validations
{
    public class VendaValidation : AbstractValidator<Venda>
    {
        public VendaValidation()
        {
            RuleFor(v => v.DataVenda)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data da venda não pode ser uma data futura.");

            RuleFor(v => v.PrecoVenda)
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

            RuleFor(v => v.Protocolo)
                .NotEmpty()
                .WithMessage("O protocolo da venda é obrigatório.")
                .Length(36)
                .WithMessage("O protocolo deve ter 36 caracteres.");
        }
    }
}

