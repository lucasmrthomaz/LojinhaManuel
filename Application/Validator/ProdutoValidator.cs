using FluentValidation;
using LojinhaManuel.Domain.Model;

namespace LojinhaManuel.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator() {
            //RuleFor(produto => produto.Nome).NotEmpty();
            //RuleFor(produto => produto.Dimensoes).NotEmpty();
        }
    }
}
