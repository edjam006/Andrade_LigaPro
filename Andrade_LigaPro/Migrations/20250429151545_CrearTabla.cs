using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Andrade_LigaPro.Migrations
{
    /// <inheritdoc />
    public partial class CrearTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCamiseta = table.Column<int>(type: "int", nullable: false),
                    Goles = table.Column<int>(type: "int", nullable: false),
                    Asistencias = table.Column<int>(type: "int", nullable: false),
                    Sueldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jugador_equipo_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_EquipoId",
                table: "Jugador",
                column: "EquipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jugador");
        }
    }
}
