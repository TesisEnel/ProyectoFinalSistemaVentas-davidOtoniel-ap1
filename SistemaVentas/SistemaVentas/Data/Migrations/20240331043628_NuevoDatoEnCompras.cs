using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Migrations
{
    /// <inheritdoc />
    public partial class NuevoDatoEnCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Compras",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "TiposContribuyente",
                keyColumn: "TipoContribuyenteId",
                keyValue: 1,
                column: "Descripcion",
                value: "Persona Fisica");

            migrationBuilder.UpdateData(
                table: "TiposContribuyente",
                keyColumn: "TipoContribuyenteId",
                keyValue: 2,
                column: "Descripcion",
                value: "Persona Juridica");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Compras");

            migrationBuilder.UpdateData(
                table: "TiposContribuyente",
                keyColumn: "TipoContribuyenteId",
                keyValue: 1,
                column: "Descripcion",
                value: "Persona Física");

            migrationBuilder.UpdateData(
                table: "TiposContribuyente",
                keyColumn: "TipoContribuyenteId",
                keyValue: 2,
                column: "Descripcion",
                value: "Persona Jurídica");
        }
    }
}
