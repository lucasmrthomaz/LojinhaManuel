using LojinhaManuel.Domain.Model;
using Domain.Entity;

namespace LojinhaManuel.Application.Services
{
    public class PackingService
    {
        // Definindo as dimensões das caixas pré-fabricadas
        public List<Caixa> caixasDisponiveis = new List<Caixa>
        {
            new Caixa { Tipo = "Caixa 1", Altura = 30, Largura = 40, Comprimento = 80 },
            new Caixa { Tipo = "Caixa 2", Altura = 80, Largura = 50, Comprimento = 40 },
            new Caixa { Tipo = "Caixa 3", Altura = 50, Largura = 80, Comprimento = 60 }
        };

        public ResultadoPedido Empacotar(Pedido pedido)
        {
            var caixasUsadas = new List<Caixa>();

            // Ordenar os produtos por volume decrescente
            foreach (var produto in pedido.Produtos.OrderByDescending(p => p.Volume))
            {
                // Tentar encaixar o produto em uma das caixas disponíveis
                Caixa caixaSelecionada = null;

                foreach (var caixaModelo in caixasDisponiveis)
                {
                    if (ProdutoCabeNaCaixa(produto, caixaModelo))
                    {
                        // Verifica se existe uma caixa do mesmo tipo já sendo usada com espaço
                        caixaSelecionada = caixasUsadas.FirstOrDefault(c =>
                            c.Tipo == caixaModelo.Tipo && c.EspacoDisponivel >= produto.Volume);

                        // Se não existir, cria uma nova
                        if (caixaSelecionada == null)
                        {
                            caixaSelecionada = new Caixa
                            {
                                Tipo = caixaModelo.Tipo,
                                Altura = caixaModelo.Altura,
                                Largura = caixaModelo.Largura,
                                Comprimento = caixaModelo.Comprimento,
                                Produtos = new List<Produto>()
                            };
                            caixasUsadas.Add(caixaSelecionada);
                        }

                        break;
                    }
                }

                if (caixaSelecionada != null)
                {
                    caixaSelecionada.Produtos.Add(produto);
                }
                else
                {
                    // Caso não caiba em nenhuma caixa disponível, isso pode ser tratado com uma mensagem de erro ou lógica alternativa
                    throw new System.Exception($"O produto {produto.Nome} não cabe em nenhuma das caixas disponíveis.");
                }
            }

            return new ResultadoPedido
            {
                PedidoId = pedido.Id,
                CaixasUsadas = caixasUsadas
            };
        }

        // Função que verifica se o produto cabe nas dimensões da caixa, independentemente da rotação
        private bool ProdutoCabeNaCaixa(Produto produto, Caixa caixa)
        {
            var dimensoesProduto = new[] { produto.Altura, produto.Largura, produto.Comprimento }.OrderByDescending(d => d).ToList();
            var dimensoesCaixa = new[] { caixa.Altura, caixa.Largura, caixa.Comprimento }.OrderByDescending(d => d).ToList();

            // Verifica se o produto cabe em qualquer orientação
            return dimensoesProduto[0] <= dimensoesCaixa[0] &&
                   dimensoesProduto[1] <= dimensoesCaixa[1] &&
                   dimensoesProduto[2] <= dimensoesCaixa[2];
        }
    }
}
