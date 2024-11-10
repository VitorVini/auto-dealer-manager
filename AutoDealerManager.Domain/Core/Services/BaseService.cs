using FluentValidation;

namespace AutoDealerManager.Domain.Core.Services
{
    public class BaseService
    {
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            //Notificar(validator);

            return false;

        }
    }
}