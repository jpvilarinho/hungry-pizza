public class Pedido
{
    public Guid Id { get; set; }
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    public EnderecoEntrega EnderecoEntrega { get; set; } = new EnderecoEntrega();
    public decimal PrecoTotal { get; set; }
}