using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opzenix.Modules.Reviews.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "reviews",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "reviews");
        }
    }
}
