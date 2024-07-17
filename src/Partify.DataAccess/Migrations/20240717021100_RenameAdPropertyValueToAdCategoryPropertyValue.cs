using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Partify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameAdPropertyValueToAdCategoryPropertyValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdPropertyValues");

            migrationBuilder.CreateTable(
                name: "AdCategoryPropertyValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdCategoryPropertyId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    AdId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdCategoryPropertyValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdCategoryPropertyValues_AdCategoryProperties_AdCategoryPro~",
                        column: x => x.AdCategoryPropertyId,
                        principalTable: "AdCategoryProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdCategoryPropertyValues_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdCategoryPropertyValues_AdCategoryPropertyId",
                table: "AdCategoryPropertyValues",
                column: "AdCategoryPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_AdCategoryPropertyValues_AdId",
                table: "AdCategoryPropertyValues",
                column: "AdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdCategoryPropertyValues");

            migrationBuilder.CreateTable(
                name: "AdPropertyValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdCategoryPropertyId = table.Column<long>(type: "bigint", nullable: false),
                    AdId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdPropertyValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdPropertyValues_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdPropertyValues_AdId",
                table: "AdPropertyValues",
                column: "AdId");
        }
    }
}
