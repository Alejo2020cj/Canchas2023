using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Canchas4.Migrations
{
    /// <inheritdoc />
    public partial class AgregaCanchaVoleiEnModelsCorreccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservasVolei",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CanchaVoleiId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasVolei", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_ReservasVolei_CanchVolei_CanchaVoleiId",
                        column: x => x.CanchaVoleiId,
                        principalTable: "CanchVolei",
                        principalColumn: "CanchaVoleiId");
                    table.ForeignKey(
                        name: "FK_ReservasVolei_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservasVolei_CanchaVoleiId",
                table: "ReservasVolei",
                column: "CanchaVoleiId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasVolei_UsuarioId",
                table: "ReservasVolei",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservasVolei");
        }
    }
}
