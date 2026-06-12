using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opzenix.Modules.Reviews.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewMetrics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAtUtc",
                table: "reviews",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilesAnalyzed",
                table: "reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FindingsCount",
                table: "reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LinesAnalyzed",
                table: "reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAtUtc",
                table: "reviews",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedAtUtc",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "FilesAnalyzed",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "FindingsCount",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "LinesAnalyzed",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "StartedAtUtc",
                table: "reviews");
        }
    }
}
