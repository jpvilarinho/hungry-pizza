using HungryPizzaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HungryPizzaAPI.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<EnderecoEntrega> EnderecosEntrega => Set<EnderecoEntrega>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pedido>().HasKey(p => p.Id);
        modelBuilder.Entity<Pizza>().HasKey(p => p.Id);
        modelBuilder.Entity<EnderecoEntrega>().HasKey(e => e.Id);
    }
}