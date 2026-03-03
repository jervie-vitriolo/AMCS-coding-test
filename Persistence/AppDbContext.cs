
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
        //customers
        modelBuilder.Entity<Customer>().HasKey(p => p.Id);
        modelBuilder.Entity<Customer>().HasData(
            new Customer("CUS1", "Jervie", "Vitriolo")
            );
        modelBuilder.Entity<Customer>().HasData(
            new Customer("CUS2", "Dwane", "Johnson")
            );

        //constractors
        modelBuilder.Entity<Contractor>().HasKey(p => p.Id);
        modelBuilder.Entity<Contractor>().HasData(
            new Contractor("CON1", "SLVDR Co.", 9)
            );
        modelBuilder.Entity<Contractor>().HasData(
            new Contractor("CON2", "AMCS Group", 10)
            );


        //jobs
        modelBuilder.Entity<Job>().HasKey(p => p.Id);
        modelBuilder.Entity<Job>().HasData(
            new Job(Guid.NewGuid(), DateTime.UtcNow, DateTime.Now,10000,"Empire State Building Job",string.Empty)
            );
        modelBuilder.Entity<Job>().HasData(
            new Job(Guid.NewGuid(), DateTime.UtcNow, DateTime.Now, 210000, "Golden Gate Bridge Job", string.Empty)
            );
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("amcsgroup");
    }
}
