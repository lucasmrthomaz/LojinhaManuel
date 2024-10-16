namespace LojinhaManuel.Data.Model
{
    public class Caixa
    {
        public required Produto[]? Produto {  get; set; }

        public int? CaixaId { get; set; }

        public string? CaixaNome { get; set; }
    }
}
