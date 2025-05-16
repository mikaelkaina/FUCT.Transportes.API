using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FUCT.Transportes.API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cargueiros",
                columns: new[] { "Id", "Capacidade", "Classe", "TipoMinérioCompatível" },
                values: new object[,]
                {
                    { 3, 2.0, "III", "C" },
                    { 4, 0.5, "IV", "B,C" }
                });

            migrationBuilder.InsertData(
                table: "Minerios",
                columns: new[] { "Id", "Caracteristica", "Nome", "PrecoPorKg" },
                values: new object[,]
                {
                    { 1, "Inflamável 🔥", "A", 5000.0 },
                    { 2, "Risco Biológico ☣", "B", 10000.0 },
                    { 3, "Refrigerado 🧊", "C", 3000.0 },
                    { 4, "Sem características especiais", "D", 100.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cargueiros",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cargueiros",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Minerios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Minerios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Minerios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Minerios",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
