using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TtrpgManager.Domain;

namespace TtrpgManager.Infrastructure.Persistence.Configurations;

public sealed class NpcConfiguration : IEntityTypeConfiguration<Npc>
{
    public void Configure(EntityTypeBuilder<Npc> builder)
    {
        builder.ToTable("npcs", t =>
        {
            t.HasCheckConstraint(
                "CK_npcs_campaign_xor_adventure",
                "((CampaignId IS NOT NULL AND AdventureId IS NULL) OR (CampaignId IS NULL AND AdventureId IS NOT NULL))"
            );
        });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.CoverImageId)
            .HasMaxLength(255);

        builder.Property(x => x.Occupation)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Age).IsRequired();
        builder.Property(x => x.IsFriendly).IsRequired();

        builder.Property(x => x.CampaignId);
        builder.Property(x => x.AdventureId);

        builder.HasOne<Campaign>()
            .WithMany()
            .HasForeignKey(x => x.CampaignId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<Adventure>()
            .WithMany()
            .HasForeignKey(x => x.AdventureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.CampaignId);
        builder.HasIndex(x => x.AdventureId);
    }
}
