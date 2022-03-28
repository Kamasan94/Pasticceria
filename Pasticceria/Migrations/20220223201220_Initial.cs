using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pasticceria.Migrations
{
    public partial class Initial : Migration
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
                name: "Ricette",
                columns: table => new
                {
                    RicettaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DolceId = table.Column<int>(type: "int", nullable: false),
                    IngredienteId = table.Column<int>(type: "int", nullable: false),
                    Quantita = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    UM = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ricette", x => x.RicettaId);
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
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dolci");

            migrationBuilder.DropTable(
                name: "Ingredienti");

            migrationBuilder.DropTable(
                name: "Ricette");

            migrationBuilder.DropTable(
                name: "Vetrina");
        }
    }
}
