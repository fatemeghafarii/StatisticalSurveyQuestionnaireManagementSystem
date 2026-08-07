using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCreatedDateFromQuestionnaire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Questionnaires");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Jobs");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Questionnaires",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
