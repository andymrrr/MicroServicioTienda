using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ServicioTienda.Api.Autor.Migrations
{
    /// <inheritdoc />
    public partial class inicialPosgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutorLibros",
                columns: table => new
                {
                    AutorlibroId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AutorlibroGuid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLibros", x => x.AutorlibroId);
                });

            migrationBuilder.CreateTable(
                name: "GradoAcademicos",
                columns: table => new
                {
                    GradoAcademicoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    CentroAcademico = table.Column<string>(type: "text", nullable: false),
                    FechaGrado = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AutorlibroId = table.Column<int>(type: "integer", nullable: false),
                    GradoAcademicoGuid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradoAcademicos", x => x.GradoAcademicoId);
                    table.ForeignKey(
                        name: "FK_GradoAcademicos_AutorLibros_AutorlibroId",
                        column: x => x.AutorlibroId,
                        principalTable: "AutorLibros",
                        principalColumn: "AutorlibroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradoAcademicos_AutorlibroId",
                table: "GradoAcademicos",
                column: "AutorlibroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradoAcademicos");

            migrationBuilder.DropTable(
                name: "AutorLibros");
        }
    }
}
