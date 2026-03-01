
using Domain;
using Microsoft.EntityFrameworkCore;


namespace Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Contractor> Contractors { get; set; }
    public DbSet<Job> Jobs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasKey(p => p.Id);
        modelBuilder.Entity<Customer>().HasData(
            new Customer(1, "jervie", "vitriolo")
            );
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("amcsgroup");
    }
}
