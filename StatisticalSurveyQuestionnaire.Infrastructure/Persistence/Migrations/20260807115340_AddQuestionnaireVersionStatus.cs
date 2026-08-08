using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionnaireVersionStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "QuestionnaireVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QuestionnaireVersionStatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireVersionStatusTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireVersions_StatusId",
                table: "QuestionnaireVersions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireVersionStatusTypes_Order",
                table: "QuestionnaireVersionStatusTypes",
                column: "Order",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireVersionStatusTypes_Title",
                table: "QuestionnaireVersionStatusTypes",
                column: "Title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireVersions_QuestionnaireVersionStatusTypes_StatusId",
                table: "QuestionnaireVersions",
                column: "StatusId",
                principalTable: "QuestionnaireVersionStatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireVersions_QuestionnaireVersionStatusTypes_StatusId",
                table: "QuestionnaireVersions");

            migrationBuilder.DropTable(
                name: "QuestionnaireVersionStatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_QuestionnaireVersions_StatusId",
                table: "QuestionnaireVersions");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "QuestionnaireVersions");
        }
    }
}
