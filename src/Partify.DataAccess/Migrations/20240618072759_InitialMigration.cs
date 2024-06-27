using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Partify.DataAccess.Migrations
{
	/// <inheritdoc />
	public partial class InitialMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Assets",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					FileName = table.Column<string>(type: "text", nullable: true),
					FilePath = table.Column<string>(type: "text", nullable: true),
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
					table.PrimaryKey("PK_Assets", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Facilities",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Name = table.Column<string>(type: "text", nullable: true),
					Icon = table.Column<string>(type: "text", nullable: true),
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
					table.PrimaryKey("PK_Facilities", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					FirstName = table.Column<string>(type: "text", nullable: true),
					LastName = table.Column<string>(type: "text", nullable: true),
					Phone = table.Column<long>(type: "bigint", nullable: false),
					Email = table.Column<string>(type: "text", nullable: true),
					Password = table.Column<string>(type: "text", nullable: true),
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
					table.PrimaryKey("PK_Users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Merchants",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					UserId = table.Column<long>(type: "bigint", nullable: false),
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
					table.PrimaryKey("PK_Merchants", x => x.Id);
					table.ForeignKey(
						name: "FK_Merchants_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Ads",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Address = table.Column<string>(type: "text", nullable: true),
					Longitude = table.Column<double>(type: "double precision", nullable: false),
					Latitude = table.Column<double>(type: "double precision", nullable: false),
					Description = table.Column<string>(type: "text", nullable: true),
					Phone = table.Column<long>(type: "bigint", nullable: false),
					Floor = table.Column<int>(type: "integer", nullable: false),
					RoomCount = table.Column<int>(type: "integer", nullable: false),
					Area = table.Column<double>(type: "double precision", nullable: false),
					Price = table.Column<decimal>(type: "numeric", nullable: false),
					Type = table.Column<int>(type: "integer", nullable: false),
					Status = table.Column<int>(type: "integer", nullable: false),
					MerchantId = table.Column<long>(type: "bigint", nullable: false),
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
					table.PrimaryKey("PK_Ads", x => x.Id);
					table.ForeignKey(
						name: "FK_Ads_Merchants_MerchantId",
						column: x => x.MerchantId,
						principalTable: "Merchants",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AdComments",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					UserId = table.Column<long>(type: "bigint", nullable: false),
					AdId = table.Column<long>(type: "bigint", nullable: false),
					Comment = table.Column<string>(type: "text", nullable: true),
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
					table.PrimaryKey("PK_AdComments", x => x.Id);
					table.ForeignKey(
						name: "FK_AdComments_Ads_AdId",
						column: x => x.AdId,
						principalTable: "Ads",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AdComments_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AdFacilities",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					AdId = table.Column<long>(type: "bigint", nullable: false),
					FacilityId = table.Column<long>(type: "bigint", nullable: false),
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
					table.PrimaryKey("PK_AdFacilities", x => x.Id);
					table.ForeignKey(
						name: "FK_AdFacilities_Ads_AdId",
						column: x => x.AdId,
						principalTable: "Ads",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AdFacilities_Facilities_FacilityId",
						column: x => x.FacilityId,
						principalTable: "Facilities",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AdImages",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					AdId = table.Column<long>(type: "bigint", nullable: false),
					ImageId = table.Column<long>(type: "bigint", nullable: false),
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
					table.PrimaryKey("PK_AdImages", x => x.Id);
					table.ForeignKey(
						name: "FK_AdImages_Ads_AdId",
						column: x => x.AdId,
						principalTable: "Ads",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AdImages_Assets_ImageId",
						column: x => x.ImageId,
						principalTable: "Assets",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AdScores",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Score = table.Column<int>(type: "integer", nullable: false),
					UserId = table.Column<long>(type: "bigint", nullable: false),
					AdId = table.Column<long>(type: "bigint", nullable: false),
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
					table.PrimaryKey("PK_AdScores", x => x.Id);
					table.ForeignKey(
						name: "FK_AdScores_Ads_AdId",
						column: x => x.AdId,
						principalTable: "Ads",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AdScores_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AdViews",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					ViewCount = table.Column<int>(type: "integer", nullable: false),
					AdId = table.Column<long>(type: "bigint", nullable: false),
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
					table.PrimaryKey("PK_AdViews", x => x.Id);
					table.ForeignKey(
						name: "FK_AdViews_Ads_AdId",
						column: x => x.AdId,
						principalTable: "Ads",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "FavoriteAds",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					UserId = table.Column<long>(type: "bigint", nullable: false),
					AdId = table.Column<long>(type: "bigint", nullable: false),
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
					table.PrimaryKey("PK_FavoriteAds", x => x.Id);
					table.ForeignKey(
						name: "FK_FavoriteAds_Ads_AdId",
						column: x => x.AdId,
						principalTable: "Ads",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_FavoriteAds_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AdCommentFiles",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					AdCommentId = table.Column<long>(type: "bigint", nullable: false),
					FileId = table.Column<long>(type: "bigint", nullable: true),
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
					table.PrimaryKey("PK_AdCommentFiles", x => x.Id);
					table.ForeignKey(
						name: "FK_AdCommentFiles_AdComments_AdComment~",
						column: x => x.AdCommentId,
						principalTable: "AdComments",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AdCommentFiles_Assets_FileId",
						column: x => x.FileId,
						principalTable: "Assets",
						principalColumn: "Id");
				});

			migrationBuilder.CreateIndex(
				name: "IX_AdCommentFiles_AdCommentId",
				table: "AdCommentFiles",
				column: "AdCommentId");

			migrationBuilder.CreateIndex(
				name: "IX_AdCommentFiles_FileId",
				table: "AdCommentFiles",
				column: "FileId");

			migrationBuilder.CreateIndex(
				name: "IX_AdComments_AdId",
				table: "AdComments",
				column: "AdId");

			migrationBuilder.CreateIndex(
				name: "IX_AdComments_UserId",
				table: "AdComments",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AdFacilities_AdId",
				table: "AdFacilities",
				column: "AdId");

			migrationBuilder.CreateIndex(
				name: "IX_AdFacilities_FacilityId",
				table: "AdFacilities",
				column: "FacilityId");

			migrationBuilder.CreateIndex(
				name: "IX_AdImages_AdId",
				table: "AdImages",
				column: "AdId");

			migrationBuilder.CreateIndex(
				name: "IX_AdImages_ImageId",
				table: "AdImages",
				column: "ImageId");

			migrationBuilder.CreateIndex(
				name: "IX_Ads_MerchantId",
				table: "Ads",
				column: "MerchantId");

			migrationBuilder.CreateIndex(
				name: "IX_AdScores_AdId",
				table: "AdScores",
				column: "AdId");

			migrationBuilder.CreateIndex(
				name: "IX_AdScores_UserId",
				table: "AdScores",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AdViews_AdId",
				table: "AdViews",
				column: "AdId");

			migrationBuilder.CreateIndex(
				name: "IX_FavoriteAds_AdId",
				table: "FavoriteAds",
				column: "AdId");

			migrationBuilder.CreateIndex(
				name: "IX_FavoriteAds_UserId",
				table: "FavoriteAds",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_Merchants_UserId",
				table: "Merchants",
				column: "UserId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AdCommentFiles");

			migrationBuilder.DropTable(
				name: "AdFacilities");

			migrationBuilder.DropTable(
				name: "AdImages");

			migrationBuilder.DropTable(
				name: "AdScores");

			migrationBuilder.DropTable(
				name: "AdViews");

			migrationBuilder.DropTable(
				name: "FavoriteAds");

			migrationBuilder.DropTable(
				name: "AdComments");

			migrationBuilder.DropTable(
				name: "Facilities");

			migrationBuilder.DropTable(
				name: "Assets");

			migrationBuilder.DropTable(
				name: "Ads");

			migrationBuilder.DropTable(
				name: "Merchants");

			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}
