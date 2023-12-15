using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webProjeOdev2.Migrations
{
    /// <inheritdoc />
    public partial class poliklinikDüzeltme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HastaneKlinik_Poliklinikler_poliklinikId",
                table: "HastaneKlinik");

            migrationBuilder.DropForeignKey(
                name: "FK_HastanePoliklinik_Hastaneler_hastaneId",
                table: "HastanePoliklinik");

            migrationBuilder.DropForeignKey(
                name: "FK_HastanePoliklinik_Poliklinikler_poliklinikId",
                table: "HastanePoliklinik");

            migrationBuilder.DropIndex(
                name: "IX_HastaneKlinik_poliklinikId",
                table: "HastaneKlinik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HastanePoliklinik",
                table: "HastanePoliklinik");

            migrationBuilder.DropColumn(
                name: "poliklinikId",
                table: "HastaneKlinik");

            migrationBuilder.RenameTable(
                name: "HastanePoliklinik",
                newName: "HastanePoliklinikler");

            migrationBuilder.RenameIndex(
                name: "IX_HastanePoliklinik_poliklinikId",
                table: "HastanePoliklinikler",
                newName: "IX_HastanePoliklinikler_poliklinikId");

            migrationBuilder.AddColumn<int>(
                name: "PolikliniklerpoliklinikId",
                table: "HastaneKlinik",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HastanePoliklinikler",
                table: "HastanePoliklinikler",
                columns: new[] { "hastaneId", "poliklinikId" });

            migrationBuilder.CreateIndex(
                name: "IX_HastaneKlinik_PolikliniklerpoliklinikId",
                table: "HastaneKlinik",
                column: "PolikliniklerpoliklinikId");

            migrationBuilder.AddForeignKey(
                name: "FK_HastaneKlinik_Poliklinikler_PolikliniklerpoliklinikId",
                table: "HastaneKlinik",
                column: "PolikliniklerpoliklinikId",
                principalTable: "Poliklinikler",
                principalColumn: "poliklinikId");

            migrationBuilder.AddForeignKey(
                name: "FK_HastanePoliklinikler_Hastaneler_hastaneId",
                table: "HastanePoliklinikler",
                column: "hastaneId",
                principalTable: "Hastaneler",
                principalColumn: "hastaneId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HastanePoliklinikler_Poliklinikler_poliklinikId",
                table: "HastanePoliklinikler",
                column: "poliklinikId",
                principalTable: "Poliklinikler",
                principalColumn: "poliklinikId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HastaneKlinik_Poliklinikler_PolikliniklerpoliklinikId",
                table: "HastaneKlinik");

            migrationBuilder.DropForeignKey(
                name: "FK_HastanePoliklinikler_Hastaneler_hastaneId",
                table: "HastanePoliklinikler");

            migrationBuilder.DropForeignKey(
                name: "FK_HastanePoliklinikler_Poliklinikler_poliklinikId",
                table: "HastanePoliklinikler");

            migrationBuilder.DropIndex(
                name: "IX_HastaneKlinik_PolikliniklerpoliklinikId",
                table: "HastaneKlinik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HastanePoliklinikler",
                table: "HastanePoliklinikler");

            migrationBuilder.DropColumn(
                name: "PolikliniklerpoliklinikId",
                table: "HastaneKlinik");

            migrationBuilder.RenameTable(
                name: "HastanePoliklinikler",
                newName: "HastanePoliklinik");

            migrationBuilder.RenameIndex(
                name: "IX_HastanePoliklinikler_poliklinikId",
                table: "HastanePoliklinik",
                newName: "IX_HastanePoliklinik_poliklinikId");

            migrationBuilder.AddColumn<int>(
                name: "poliklinikId",
                table: "HastaneKlinik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HastanePoliklinik",
                table: "HastanePoliklinik",
                columns: new[] { "hastaneId", "poliklinikId" });

            migrationBuilder.CreateIndex(
                name: "IX_HastaneKlinik_poliklinikId",
                table: "HastaneKlinik",
                column: "poliklinikId");

            migrationBuilder.AddForeignKey(
                name: "FK_HastaneKlinik_Poliklinikler_poliklinikId",
                table: "HastaneKlinik",
                column: "poliklinikId",
                principalTable: "Poliklinikler",
                principalColumn: "poliklinikId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HastanePoliklinik_Hastaneler_hastaneId",
                table: "HastanePoliklinik",
                column: "hastaneId",
                principalTable: "Hastaneler",
                principalColumn: "hastaneId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HastanePoliklinik_Poliklinikler_poliklinikId",
                table: "HastanePoliklinik",
                column: "poliklinikId",
                principalTable: "Poliklinikler",
                principalColumn: "poliklinikId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
