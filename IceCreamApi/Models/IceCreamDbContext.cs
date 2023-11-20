using Microsoft.EntityFrameworkCore;

public class IceCreamDbContext : DbContext
{
    public IceCreamDbContext(DbContextOptions<IceCreamDbContext> options)
        : base(options)
    {
        
        
    }

    public DbSet<IceCream> IceCream { get; set; }
}
