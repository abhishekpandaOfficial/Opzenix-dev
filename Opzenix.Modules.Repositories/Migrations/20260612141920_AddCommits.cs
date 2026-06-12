using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opzenix.Modules.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddCommits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Commits",
                table: "Commits");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Commits");

            migrationBuilder.RenameTable(
                name: "Commits",
                newName: "commits");

            migrationBuilder.RenameColumn(
                name: "CommittedAtUtc",
                table: "commits",
                newName: "CreatedAtUtc");

            migrationBuilder.AlterColumn<string>(
                name: "Sha",
                table: "commits",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "commits",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "commits",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_commits",
                table: "commits",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_commits",
                table: "commits");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "commits");

            migrationBuilder.RenameTable(
                name: "commits",
                newName: "Commits");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUtc",
                table: "Commits",
                newName: "CommittedAtUtc");

            migrationBuilder.AlterColumn<string>(
                name: "Sha",
                table: "Commits",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Commits",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Commits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commits",
                table: "Commits",
                column: "Id");
        }
    }
}
