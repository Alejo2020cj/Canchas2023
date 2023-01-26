using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Canchas4.Migrations
{
    public partial class creamosCanchafutCanchavolei : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sede",
                columns: table => new
                {
                    SedeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sede", x => x.SedeId);
                });

            migrationBuilder.CreateTable(
                name: "CanchaFut",
                columns: table => new
                {
                    CanchaFutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SedeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanchaFut", x => x.CanchaFutId);
                    table.ForeignKey(
                        name: "FK_CanchaFut_Sede_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sede",
                        principalColumn: "SedeId");
                });

            migrationBuilder.CreateTable(
                name: "CanchVolei",
                columns: table => new
                {
                    CanchaVoleiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SedeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanchVolei", x => x.CanchaVoleiId);
                    table.ForeignKey(
                        name: "FK_CanchVolei_Sede_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sede",
                        principalColumn: "SedeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CanchaFut_SedeId",
                table: "CanchaFut",
                column: "SedeId");

            migrationBuilder.CreateIndex(
                name: "IX_CanchVolei_SedeId",
                table: "CanchVolei",
                column: "SedeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CanchaFut");

            migrationBuilder.DropTable(
                name: "CanchVolei");

            migrationBuilder.DropTable(
                name: "Sede");
        }
    }
}
