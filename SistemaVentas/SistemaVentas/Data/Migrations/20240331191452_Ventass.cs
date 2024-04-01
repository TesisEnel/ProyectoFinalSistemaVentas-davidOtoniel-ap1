using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Migrations
{
    /// <inheritdoc />
    public partial class Ventass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "VentasDetalle");

            migrationBuilder.DropColumn(
                name: "Devolucion",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Pago",
                table: "Ventas");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Ventas",
                newName: "FechaCreacion");

            migrationBuilder.AddColumn<int>(
                name: "CantidadProducto",
                table: "VentasDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CantidadUnidadProducto",
                table: "VentasDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CostoTotal",
                table: "VentasDetalle",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CostoTotalNeto",
                table: "VentasDetalle",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CostoUnidad",
                table: "VentasDetalle",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Itbis",
                table: "VentasDetalle",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UnidadMedidaId",
                table: "VentasDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "SubTotal",
                table: "Ventas",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CuentaPorPagarId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Deuda",
                table: "Ventas",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Devuelta",
                table: "Ventas",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "EmpleadoResponsable",
                table: "Ventas",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Ventas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MetodoPagoId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoPagado",
                table: "Ventas",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Nota",
                table: "Ventas",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalItbis",
                table: "Ventas",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalNeto",
                table: "Ventas",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_CuentaPorPagarId",
                table: "Ventas",
                column: "CuentaPorPagarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_CuentasPorPagar_CuentaPorPagarId",
                table: "Ventas",
                column: "CuentaPorPagarId",
                principalTable: "CuentasPorPagar",
                principalColumn: "CuentaPorPagarId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_CuentasPorPagar_CuentaPorPagarId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_CuentaPorPagarId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "CantidadProducto",
                table: "VentasDetalle");

            migrationBuilder.DropColumn(
                name: "CantidadUnidadProducto",
                table: "VentasDetalle");

            migrationBuilder.DropColumn(
                name: "CostoTotal",
                table: "VentasDetalle");

            migrationBuilder.DropColumn(
                name: "CostoTotalNeto",
                table: "VentasDetalle");

            migrationBuilder.DropColumn(
                name: "CostoUnidad",
                table: "VentasDetalle");

            migrationBuilder.DropColumn(
                name: "Itbis",
                table: "VentasDetalle");

            migrationBuilder.DropColumn(
                name: "UnidadMedidaId",
                table: "VentasDetalle");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "CuentaPorPagarId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Deuda",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Devuelta",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "EmpleadoResponsable",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "MetodoPagoId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "MontoPagado",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "TotalItbis",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "TotalNeto",
                table: "Ventas");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Ventas",
                newName: "Fecha");

            migrationBuilder.AddColumn<float>(
                name: "Cantidad",
                table: "VentasDetalle",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "SubTotal",
                table: "Ventas",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddColumn<float>(
                name: "Devolucion",
                table: "Ventas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Pago",
                table: "Ventas",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
