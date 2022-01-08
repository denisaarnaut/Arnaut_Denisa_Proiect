using Microsoft.EntityFrameworkCore.Migrations;

namespace Flyer1.Migrations
{
    public partial class BiletPachet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiletClasa");

            migrationBuilder.RenameColumn(
                name: "Tip_Clasa",
                table: "Clasa",
                newName: "Nume_Pachet");

            migrationBuilder.CreateTable(
                name: "BiletPachet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiletID = table.Column<int>(type: "int", nullable: false),
                    PachetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiletPachet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BiletPachet_Bilet_BiletID",
                        column: x => x.BiletID,
                        principalTable: "Bilet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiletPachet_Clasa_PachetID",
                        column: x => x.PachetID,
                        principalTable: "Clasa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiletPachet_BiletID",
                table: "BiletPachet",
                column: "BiletID");

            migrationBuilder.CreateIndex(
                name: "IX_BiletPachet_PachetID",
                table: "BiletPachet",
                column: "PachetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiletPachet");

            migrationBuilder.RenameColumn(
                name: "Nume_Pachet",
                table: "Clasa",
                newName: "Tip_Clasa");

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
                name: "IX_BiletClasa_BiletID",
                table: "BiletClasa",
                column: "BiletID");

            migrationBuilder.CreateIndex(
                name: "IX_BiletClasa_ClasaID",
                table: "BiletClasa",
                column: "ClasaID");
        }
    }
}
