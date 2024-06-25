using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<EnderecoEntrega> EnderecosEntrega { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pedido>().HasKey(p => p.Id);
        modelBuilder.Entity<Pizza>().HasKey(p => p.Id);
        modelBuilder.Entity<EnderecoEntrega>().HasKey(e => e.Id);
    }
}