using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Partify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolepropertytoUserentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RoleId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolePermissions_PermissionId",
                table: "UserRolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolePermissions_UserRoleId",
                table: "UserRolePermissions",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRolePermissions_Permissions_PermissionId",
                table: "UserRolePermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRolePermissions_UserRoles_UserRoleId",
                table: "UserRolePermissions",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRolePermissions_Permissions_PermissionId",
                table: "UserRolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRolePermissions_UserRoles_UserRoleId",
                table: "UserRolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserRolePermissions_PermissionId",
                table: "UserRolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_UserRolePermissions_UserRoleId",
                table: "UserRolePermissions");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");
        }
    }
}
