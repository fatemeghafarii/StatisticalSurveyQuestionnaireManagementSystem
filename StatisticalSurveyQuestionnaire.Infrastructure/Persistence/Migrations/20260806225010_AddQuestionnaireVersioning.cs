using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionnaireVersioning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Questionnaires_QuestionnaireId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResponses_Questionnaires_QuestionnaireId",
                table: "SurveyResponses");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResponses_HouseholdId_QuestionnaireId_SurveyPeriodId",
                table: "SurveyResponses");

            migrationBuilder.RenameColumn(
                name: "QuestionnaireId",
                table: "Questions",
                newName: "QuestionnaireVersionId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_QuestionnaireId_Order",
                table: "Questions",
                newName: "IX_Questions_QuestionnaireVersionId_Order");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionnaireId",
                table: "SurveyResponses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "QuestionnaireVersionId",
                table: "SurveyResponses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QuestionnaireVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionnaireId = table.Column<int>(type: "int", nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionnaireVersions_Questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponses_HouseholdId_QuestionnaireVersionId_SurveyPeriodId",
                table: "SurveyResponses",
                columns: new[] { "HouseholdId", "QuestionnaireVersionId", "SurveyPeriodId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponses_QuestionnaireVersionId",
                table: "SurveyResponses",
                column: "QuestionnaireVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireVersions_QuestionnaireId_VersionNumber",
                table: "QuestionnaireVersions",
                columns: new[] { "QuestionnaireId", "VersionNumber" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionnaireVersions_QuestionnaireVersionId",
                table: "Questions",
                column: "QuestionnaireVersionId",
                principalTable: "QuestionnaireVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResponses_QuestionnaireVersions_QuestionnaireVersionId",
                table: "SurveyResponses",
                column: "QuestionnaireVersionId",
                principalTable: "QuestionnaireVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResponses_Questionnaires_QuestionnaireId",
                table: "SurveyResponses",
                column: "QuestionnaireId",
                principalTable: "Questionnaires",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionnaireVersions_QuestionnaireVersionId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResponses_QuestionnaireVersions_QuestionnaireVersionId",
                table: "SurveyResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResponses_Questionnaires_QuestionnaireId",
                table: "SurveyResponses");

            migrationBuilder.DropTable(
                name: "QuestionnaireVersions");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResponses_HouseholdId_QuestionnaireVersionId_SurveyPeriodId",
                table: "SurveyResponses");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResponses_QuestionnaireVersionId",
                table: "SurveyResponses");

            migrationBuilder.DropColumn(
                name: "QuestionnaireVersionId",
                table: "SurveyResponses");

            migrationBuilder.RenameColumn(
                name: "QuestionnaireVersionId",
                table: "Questions",
                newName: "QuestionnaireId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_QuestionnaireVersionId_Order",
                table: "Questions",
                newName: "IX_Questions_QuestionnaireId_Order");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionnaireId",
                table: "SurveyResponses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponses_HouseholdId_QuestionnaireId_SurveyPeriodId",
                table: "SurveyResponses",
                columns: new[] { "HouseholdId", "QuestionnaireId", "SurveyPeriodId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Questionnaires_QuestionnaireId",
                table: "Questions",
                column: "QuestionnaireId",
                principalTable: "Questionnaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResponses_Questionnaires_QuestionnaireId",
                table: "SurveyResponses",
                column: "QuestionnaireId",
                principalTable: "Questionnaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
