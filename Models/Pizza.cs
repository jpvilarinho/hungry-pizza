namespace HungryPizzaAPI.Models;

public class Pizza
{
    public int Id { get; set; }

    public string Sabor1 { get; set; } = string.Empty;

    public string? Sabor2 { get; set; }
    
    public decimal Preco { get; set; }
}
