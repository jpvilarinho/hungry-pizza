using HungryPizzaAPI.Controllers;
using HungryPizzaAPI.Data;
using HungryPizzaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HungryPizzaAPI.Tests;

public class IntegrationTests
{
    private readonly ApplicationDbContext _context;

    public IntegrationTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new ApplicationDbContext(options);
    }

    [Fact]
    public async Task TestarCriarEConsultarPedido()
    {
        var controller = new PedidosController(_context);

        var pedido = new Pedido
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Sabor1 = "Mussarela" },
                new Pizza { Sabor1 = "Calabresa" }
            },
            EnderecoEntrega = new EnderecoEntrega
            {
                Logradouro = "Rua A",
                Numero = "123",
                Bairro = "Centro",
                Cidade = "Cidade A",
                Estado = "Estado A",
                CEP = "12345-678"
            }
        };

        var result = await controller.CriarPedido(pedido);
        var okCriar = Assert.IsType<OkObjectResult>(result.Result);
        var id = Assert.IsType<Guid>(okCriar.Value);

        var resultPedido = await controller.ConsultarPedido(id);
        var okConsultar = Assert.IsType<OkObjectResult>(resultPedido.Result);
        var pedidoCriado = Assert.IsType<Pedido>(okConsultar.Value);

        Assert.Equal(2, pedidoCriado.Pizzas.Count);
        Assert.Equal(85m, pedidoCriado.PrecoTotal);
    }
}
