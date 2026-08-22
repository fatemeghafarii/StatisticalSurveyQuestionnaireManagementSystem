using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAnswerOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_QuestionOptions_QuestionOptionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResponses_Questionnaires_QuestionnaireId",
                table: "SurveyResponses");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResponseStatusTypes_Order",
                table: "SurveyResponseStatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResponseStatusTypes_Title",
                table: "SurveyResponseStatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResponses_QuestionnaireId",
                table: "SurveyResponses");

            migrationBuilder.DropIndex(
                name: "IX_Roles_Title",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_QuestionTypes_Title",
                table: "QuestionTypes");

            migrationBuilder.DropIndex(
                name: "IX_QuestionnaireVersionStatusTypes_Code",
                table: "QuestionnaireVersionStatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_QuestionnaireVersionStatusTypes_Order",
                table: "QuestionnaireVersionStatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_QuestionnaireVersionStatusTypes_Title",
                table: "QuestionnaireVersionStatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_MaritalStatuses_Title_Order",
                table: "MaritalStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_Code",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_EducationLevels_Title_Order",
                table: "EducationLevels");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionOptionId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "SurveyResponseStatusTypes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "SurveyResponses");

            migrationBuilder.DropColumn(
                name: "QuestionnaireId",
                table: "SurveyResponses");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "SurveyPeriods");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "QuestionTypes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "QuestionOptions");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "QuestionnaireVersionStatusTypes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "QuestionnaireVersions");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Job",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MaritalStatuses");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Households");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "EducationLevels");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "QuestionOptionId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "SurveyResponseStatusTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "SurveyResponses",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "SurveyPeriods",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Roles",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "QuestionTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Questions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "QuestionOptions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "QuestionnaireVersionStatusTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "QuestionnaireVersions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Questionnaires",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Provinces",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Persons",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "MaritalStatuses",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Jobs",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Households",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "EducationLevels",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Cities",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Answers",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "SurveyResponseStatusTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SurveyResponseStatusTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "SurveyResponseStatusTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "SurveyResponses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "SurveyResponses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "SurveyPeriods",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "SurveyPeriods",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Roles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "QuestionTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "QuestionTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "QuestionTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "QuestionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Questions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "QuestionOptions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "QuestionOptions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "QuestionnaireVersionStatusTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "QuestionnaireVersionStatusTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "QuestionnaireVersions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "QuestionnaireVersions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Questionnaires",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Questionnaires",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Provinces",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Provinces",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Persons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "MaritalStatuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MaritalStatuses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "MaritalStatuses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Jobs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Households",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Households",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "EducationLevels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "EducationLevels",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "EducationLevels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Answers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnswerOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    QuestionOptionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerOptions_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerOptions_QuestionOptions_QuestionOptionId",
                        column: x => x.QuestionOptionId,
                        principalTable: "QuestionOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponseStatusTypes_Code_Title_Order",
                table: "SurveyResponseStatusTypes",
                columns: new[] { "Code", "Title", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Code_Title_Order",
                table: "Roles",
                columns: new[] { "Code", "Title", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTypes_Code_Title_Order",
                table: "QuestionTypes",
                columns: new[] { "Code", "Title", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireVersionStatusTypes_Code_Title_Order",
                table: "QuestionnaireVersionStatusTypes",
                columns: new[] { "Code", "Title", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_JobId",
                table: "Persons",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_MaritalStatuses_Code_Title_Order",
                table: "MaritalStatuses",
                columns: new[] { "Code", "Title", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Code",
                table: "Jobs",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EducationLevels_Code_Title_Order",
                table: "EducationLevels",
                columns: new[] { "Code", "Title", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnswerOptions_AnswerId_QuestionOptionId",
                table: "AnswerOptions",
                columns: new[] { "AnswerId", "QuestionOptionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnswerOptions_QuestionOptionId",
                table: "AnswerOptions",
                column: "QuestionOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Jobs_JobId",
                table: "Persons",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Jobs_JobId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "AnswerOptions");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResponseStatusTypes_Code_Title_Order",
                table: "SurveyResponseStatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_Roles_Code_Title_Order",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_QuestionTypes_Code_Title_Order",
                table: "QuestionTypes");

            migrationBuilder.DropIndex(
                name: "IX_QuestionnaireVersionStatusTypes_Code_Title_Order",
                table: "QuestionnaireVersionStatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_Persons_JobId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_MaritalStatuses_Code_Title_Order",
                table: "MaritalStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_Code",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_EducationLevels_Code_Title_Order",
                table: "EducationLevels");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SurveyResponseStatusTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "SurveyResponseStatusTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "SurveyResponses");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "SurveyPeriods");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "QuestionTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "QuestionTypes");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "QuestionTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "QuestionOptions");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "QuestionnaireVersionStatusTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "QuestionnaireVersions");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "MaritalStatuses");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "MaritalStatuses");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Households");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "EducationLevels");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "EducationLevels");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "SurveyResponseStatusTypes",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "SurveyResponses",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "SurveyPeriods",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Roles",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "QuestionTypes",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Questions",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "QuestionOptions",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "QuestionnaireVersionStatusTypes",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "QuestionnaireVersions",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Questionnaires",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Provinces",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Persons",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "MaritalStatuses",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Jobs",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Households",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "EducationLevels",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Cities",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Answers",
                newName: "ModifiedDate");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "SurveyResponseStatusTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "SurveyResponseStatusTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "SurveyResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "SurveyResponses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "QuestionnaireId",
                table: "SurveyResponses",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "SurveyPeriods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "SurveyPeriods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "QuestionTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "QuestionTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Questions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "QuestionOptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "QuestionOptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "QuestionnaireVersionStatusTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "QuestionnaireVersionStatusTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "QuestionnaireVersions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "QuestionnaireVersions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Questionnaires",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Questionnaires",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Provinces",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Provinces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "MaritalStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MaritalStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Jobs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Jobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Households",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Households",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "EducationLevels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "EducationLevels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Answers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "QuestionOptionId",
                table: "Answers",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponses_QuestionnaireId",
                table: "SurveyResponses",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Title",
                table: "Roles",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTypes_Title",
                table: "QuestionTypes",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireVersionStatusTypes_Code",
                table: "QuestionnaireVersionStatusTypes",
                column: "Code",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_MaritalStatuses_Title_Order",
                table: "MaritalStatuses",
                columns: new[] { "Title", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Code",
                table: "Jobs",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EducationLevels_Title_Order",
                table: "EducationLevels",
                columns: new[] { "Title", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionOptionId",
                table: "Answers",
                column: "QuestionOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_QuestionOptions_QuestionOptionId",
                table: "Answers",
                column: "QuestionOptionId",
                principalTable: "QuestionOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResponses_Questionnaires_QuestionnaireId",
                table: "SurveyResponses",
                column: "QuestionnaireId",
                principalTable: "Questionnaires",
                principalColumn: "Id");
        }
    }
}
