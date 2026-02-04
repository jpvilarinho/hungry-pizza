using HungryPizzaAPI.Data;
using HungryPizzaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HungryPizzaAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PedidosController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CriarPedido([FromBody] Pedido pedido)
    {
        if (pedido.Pizzas is null || pedido.Pizzas.Count < 1 || pedido.Pizzas.Count > 10)
            return BadRequest("O pedido deve conter entre 1 e 10 pizzas.");

        foreach (var pizza in pedido.Pizzas)
        {
            pizza.Preco = pizza.Sabor2 is not null
                ? (ObterPrecoSabor(pizza.Sabor1) + ObterPrecoSabor(pizza.Sabor2)) / 2
                : ObterPrecoSabor(pizza.Sabor1);
        }

        pedido.PrecoTotal = pedido.Pizzas.Sum(p => p.Preco);
        pedido.Id = Guid.NewGuid();

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();

        return Ok(pedido.Id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Pedido>> ConsultarPedido(Guid id)
    {
        var pedido = await _context.Pedidos
            .Include(p => p.Pizzas)
            .Include(p => p.EnderecoEntrega)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pedido is null)
            return NotFound();

        return Ok(pedido);
    }

    private static decimal ObterPrecoSabor(string sabor)
    {
        return sabor switch
        {
            "3 Queijos" => 50m,
            "Frango com requeijão" => 59.99m,
            "Mussarela" => 42.50m,
            "Calabresa" => 42.50m,
            "Pepperoni" => 55m,
            "Portuguesa" => 45m,
            "Veggie" => 59.99m,
            _ => throw new ArgumentException("Sabor desconhecido", nameof(sabor))
        };
    }

    [HttpGet("PrecoSabor/{sabor}")]
    public ActionResult<decimal> GetPrecoSabor(string sabor)
        => Ok(ObterPrecoSabor(sabor));
}
