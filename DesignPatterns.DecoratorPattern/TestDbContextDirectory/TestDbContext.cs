using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.DecoratorPattern.TestDbContextDirectory;

public class TestDbContext: DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        // audit logging
        return base.SaveChanges();
    }
}
