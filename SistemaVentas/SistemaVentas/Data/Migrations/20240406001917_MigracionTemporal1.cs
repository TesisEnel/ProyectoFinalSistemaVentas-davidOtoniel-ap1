using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Migrations
{
    /// <inheritdoc />
    public partial class MigracionTemporal1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "Proveedores");

            migrationBuilder.RenameColumn(
                name: "Encargado",
                table: "Proveedores",
                newName: "Representante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Representante",
                table: "Proveedores",
                newName: "Encargado");

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Proveedores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
