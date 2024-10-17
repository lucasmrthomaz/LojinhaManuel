using LojinhaManuel.Domain.Interface;

namespace LojinhaManuel.Domain.Model
{
    public class DimensoesEcommerce : IMedidasPadrao
    {
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }
    }
}