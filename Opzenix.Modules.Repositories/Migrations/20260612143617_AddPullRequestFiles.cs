using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opzenix.Modules.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddPullRequestFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pull_request_files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PullRequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Additions = table.Column<int>(type: "integer", nullable: false),
                    Deletions = table.Column<int>(type: "integer", nullable: false),
                    Changes = table.Column<int>(type: "integer", nullable: false),
                    Patch = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pull_request_files", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pull_request_files");
        }
    }
}
