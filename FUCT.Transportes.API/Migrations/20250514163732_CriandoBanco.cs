using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FUCT.Transportes.API.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargueiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidade = table.Column<double>(type: "float", nullable: false),
                    TipoMinérioCompatível = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargueiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Minerios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caracteristica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoPorKg = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minerios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRetorno = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CargueiroId = table.Column<int>(type: "int", nullable: false),
                    MinérioId = table.Column<int>(type: "int", nullable: false),
                    QuantidadeTransportada = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportes_Cargueiros_CargueiroId",
                        column: x => x.CargueiroId,
                        principalTable: "Cargueiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transportes_Minerios_MinérioId",
                        column: x => x.MinérioId,
                        principalTable: "Minerios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cargueiros",
                columns: new[] { "Id", "Capacidade", "Classe", "TipoMinérioCompatível" },
                values: new object[,]
                {
                    { 1, 5.0, "I", "D" },
                    { 2, 3.0, "II", "A" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transportes_CargueiroId",
                table: "Transportes",
                column: "CargueiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportes_MinérioId",
                table: "Transportes",
                column: "MinérioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transportes");

            migrationBuilder.DropTable(
                name: "Cargueiros");

            migrationBuilder.DropTable(
                name: "Minerios");
        }
    }
}
