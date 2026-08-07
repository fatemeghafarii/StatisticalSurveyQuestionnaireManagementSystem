using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSurveyManagementEntitiesAndLookupFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Households_HouseholdId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Households");

            migrationBuilder.RenameColumn(
                name: "HouseholdId",
                table: "Answers",
                newName: "SurveyResponseId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_HouseholdId_QuestionId",
                table: "Answers",
                newName: "IX_Answers_SurveyResponseId_QuestionId");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Provinces",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MaritalStatuses",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOptionId",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "SurveyPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyResponseStatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResponseStatusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseholdId = table.Column<int>(type: "int", nullable: false),
                    QuestionnaireId = table.Column<int>(type: "int", nullable: false),
                    SurveyPeriodId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyResponses_Households_HouseholdId",
                        column: x => x.HouseholdId,
                        principalTable: "Households",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyResponses_Questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyResponses_SurveyPeriods_SurveyPeriodId",
                        column: x => x.SurveyPeriodId,
                        principalTable: "SurveyPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyResponses_SurveyResponseStatusTypes_StatusId",
                        column: x => x.StatusId,
                        principalTable: "SurveyResponseStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyPeriods_Title",
                table: "SurveyPeriods",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponses_HouseholdId_QuestionnaireId_SurveyPeriodId",
                table: "SurveyResponses",
                columns: new[] { "HouseholdId", "QuestionnaireId", "SurveyPeriodId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponses_QuestionnaireId",
                table: "SurveyResponses",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponses_StatusId",
                table: "SurveyResponses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponses_SurveyPeriodId",
                table: "SurveyResponses",
                column: "SurveyPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponseStatusTypes_Order",
                table: "SurveyResponseStatusTypes",
                column: "Order",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponseStatusTypes_Title",
                table: "SurveyResponseStatusTypes",
                column: "Title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_SurveyResponses_SurveyResponseId",
                table: "Answers",
                column: "SurveyResponseId",
                principalTable: "SurveyResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_SurveyResponses_SurveyResponseId",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "SurveyResponses");

            migrationBuilder.DropTable(
                name: "SurveyPeriods");

            migrationBuilder.DropTable(
                name: "SurveyResponseStatusTypes");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MaritalStatuses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "SurveyResponseId",
                table: "Answers",
                newName: "HouseholdId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_SurveyResponseId_QuestionId",
                table: "Answers",
                newName: "IX_Answers_HouseholdId_QuestionId");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "Households",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOptionId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Households_HouseholdId",
                table: "Answers",
                column: "HouseholdId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
