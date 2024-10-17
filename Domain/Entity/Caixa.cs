namespace LojinhaManuel.Domain.Model
{
    public class Caixa
    {
        public string Tipo { get; set; } // Identificador da caixa (Caixa 1, Caixa 2, Caixa 3)
        public List<Produto> Produtos { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }

        public int Volume => Altura * Largura * Comprimento;
        public int EspacoDisponivel => Volume - Produtos.Sum(p => p.Volume);
    }
}
