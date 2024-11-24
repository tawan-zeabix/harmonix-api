using Microsoft.EntityFrameworkCore;

namespace UpdatePolicyService.Models.Database;

public class DatabaseContext : DbContext
{
    public DbSet<TablePolicy> TablePolicy { get; set; }
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    public DatabaseContext() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TablePolicy>(entity =>
        {
            entity.ToTable("TablePolicy");
        });
    }
}