using LojinhaManuel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Pedido
    {
        public int Id { get; set; }
        public List<Produto>? Produtos { get; set; }
    }
}
