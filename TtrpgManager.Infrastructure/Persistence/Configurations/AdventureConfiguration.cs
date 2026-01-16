using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TtrpgManager.Domain;

namespace TtrpgManager.Infrastructure.Persistence.Configurations;

public class AdventureConfiguration : IEntityTypeConfiguration<Adventure>
{
    public void Configure(EntityTypeBuilder<Adventure> builder)
    {
        builder.ToTable("adventures");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Summary);

        builder.Property(x => x.CoverImageId)
            .HasMaxLength(255);

        builder.Property(x => x.CampaignId).IsRequired();

        // FK CampaignId -> Campaign.Id (sans navigation)
        builder.HasOne<Campaign>()
            .WithMany()
            .HasForeignKey(x => x.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.CampaignId, x.Name });
    }
}
