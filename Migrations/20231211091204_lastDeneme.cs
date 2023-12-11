using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webProjeOdev.Migrations
{
    /// <inheritdoc />
    public partial class lastDeneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HastaneKlinikler",
                columns: table => new
                {
                    hastaneId = table.Column<int>(type: "int", nullable: false),
                    klinikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HastaneKlinikler", x => new { x.hastaneId, x.klinikId });
                    table.ForeignKey(
                        name: "FK_HastaneKlinikler_Hastaneler_hastaneId",
                        column: x => x.hastaneId,
                        principalTable: "Hastaneler",
                        principalColumn: "hastaneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HastaneKlinikler_Klinikler_klinikId",
                        column: x => x.klinikId,
                        principalTable: "Klinikler",
                        principalColumn: "klinikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HastanePoliklinikler",
                columns: table => new
                {
                    hastaneId = table.Column<int>(type: "int", nullable: false),
                    poliklinikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HastanePoliklinikler", x => new { x.hastaneId, x.poliklinikId });
                    table.ForeignKey(
                        name: "FK_HastanePoliklinikler_Hastaneler_hastaneId",
                        column: x => x.hastaneId,
                        principalTable: "Hastaneler",
                        principalColumn: "hastaneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HastanePoliklinikler_Poliklinikler_poliklinikId",
                        column: x => x.poliklinikId,
                        principalTable: "Poliklinikler",
                        principalColumn: "poliklinikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HastaneKlinikler_klinikId",
                table: "HastaneKlinikler",
                column: "klinikId");

            migrationBuilder.CreateIndex(
                name: "IX_HastanePoliklinikler_poliklinikId",
                table: "HastanePoliklinikler",
                column: "poliklinikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HastaneKlinikler");

            migrationBuilder.DropTable(
                name: "HastanePoliklinikler");
        }
    }
}
