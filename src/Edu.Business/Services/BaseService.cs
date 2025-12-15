using Edu.Business.Models;
using FluentValidation;

namespace Edu.Business.Services
{
    public abstract class BaseService  
    {
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if(validator.IsValid) return true;

            // lançamento de notificações.

            return false;
        }
    }
}
