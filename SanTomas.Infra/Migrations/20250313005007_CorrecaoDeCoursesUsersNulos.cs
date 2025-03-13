using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanTomas.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoDeCoursesUsersNulos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "CoursesUsers",
                type: "datetime(6)",
                nullable: true,
                comment: "Data de início do curso",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldComment: "Data de início do curso");

            migrationBuilder.AlterColumn<decimal>(
                name: "Progress",
                table: "CoursesUsers",
                type: "decimal(5,2)",
                nullable: true,
                comment: "Progresso do curso em porcentagem",
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldComment: "Progresso do curso em porcentagem");

            migrationBuilder.AlterColumn<decimal>(
                name: "HoursWorked",
                table: "CoursesUsers",
                type: "decimal(6,2)",
                nullable: true,
                comment: "Total de horas que o usuário viu o curso",
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldComment: "Total de horas que o usuário viu o curso");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletionDate",
                table: "CoursesUsers",
                type: "datetime(6)",
                nullable: true,
                comment: "Data de conclusão do curso",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldComment: "Data de conclusão do curso");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hours",
                table: "Courses",
                type: "decimal(6,2)",
                nullable: false,
                comment: "Horas totais oferecidas pelo curso",
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldComment: "Horas totais oferecidas pelo curso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "CoursesUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data de início do curso",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldComment: "Data de início do curso");

            migrationBuilder.AlterColumn<decimal>(
                name: "Progress",
                table: "CoursesUsers",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Progresso do curso em porcentagem",
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldNullable: true,
                oldComment: "Progresso do curso em porcentagem");

            migrationBuilder.AlterColumn<decimal>(
                name: "HoursWorked",
                table: "CoursesUsers",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Total de horas que o usuário viu o curso",
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldNullable: true,
                oldComment: "Total de horas que o usuário viu o curso");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletionDate",
                table: "CoursesUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data de conclusão do curso",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldComment: "Data de conclusão do curso");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hours",
                table: "Courses",
                type: "decimal(65,30)",
                nullable: false,
                comment: "Horas totais oferecidas pelo curso",
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldComment: "Horas totais oferecidas pelo curso");
        }
    }
}
