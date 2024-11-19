using FluentValidation;
using System.Collections.Generic;

namespace AutoDealerManager.Domain.Core.Services
{
    public class BaseService
    {
        protected List<string> errors = new List<string>();
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            errors.Clear();

            foreach (var error in validator.Errors)
            {
                errors.Add(error.ErrorMessage);
            }

            return false;
        }
    }
}