using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoCedulaAProveedores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NombreEmpresa",
                table: "Proveedores",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Encargado",
                table: "Proveedores",
                type: "nvarchar(18)",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Proveedores",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AddColumn<string>(
                name: "CedulaEncargado",
                table: "Proveedores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CedulaEncargado",
                table: "Proveedores");

            migrationBuilder.AlterColumn<string>(
                name: "NombreEmpresa",
                table: "Proveedores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "Encargado",
                table: "Proveedores",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(18)",
                oldMaxLength: 18);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Proveedores",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);
        }
    }
}
