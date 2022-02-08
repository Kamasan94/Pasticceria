using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pasticceria.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dolci",
                columns: table => new
                {
                    DolceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dolci", x => x.DolceId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredienti",
                columns: table => new
                {
                    IngredienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredienti", x => x.IngredienteId);
                });

            migrationBuilder.CreateTable(
                name: "Vetrina",
                columns: table => new
                {
                    VetrinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DolceId = table.Column<int>(type: "int", nullable: false),
                    Prezzo = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Quantita = table.Column<int>(type: "int", nullable: false),
                    MessaInVendita = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vetrina", x => x.VetrinaId);
                    table.ForeignKey(
                        name: "FK_Vetrina_Dolci_DolceId",
                        column: x => x.DolceId,
                        principalTable: "Dolci",
                        principalColumn: "DolceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ricette",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DolceId = table.Column<int>(type: "int", nullable: false),
                    IngredienteId = table.Column<int>(type: "int", nullable: false),
                    Quantita = table.Column<int>(type: "int", nullable: false),
                    UM = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ricette", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ricette_Dolci_DolceId",
                        column: x => x.DolceId,
                        principalTable: "Dolci",
                        principalColumn: "DolceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ricette_Ingredienti_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredienti",
                        principalColumn: "IngredienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ricette_DolceId",
                table: "Ricette",
                column: "DolceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ricette_IngredienteId",
                table: "Ricette",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vetrina_DolceId",
                table: "Vetrina",
                column: "DolceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ricette");

            migrationBuilder.DropTable(
                name: "Vetrina");

            migrationBuilder.DropTable(
                name: "Ingredienti");

            migrationBuilder.DropTable(
                name: "Dolci");
        }
    }
}
