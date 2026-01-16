using Microsoft.EntityFrameworkCore;
using TtrpgManager.Domain;

namespace TtrpgManager.Infrastructure.Persistence;

public class TtrpgManagerDbContext : DbContext
{
    public TtrpgManagerDbContext(DbContextOptions<TtrpgManagerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Campaign> Campaigns => Set<Campaign>();
    public DbSet<Adventure> Adventures => Set<Adventure>();
    public DbSet<Npc> Npcs => Set<Npc>();
    public DbSet<Place> Places => Set<Place>();
    public DbSet<Chapter> Chapters => Set<Chapter>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TtrpgManagerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
