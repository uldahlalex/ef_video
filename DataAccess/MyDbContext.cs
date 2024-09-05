using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
    : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
    }
    
    
    public DbSet<Product> Products { get; set; }
    
}

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
}