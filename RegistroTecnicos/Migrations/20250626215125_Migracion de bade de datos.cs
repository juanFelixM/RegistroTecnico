using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class Migraciondebadededatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VentasDetalles",
                newName: "DetalleId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "VentasDetalles",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<decimal>(
                name: "Monto",
                table: "VentasDetalles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Monto",
                table: "Ventas",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Ventas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Sistemas",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<decimal>(
                name: "Monto",
                table: "Sistemas",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Sistemas",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalles_SistemaId",
                table: "VentasDetalles",
                column: "SistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalles_VentaId",
                table: "VentasDetalles",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentasDetalles_Sistemas_SistemaId",
                table: "VentasDetalles",
                column: "SistemaId",
                principalTable: "Sistemas",
                principalColumn: "SistemaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentasDetalles_Ventas_VentaId",
                table: "VentasDetalles",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "VentaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_VentasDetalles_Sistemas_SistemaId",
                table: "VentasDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_VentasDetalles_Ventas_VentaId",
                table: "VentasDetalles");

            migrationBuilder.DropIndex(
                name: "IX_VentasDetalles_SistemaId",
                table: "VentasDetalles");

            migrationBuilder.DropIndex(
                name: "IX_VentasDetalles_VentaId",
                table: "VentasDetalles");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Monto",
                table: "VentasDetalles");

            migrationBuilder.DropColumn(
                name: "Monto",
                table: "Sistemas");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Sistemas");

            migrationBuilder.RenameColumn(
                name: "DetalleId",
                table: "VentasDetalles",
                newName: "Id");

            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "VentasDetalles",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "Monto",
                table: "Ventas",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "ClienteId",
                table: "Ventas",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Sistemas",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
