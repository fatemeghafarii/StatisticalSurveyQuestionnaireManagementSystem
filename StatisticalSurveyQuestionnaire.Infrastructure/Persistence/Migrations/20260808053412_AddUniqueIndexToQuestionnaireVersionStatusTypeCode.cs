using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToQuestionnaireVersionStatusTypeCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireVersionStatusTypes_Code",
                table: "QuestionnaireVersionStatusTypes",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuestionnaireVersionStatusTypes_Code",
                table: "QuestionnaireVersionStatusTypes");
        }
    }
}
