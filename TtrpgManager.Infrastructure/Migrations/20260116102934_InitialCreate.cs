using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TtrpgManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CoverImageId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adventures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CoverImageId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adventures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adventures_campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chapters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdventureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 20000, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chapters_adventures_AdventureId",
                        column: x => x.AdventureId,
                        principalTable: "adventures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "npcs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdventureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsFriendly = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CoverImageId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_npcs", x => x.Id);
                    table.CheckConstraint("CK_npcs_campaign_xor_adventure", "((CampaignId IS NOT NULL AND AdventureId IS NULL) OR (CampaignId IS NULL AND AdventureId IS NOT NULL))");
                    table.ForeignKey(
                        name: "FK_npcs_adventures_AdventureId",
                        column: x => x.AdventureId,
                        principalTable: "adventures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_npcs_campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "campaigns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "places",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdventureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CoverImageId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_places", x => x.Id);
                    table.CheckConstraint("CK_places_campaign_xor_adventure", "((CampaignId IS NOT NULL AND AdventureId IS NULL) OR (CampaignId IS NULL AND AdventureId IS NOT NULL))");
                    table.ForeignKey(
                        name: "FK_places_adventures_AdventureId",
                        column: x => x.AdventureId,
                        principalTable: "adventures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_places_campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "campaigns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "place_npcs",
                columns: table => new
                {
                    place_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    npc_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_place_npcs", x => new { x.place_id, x.npc_id });
                    table.ForeignKey(
                        name: "FK_place_npcs_npcs_npc_id",
                        column: x => x.npc_id,
                        principalTable: "npcs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_place_npcs_places_place_id",
                        column: x => x.place_id,
                        principalTable: "places",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_adventures_CampaignId_Name",
                table: "adventures",
                columns: new[] { "CampaignId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_chapters_AdventureId_Name",
                table: "chapters",
                columns: new[] { "AdventureId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_chapters_AdventureId_Order",
                table: "chapters",
                columns: new[] { "AdventureId", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_npcs_AdventureId",
                table: "npcs",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_npcs_CampaignId",
                table: "npcs",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_place_npcs_npc_id",
                table: "place_npcs",
                column: "npc_id");

            migrationBuilder.CreateIndex(
                name: "IX_places_AdventureId",
                table: "places",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_places_CampaignId",
                table: "places",
                column: "CampaignId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chapters");

            migrationBuilder.DropTable(
                name: "place_npcs");

            migrationBuilder.DropTable(
                name: "npcs");

            migrationBuilder.DropTable(
                name: "places");

            migrationBuilder.DropTable(
                name: "adventures");

            migrationBuilder.DropTable(
                name: "campaigns");
        }
    }
}
