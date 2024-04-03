using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionTiposContribuyenteProveedoresNumeros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "TiposContribuyente",
                newName: "TipoContribuyente");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Proveedores",
                newName: "Encargado");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Contactos",
                newName: "TipoNumero");

            migrationBuilder.RenameColumn(
                name: "ContactoId",
                table: "Contactos",
                newName: "NumeroId");

            migrationBuilder.AddColumn<string>(
                name: "NombreEmpresa",
                table: "Proveedores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Proveedores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreEmpresa",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "Proveedores");

            migrationBuilder.RenameColumn(
                name: "TipoContribuyente",
                table: "TiposContribuyente",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "Encargado",
                table: "Proveedores",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "TipoNumero",
                table: "Contactos",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "NumeroId",
                table: "Contactos",
                newName: "ContactoId");
        }
    }
}
