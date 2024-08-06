using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvBeacon.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSkill_Skill_SkillsId",
                table: "ApplicantSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSkill_User_ApplicantsId",
                table: "ApplicantSkill");

            migrationBuilder.RenameColumn(
                name: "SkillsId",
                table: "ApplicantSkill",
                newName: "SkillId");

            migrationBuilder.RenameColumn(
                name: "ApplicantsId",
                table: "ApplicantSkill",
                newName: "ApplicantId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantSkill_SkillsId",
                table: "ApplicantSkill",
                newName: "IX_ApplicantSkill_SkillId");

            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Skill",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Skill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Skill",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "Skill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Skill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "JobOffer",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "JobOffer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "JobOffer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "JobOffer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "JobOffer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "JobApplication",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "JobApplication",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "JobApplication",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "JobApplication",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Experience",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Experience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Experience",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "Experience",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Experience",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Education",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Education",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "Education",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Education",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantSkill_Skill_SkillId",
                table: "ApplicantSkill",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantSkill_User_ApplicantId",
                table: "ApplicantSkill",
                column: "ApplicantId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSkill_Skill_SkillId",
                table: "ApplicantSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSkill_User_ApplicantId",
                table: "ApplicantSkill");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Education");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "ApplicantSkill",
                newName: "SkillsId");

            migrationBuilder.RenameColumn(
                name: "ApplicantId",
                table: "ApplicantSkill",
                newName: "ApplicantsId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantSkill_SkillId",
                table: "ApplicantSkill",
                newName: "IX_ApplicantSkill_SkillsId");

            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "User",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Skill",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "JobOffer",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Experience",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Education",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantSkill_Skill_SkillsId",
                table: "ApplicantSkill",
                column: "SkillsId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantSkill_User_ApplicantsId",
                table: "ApplicantSkill",
                column: "ApplicantsId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
