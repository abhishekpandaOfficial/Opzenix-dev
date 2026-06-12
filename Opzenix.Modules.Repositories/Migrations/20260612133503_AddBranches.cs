using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opzenix.Modules.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddBranches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "branches");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "branches",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_branches",
                table: "branches",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_branches",
                table: "branches");

            migrationBuilder.RenameTable(
                name: "branches",
                newName: "Branches");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Branches",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "Id");
        }
    }
}
