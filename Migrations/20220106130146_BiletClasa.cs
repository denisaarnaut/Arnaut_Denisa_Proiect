using Microsoft.EntityFrameworkCore.Migrations;

namespace Flyer1.Migrations
{
    public partial class BiletClasa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Bilet",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "CompanieID",
                table: "Bilet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clasa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip_Clasa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Companie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_Companie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BiletClasa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiletID = table.Column<int>(type: "int", nullable: false),
                    ClasaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiletClasa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BiletClasa_Bilet_BiletID",
                        column: x => x.BiletID,
                        principalTable: "Bilet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiletClasa_Clasa_ClasaID",
                        column: x => x.ClasaID,
                        principalTable: "Clasa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_CompanieID",
                table: "Bilet",
                column: "CompanieID");

            migrationBuilder.CreateIndex(
                name: "IX_BiletClasa_BiletID",
                table: "BiletClasa",
                column: "BiletID");

            migrationBuilder.CreateIndex(
                name: "IX_BiletClasa_ClasaID",
                table: "BiletClasa",
                column: "ClasaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bilet_Companie_CompanieID",
                table: "Bilet",
                column: "CompanieID",
                principalTable: "Companie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bilet_Companie_CompanieID",
                table: "Bilet");

            migrationBuilder.DropTable(
                name: "BiletClasa");

            migrationBuilder.DropTable(
                name: "Companie");

            migrationBuilder.DropTable(
                name: "Clasa");

            migrationBuilder.DropIndex(
                name: "IX_Bilet_CompanieID",
                table: "Bilet");

            migrationBuilder.DropColumn(
                name: "CompanieID",
                table: "Bilet");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Bilet",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }
    }
}
