using Microsoft.EntityFrameworkCore;

public class UsersDb : DbContext
{
    public DbSet<Users> users {get; set;}
    public UsersDb(DbContextOptions options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}