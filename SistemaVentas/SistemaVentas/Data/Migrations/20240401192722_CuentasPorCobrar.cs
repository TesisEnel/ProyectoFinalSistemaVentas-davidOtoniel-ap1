using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Migrations
{
    /// <inheritdoc />
    public partial class CuentasPorCobrar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CuentasPorCobrar",
                columns: table => new
                {
                    CuentaPorCobrarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    DeudaInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeudaRestante = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasPorCobrar", x => x.CuentaPorCobrarId);
                    table.ForeignKey(
                        name: "FK_CuentasPorCobrar_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuentasPorCobrarDetalle",
                columns: table => new
                {
                    CuentasPorCobrarDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuentaPorCobrarId = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Abono = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasPorCobrarDetalle", x => x.CuentasPorCobrarDetalleId);
                    table.ForeignKey(
                        name: "FK_CuentasPorCobrarDetalle_CuentasPorCobrar_CuentaPorCobrarId",
                        column: x => x.CuentaPorCobrarId,
                        principalTable: "CuentasPorCobrar",
                        principalColumn: "CuentaPorCobrarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentasPorCobrar_VentaId",
                table: "CuentasPorCobrar",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentasPorCobrarDetalle_CuentaPorCobrarId",
                table: "CuentasPorCobrarDetalle",
                column: "CuentaPorCobrarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuentasPorCobrarDetalle");

            migrationBuilder.DropTable(
                name: "CuentasPorCobrar");
        }
    }
}
