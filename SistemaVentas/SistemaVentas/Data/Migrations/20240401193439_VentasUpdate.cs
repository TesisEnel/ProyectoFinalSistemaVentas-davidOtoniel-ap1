using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Migrations
{
    /// <inheritdoc />
    public partial class VentasUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_CuentasPorPagar_CuentaPorPagarId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_CuentaPorPagarId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_CuentasPorCobrar_VentaId",
                table: "CuentasPorCobrar");

            migrationBuilder.DropColumn(
                name: "CuentaPorPagarId",
                table: "Ventas");

            migrationBuilder.CreateIndex(
                name: "IX_CuentasPorCobrar_VentaId",
                table: "CuentasPorCobrar",
                column: "VentaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CuentasPorCobrar_VentaId",
                table: "CuentasPorCobrar");

            migrationBuilder.AddColumn<int>(
                name: "CuentaPorPagarId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_CuentaPorPagarId",
                table: "Ventas",
                column: "CuentaPorPagarId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentasPorCobrar_VentaId",
                table: "CuentasPorCobrar",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_CuentasPorPagar_CuentaPorPagarId",
                table: "Ventas",
                column: "CuentaPorPagarId",
                principalTable: "CuentasPorPagar",
                principalColumn: "CuentaPorPagarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
