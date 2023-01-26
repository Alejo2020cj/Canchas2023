using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Canchas4.Migrations
{
    public partial class creamosReservasUsuarioyRelacionescanchasusuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coreo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CanchaFutId = table.Column<int>(type: "int", nullable: true),
                    CanchaVoleiId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reservas_CanchaFut_CanchaFutId",
                        column: x => x.CanchaFutId,
                        principalTable: "CanchaFut",
                        principalColumn: "CanchaFutId");
                    table.ForeignKey(
                        name: "FK_Reservas_CanchVolei_CanchaVoleiId",
                        column: x => x.CanchaVoleiId,
                        principalTable: "CanchVolei",
                        principalColumn: "CanchaVoleiId");
                    table.ForeignKey(
                        name: "FK_Reservas_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_CanchaFutId",
                table: "Reservas",
                column: "CanchaFutId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_CanchaVoleiId",
                table: "Reservas",
                column: "CanchaVoleiId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UsuarioId",
                table: "Reservas",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
