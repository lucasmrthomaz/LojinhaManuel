using LojinhaManuel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ResultadoPedido
    {
        public int PedidoId { get; set; }
        public List<Caixa> CaixasUsadas { get; set; }
    }
}
