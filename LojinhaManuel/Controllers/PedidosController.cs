using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using LojinhaManuel.Application.Services;

namespace LojinhaManuel.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private  ILogger _logger;
        private  PackingService _packingService;

        public PedidosController(ILogger<PedidosController> logger)
        {
            _logger = logger;
            _packingService = new PackingService();
        }
      
        [HttpPost]
        public IActionResult EmpacotarPedidos([FromBody] List<Pedido> pedidos)
        {
            var resultado = new List<ResultadoPedido>();

            foreach (var pedido in pedidos)
            {
                resultado.Add(_packingService.Empacotar(pedido));
            }

            return Ok(resultado);
        }
    }
}
