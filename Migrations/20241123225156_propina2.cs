using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lista_De_Tareas.Migrations
{
    /// <inheritdoc />
    public partial class propina2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PorcentajePropina",
                table: "Propina",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "MontoPropina",
                table: "Propina",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoTotalConPropina",
                table: "Propina",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoPropina",
                table: "Propina");

            migrationBuilder.DropColumn(
                name: "MontoTotalConPropina",
                table: "Propina");

            migrationBuilder.AlterColumn<decimal>(
                name: "PorcentajePropina",
                table: "Propina",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);
        }
    }
}
