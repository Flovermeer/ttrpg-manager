using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TtrpgManager.Domain;

namespace TtrpgManager.Infrastructure.Persistence.Configurations;

public sealed class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.ToTable("places", t =>
        {
            t.HasCheckConstraint(
                "CK_places_campaign_xor_adventure",
                "((CampaignId IS NOT NULL AND AdventureId IS NULL) OR (CampaignId IS NULL AND AdventureId IS NOT NULL))"
            );
        });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(4000);

        builder.Property(x => x.CoverImageId)
            .HasMaxLength(255);

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

        builder.HasMany(x => x.Npcs)
            .WithMany(x => x.Places)
            .UsingEntity<Dictionary<string, object>>(
                "place_npcs",
                r => r.HasOne<Npc>()
                      .WithMany()
                      .HasForeignKey("npc_id")
                      .OnDelete(DeleteBehavior.NoAction),
                l => l.HasOne<Place>()
                      .WithMany()
                      .HasForeignKey("place_id")
                      .OnDelete(DeleteBehavior.NoAction),
                j =>
                {
                    j.ToTable("place_npcs");
                    j.HasKey("place_id", "npc_id");
                    j.HasIndex("npc_id");
                }
            );
    }
}
