namespace HungryPizzaAPI.Models;

public class Pedido
{
    public Guid Id { get; set; }

    public List<Pizza> Pizzas { get; set; } = [];

    public EnderecoEntrega EnderecoEntrega { get; set; } = new();
    
    public decimal PrecoTotal { get; set; }
}
