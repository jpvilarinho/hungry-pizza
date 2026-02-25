using HungryPizzaAPI.Controllers;
using HungryPizzaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HungryPizzaAPI.Tests;

public class PedidoTests
{
    [Fact]
    public void TestarPedidoComMaisDe10Pizzas()
    {
        var pedido = new Pedido();

        for (int i = 0; i < 11; i++)
            pedido.Pizzas.Add(new Pizza { Sabor1 = "Mussarela" });

        var controller = new PedidosController(null!);
        var result = controller.CriarPedido(pedido).Result;

        Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public void TestarCalculoPrecoPizza()
    {
        var controller = new PedidosController(null!);

        var action = controller.GetPrecoSabor("Mussarela");

        var ok = Assert.IsType<OkObjectResult>(action.Result);
        var preco = Assert.IsType<decimal>(ok.Value);

        Assert.Equal(42.50m, preco);
    }
}
