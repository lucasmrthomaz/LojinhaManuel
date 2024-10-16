using FluentValidation;
using LojinhaManuel.Data.Model;

namespace LojinhaManuel.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator() {
            RuleFor(produto => produto.Nome).NotEmpty();
            RuleFor(produto => produto.Dimensoes).NotEmpty();
        }
    }
}
