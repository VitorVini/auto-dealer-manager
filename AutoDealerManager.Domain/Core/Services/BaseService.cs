using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoDealerManager.Domain.Core.Services
{
    public class BaseService
    {
        protected List<string> errors = new List<string>();
        protected bool ExecutarValidacaoValidator<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
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

        protected void ExecutarValidacao(bool condicao, string mensagemDeErro)
        {
            if (!condicao)
                errors.Add(mensagemDeErro);
        }
        // TO DO : CRIAR EXCEPTION CUSTOMIZADO PARA VALIDAÇAO
        protected void VerificarErros()
        {
            if (errors.Any())
                throw new Exception(string.Join("<br>", errors));
        }
    }
}