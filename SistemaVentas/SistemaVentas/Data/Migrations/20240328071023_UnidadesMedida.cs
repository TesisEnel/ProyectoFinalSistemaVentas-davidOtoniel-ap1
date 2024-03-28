using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaVentas.Migrations
{
    /// <inheritdoc />
    public partial class UnidadesMedida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnidadesMedida",
                columns: table => new
                {
                    UnidadMedidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidadMedida = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedida", x => x.UnidadMedidaId);
                });

            migrationBuilder.InsertData(
                table: "UnidadesMedida",
                columns: new[] { "UnidadMedidaId", "UnidadMedida" },
                values: new object[,]
                {
                    { 1, "Caja" },
                    { 2, "Pieza" },
                    { 3, "Gramo" },
                    { 4, "Metro" },
                    { 5, "Libra" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnidadesMedida");
        }
    }
}
