using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanTomas.Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MainCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único da categoria principal")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MainCategoryName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nome da categoria principal (ex: TI, Concurso, Finanças, etc.)")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategories", x => x.Id);
                },
                comment: "Tabela que armazena as categorias principais dos cursos")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único da plataforma")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlatformName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nome da plataforma onde o curso é oferecido (ex: Alura, Udemy, etc.)")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Url do site da plataforma")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                },
                comment: "Tabela que armazena as plataformas onde os cursos são oferecidos")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do usuário")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Nome completo do usuário")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Endereço de e-mail do usuário")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false, comment: "Hash da senha do usuário")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegisterDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "Data de cadastro do usuário")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                },
                comment: "Tabela que armazena os usuários do sistema")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único da categoria")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nome da categoria do curso. Ex: Angular, C#, Agile, etc")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Referência à categoria principal/pai vinculada à categoria")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_MainCategories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tabela que armazena as categorias de cursos disponíveis")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do curso")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Url do curso no site da plataforma ou outro")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlatformId = table.Column<int>(type: "int", nullable: false, comment: "Referência à plataforma do curso"),
                    Hours = table.Column<decimal>(type: "decimal(65,30)", nullable: false, comment: "Horas totais oferecidas pelo curso")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tabela que armazena os cursos e suas informações")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CoursesCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único da relação curso e categoria")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(type: "int", nullable: false, comment: "Referência a um dos cursos que a categoria está relacionada"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Referência uma das categorias que o curso está relacionado")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesCategories_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tabela associativa que armazena as associações entre cursos e categorias")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CoursesUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único da relação curso e usuário")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(type: "int", nullable: false, comment: "Referência ao curso que o usuário se matriculou"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "Referência o usuário que está fazendo o curso"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "Data de início do curso"),
                    CompletionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "Data de conclusão do curso"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "Status do curso -> 0 = Concluído ; 1 = Planejado ; 2 = Em andamento"),
                    HoursWorked = table.Column<decimal>(type: "decimal(6,2)", nullable: false, comment: "Total de horas que o usuário viu o curso"),
                    Progress = table.Column<decimal>(type: "decimal(5,2)", nullable: false, comment: "Progresso do curso em porcentagem")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesUsers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoursesUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Tabela associativa que armazena as associações entre cursos e usuários")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do certificado")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseUserId = table.Column<int>(type: "int", nullable: false, comment: "Refêrencia ao curso do usuário ao qual o certificado pertence"),
                    FilePath = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Caminho para o arquivo do certificado")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UploadDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_CoursesUsers_CourseUserId",
                        column: x => x.CourseUserId,
                        principalTable: "CoursesUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tabela que armazena os certificados dos cursos")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryName",
                table: "Categories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MainCategoryId",
                table: "Categories",
                column: "MainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CourseUserId",
                table: "Certificates",
                column: "CourseUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PlatformId",
                table: "Courses",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesCategories_CategoryId",
                table: "CoursesCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesCategories_CourseId",
                table: "CoursesCategories",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesUsers_CourseId",
                table: "CoursesUsers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesUsers_UserId",
                table: "CoursesUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCategories_MainCategoryName",
                table: "MainCategories",
                column: "MainCategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_PlatformName",
                table: "Platforms",
                column: "PlatformName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "CoursesCategories");

            migrationBuilder.DropTable(
                name: "CoursesUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MainCategories");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
