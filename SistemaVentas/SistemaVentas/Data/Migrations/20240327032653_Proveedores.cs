using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Migrations
{
    /// <inheritdoc />
    public partial class Proveedores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TipoContribuyente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RNC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "ProveedoresDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    ContactoId = table.Column<int>(type: "int", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedoresDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_ProveedoresDetalle_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProveedoresDetalle_ProveedorId",
                table: "ProveedoresDetalle",
                column: "ProveedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProveedoresDetalle");

            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
