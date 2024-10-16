using LojinhaManuel.Data.Interface;

namespace LojinhaManuel.Data.Model
{
    public class Dimensoes : IMedidasPadrao
    {
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }
    }
}