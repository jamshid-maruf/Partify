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
				name: "Appartments",
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
					table.PrimaryKey("PK_Appartments", x => x.Id);
					table.ForeignKey(
						name: "FK_Appartments_Merchants_MerchantId",
						column: x => x.MerchantId,
						principalTable: "Merchants",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AppartmentComments",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					UserId = table.Column<long>(type: "bigint", nullable: false),
					AppartmentId = table.Column<long>(type: "bigint", nullable: false),
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
					table.PrimaryKey("PK_AppartmentComments", x => x.Id);
					table.ForeignKey(
						name: "FK_AppartmentComments_Appartments_AppartmentId",
						column: x => x.AppartmentId,
						principalTable: "Appartments",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AppartmentComments_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AppartmentFacilities",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					AppartmentId = table.Column<long>(type: "bigint", nullable: false),
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
					table.PrimaryKey("PK_AppartmentFacilities", x => x.Id);
					table.ForeignKey(
						name: "FK_AppartmentFacilities_Appartments_AppartmentId",
						column: x => x.AppartmentId,
						principalTable: "Appartments",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AppartmentFacilities_Facilities_FacilityId",
						column: x => x.FacilityId,
						principalTable: "Facilities",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AppartmentImages",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					AppartmentId = table.Column<long>(type: "bigint", nullable: false),
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
					table.PrimaryKey("PK_AppartmentImages", x => x.Id);
					table.ForeignKey(
						name: "FK_AppartmentImages_Appartments_AppartmentId",
						column: x => x.AppartmentId,
						principalTable: "Appartments",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AppartmentImages_Assets_ImageId",
						column: x => x.ImageId,
						principalTable: "Assets",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AppartmentScores",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Score = table.Column<int>(type: "integer", nullable: false),
					UserId = table.Column<long>(type: "bigint", nullable: false),
					AppartmentId = table.Column<long>(type: "bigint", nullable: false),
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
					table.PrimaryKey("PK_AppartmentScores", x => x.Id);
					table.ForeignKey(
						name: "FK_AppartmentScores_Appartments_AppartmentId",
						column: x => x.AppartmentId,
						principalTable: "Appartments",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AppartmentScores_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AppartmentViews",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					ViewCount = table.Column<int>(type: "integer", nullable: false),
					AppartmentId = table.Column<long>(type: "bigint", nullable: false),
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
					table.PrimaryKey("PK_AppartmentViews", x => x.Id);
					table.ForeignKey(
						name: "FK_AppartmentViews_Appartments_AppartmentId",
						column: x => x.AppartmentId,
						principalTable: "Appartments",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "FavoriteAppartments",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					UserId = table.Column<long>(type: "bigint", nullable: false),
					AppartmentId = table.Column<long>(type: "bigint", nullable: false),
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
					table.PrimaryKey("PK_FavoriteAppartments", x => x.Id);
					table.ForeignKey(
						name: "FK_FavoriteAppartments_Appartments_AppartmentId",
						column: x => x.AppartmentId,
						principalTable: "Appartments",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_FavoriteAppartments_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AppartmentCommentFiles",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					AppartmentCommentId = table.Column<long>(type: "bigint", nullable: false),
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
					table.PrimaryKey("PK_AppartmentCommentFiles", x => x.Id);
					table.ForeignKey(
						name: "FK_AppartmentCommentFiles_AppartmentComments_AppartmentComment~",
						column: x => x.AppartmentCommentId,
						principalTable: "AppartmentComments",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AppartmentCommentFiles_Assets_FileId",
						column: x => x.FileId,
						principalTable: "Assets",
						principalColumn: "Id");
				});

			migrationBuilder.CreateIndex(
				name: "IX_AppartmentCommentFiles_AppartmentCommentId",
				table: "AppartmentCommentFiles",
				column: "AppartmentCommentId");

			migrationBuilder.CreateIndex(
				name: "IX_AppartmentCommentFiles_FileId",
				table: "AppartmentCommentFiles",
				column: "FileId");

			migrationBuilder.CreateIndex(
				name: "IX_AppartmentComments_AppartmentId",
				table: "AppartmentComments",
				column: "AppartmentId");

			migrationBuilder.CreateIndex(
				name: "IX_AppartmentComments_UserId",
				table: "AppartmentComments",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AppartmentFacilities_AppartmentId",
				table: "AppartmentFacilities",
				column: "AppartmentId");

			migrationBuilder.CreateIndex(
				name: "IX_AppartmentFacilities_FacilityId",
				table: "AppartmentFacilities",
				column: "FacilityId");

			migrationBuilder.CreateIndex(
				name: "IX_AppartmentImages_AppartmentId",
				table: "AppartmentImages",
				column: "AppartmentId");

			migrationBuilder.CreateIndex(
				name: "IX_AppartmentImages_ImageId",
				table: "AppartmentImages",
				column: "ImageId");

			migrationBuilder.CreateIndex(
				name: "IX_Appartments_MerchantId",
				table: "Appartments",
				column: "MerchantId");

			migrationBuilder.CreateIndex(
				name: "IX_AppartmentScores_AppartmentId",
				table: "AppartmentScores",
				column: "AppartmentId");

			migrationBuilder.CreateIndex(
				name: "IX_AppartmentScores_UserId",
				table: "AppartmentScores",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AppartmentViews_AppartmentId",
				table: "AppartmentViews",
				column: "AppartmentId");

			migrationBuilder.CreateIndex(
				name: "IX_FavoriteAppartments_AppartmentId",
				table: "FavoriteAppartments",
				column: "AppartmentId");

			migrationBuilder.CreateIndex(
				name: "IX_FavoriteAppartments_UserId",
				table: "FavoriteAppartments",
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
				name: "AppartmentCommentFiles");

			migrationBuilder.DropTable(
				name: "AppartmentFacilities");

			migrationBuilder.DropTable(
				name: "AppartmentImages");

			migrationBuilder.DropTable(
				name: "AppartmentScores");

			migrationBuilder.DropTable(
				name: "AppartmentViews");

			migrationBuilder.DropTable(
				name: "FavoriteAppartments");

			migrationBuilder.DropTable(
				name: "AppartmentComments");

			migrationBuilder.DropTable(
				name: "Facilities");

			migrationBuilder.DropTable(
				name: "Assets");

			migrationBuilder.DropTable(
				name: "Appartments");

			migrationBuilder.DropTable(
				name: "Merchants");

			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}
