using Microsoft.AspNetCore.Mvc;
using Xunit;

public class PedidoTests
{
    [Fact]
    public void TestarPedidoComMaisDe10Pizzas()
    {
        var pedido = new Pedido
        {
            Pizzas = new List<Pizza>()
        };

        for (int i = 0; i < 11; i++)
        {
            pedido.Pizzas.Add(new Pizza { Sabor1 = "Mussarela" });
        }

        var controller = new PedidosController(null!);
        var result = controller.CriarPedido(pedido).Result;

        Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public void TestarCalculoPrecoPizza()
    {
        var controller = new PedidosController(null!);
        var result = controller.GetPrecoSabor("Mussarela").Result;
        var preco = ((OkObjectResult)result).Value;

        Assert.Equal(42.50m, preco);
    }
}
