using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Canchas4.Migrations
{
    public partial class creamosMensajeEnCanchaFut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mensajeError",
                table: "CanchaFut",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mensajeError",
                table: "CanchaFut");
        }
    }
}
