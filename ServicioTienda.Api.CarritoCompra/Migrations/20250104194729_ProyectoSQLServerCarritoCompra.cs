using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioTienda.Api.CarritoCompra.Migrations
{
    /// <inheritdoc />
    public partial class ProyectoSQLServerCarritoCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarritoSesions",
                columns: table => new
                {
                    CarritoSesionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoSesions", x => x.CarritoSesionId);
                });

            migrationBuilder.CreateTable(
                name: "CarritoSesionDetalles",
                columns: table => new
                {
                    CarritoSesionDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CarritoSesionId = table.Column<int>(type: "int", nullable: false),
                    libroSeleccionado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoSesionDetalles", x => x.CarritoSesionDetalleId);
                    table.ForeignKey(
                        name: "FK_CarritoSesionDetalles_CarritoSesions_CarritoSesionId",
                        column: x => x.CarritoSesionId,
                        principalTable: "CarritoSesions",
                        principalColumn: "CarritoSesionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoSesionDetalles_CarritoSesionId",
                table: "CarritoSesionDetalles",
                column: "CarritoSesionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoSesionDetalles");

            migrationBuilder.DropTable(
                name: "CarritoSesions");
        }
    }
}
