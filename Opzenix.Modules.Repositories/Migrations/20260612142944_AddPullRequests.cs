using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opzenix.Modules.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddPullRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PullRequests",
                table: "PullRequests");

            migrationBuilder.RenameTable(
                name: "PullRequests",
                newName: "pull_requests");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "pull_requests",
                newName: "Url");

            migrationBuilder.AddColumn<long>(
                name: "GitHubId",
                table: "pull_requests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "pull_requests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pull_requests",
                table: "pull_requests",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_pull_requests",
                table: "pull_requests");

            migrationBuilder.DropColumn(
                name: "GitHubId",
                table: "pull_requests");

            migrationBuilder.DropColumn(
                name: "State",
                table: "pull_requests");

            migrationBuilder.RenameTable(
                name: "pull_requests",
                newName: "PullRequests");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "PullRequests",
                newName: "Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PullRequests",
                table: "PullRequests",
                column: "Id");
        }
    }
}
