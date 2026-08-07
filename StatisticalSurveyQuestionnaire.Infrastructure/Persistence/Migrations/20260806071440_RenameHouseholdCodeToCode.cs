using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameHouseholdCodeToCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HouseholdCode",
                table: "Households",
                newName: "Code");

            migrationBuilder.RenameIndex(
                name: "IX_Households_HouseholdCode",
                table: "Households",
                newName: "IX_Households_Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Households",
                newName: "HouseholdCode");

            migrationBuilder.RenameIndex(
                name: "IX_Households_Code",
                table: "Households",
                newName: "IX_Households_HouseholdCode");
        }
    }
}
