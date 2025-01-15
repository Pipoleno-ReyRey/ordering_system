using Microsoft.EntityFrameworkCore;

public class ProductsDb : DbContext
{

    public DbSet<Products> products {get; set;}
    public ProductsDb(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
