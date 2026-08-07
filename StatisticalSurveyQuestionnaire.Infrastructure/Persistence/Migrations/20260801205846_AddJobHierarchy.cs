using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddJobHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Jobs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentJobId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ParentJobId",
                table: "Jobs",
                column: "ParentJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Jobs_ParentJobId",
                table: "Jobs",
                column: "ParentJobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Jobs_ParentJobId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ParentJobId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ParentJobId",
                table: "Jobs");
        }
    }
}
