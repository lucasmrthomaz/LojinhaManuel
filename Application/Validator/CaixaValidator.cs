using FluentValidation;
using LojinhaManuel.Domain.Model;

namespace LojinhaManuel.Validator
{
    public class CaixaValidator : AbstractValidator<Caixa>
    {
        public CaixaValidator()
        {
            //RuleFor(caixa => caixa.CaixaId).NotNull();
            //RuleFor(caixa => caixa.CaixaNome).NotEmpty();
        }
    }
}
