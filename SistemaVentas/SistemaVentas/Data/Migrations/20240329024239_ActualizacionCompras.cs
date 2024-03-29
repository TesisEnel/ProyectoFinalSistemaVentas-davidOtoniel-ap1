using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnidadMedida",
                table: "ComprasDetalle");

            migrationBuilder.DropColumn(
                name: "DireccionProveedor",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "MetodoPago",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "NombreProveedor",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "RNC",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "TipoContribuyente",
                table: "Compras");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "ComprasDetalle",
                newName: "CostoUnidad");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "ComprasDetalle",
                newName: "UnidadMedidaId");

            migrationBuilder.AddColumn<int>(
                name: "CantidadProducto",
                table: "ComprasDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CantidadUnidadProducto",
                table: "ComprasDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CostoTotal",
                table: "ComprasDetalle",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "ComprasDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MetodoPagoId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadProducto",
                table: "ComprasDetalle");

            migrationBuilder.DropColumn(
                name: "CantidadUnidadProducto",
                table: "ComprasDetalle");

            migrationBuilder.DropColumn(
                name: "CostoTotal",
                table: "ComprasDetalle");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "ComprasDetalle");

            migrationBuilder.DropColumn(
                name: "MetodoPagoId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Compras");

            migrationBuilder.RenameColumn(
                name: "UnidadMedidaId",
                table: "ComprasDetalle",
                newName: "Cantidad");

            migrationBuilder.RenameColumn(
                name: "CostoUnidad",
                table: "ComprasDetalle",
                newName: "Precio");

            migrationBuilder.AddColumn<string>(
                name: "UnidadMedida",
                table: "ComprasDetalle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DireccionProveedor",
                table: "Compras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MetodoPago",
                table: "Compras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreProveedor",
                table: "Compras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RNC",
                table: "Compras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoContribuyente",
                table: "Compras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
