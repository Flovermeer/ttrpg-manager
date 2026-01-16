using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TtrpgManager.Domain;

namespace TtrpgManager.Infrastructure.Persistence.Configurations;

public sealed class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
{
    public void Configure(EntityTypeBuilder<Chapter> builder)
    {
        builder.ToTable("chapters");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Content)
            .HasMaxLength(20000);

        builder.Property(x => x.AdventureId)
            .IsRequired();

        builder.Property(x => x.Order)
            .IsRequired();

        // Chapter -> Adventure (sans navigation)
        builder.HasOne<Adventure>()
            .WithMany()
            .HasForeignKey(x => x.AdventureId)
            .OnDelete(DeleteBehavior.Cascade);

        // Unicité de l'ordre dans une aventure
        builder.HasIndex(x => new { x.AdventureId, x.Order })
            .IsUnique();

        builder.HasIndex(x => new { x.AdventureId, x.Name });
    }
}