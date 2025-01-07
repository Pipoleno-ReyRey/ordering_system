using Microsoft.EntityFrameworkCore;

public class CartDb : DbContext
{
    public DbSet<Cart> cart {get; set;}

    public CartDb(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Cart>().HasKey(c => new{c.id});
        modelBuilder.Entity<Cart>().HasIndex(c => c.userId).IsUnique();
    }
}