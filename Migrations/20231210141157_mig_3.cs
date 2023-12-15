using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webProjeOdev2.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HastaneAnaBilim_AnaBilimDallari_anaBilimDaliId",
                table: "HastaneAnaBilim");

            migrationBuilder.DropForeignKey(
                name: "FK_HastaneAnaBilim_Hastaneler_hastaneId",
                table: "HastaneAnaBilim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HastaneAnaBilim",
                table: "HastaneAnaBilim");

            migrationBuilder.RenameTable(
                name: "HastaneAnaBilim",
                newName: "HastanedekiAnaBilimler");

            migrationBuilder.RenameIndex(
                name: "IX_HastaneAnaBilim_hastaneId",
                table: "HastanedekiAnaBilimler",
                newName: "IX_HastanedekiAnaBilimler_hastaneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HastanedekiAnaBilimler",
                table: "HastanedekiAnaBilimler",
                columns: new[] { "anaBilimDaliId", "hastaneId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HastanedekiAnaBilimler_AnaBilimDallari_anaBilimDaliId",
                table: "HastanedekiAnaBilimler",
                column: "anaBilimDaliId",
                principalTable: "AnaBilimDallari",
                principalColumn: "anaBilimDaliId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HastanedekiAnaBilimler_Hastaneler_hastaneId",
                table: "HastanedekiAnaBilimler",
                column: "hastaneId",
                principalTable: "Hastaneler",
                principalColumn: "hastaneId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HastanedekiAnaBilimler_AnaBilimDallari_anaBilimDaliId",
                table: "HastanedekiAnaBilimler");

            migrationBuilder.DropForeignKey(
                name: "FK_HastanedekiAnaBilimler_Hastaneler_hastaneId",
                table: "HastanedekiAnaBilimler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HastanedekiAnaBilimler",
                table: "HastanedekiAnaBilimler");

            migrationBuilder.RenameTable(
                name: "HastanedekiAnaBilimler",
                newName: "HastaneAnaBilim");

            migrationBuilder.RenameIndex(
                name: "IX_HastanedekiAnaBilimler_hastaneId",
                table: "HastaneAnaBilim",
                newName: "IX_HastaneAnaBilim_hastaneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HastaneAnaBilim",
                table: "HastaneAnaBilim",
                columns: new[] { "anaBilimDaliId", "hastaneId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HastaneAnaBilim_AnaBilimDallari_anaBilimDaliId",
                table: "HastaneAnaBilim",
                column: "anaBilimDaliId",
                principalTable: "AnaBilimDallari",
                principalColumn: "anaBilimDaliId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HastaneAnaBilim_Hastaneler_hastaneId",
                table: "HastaneAnaBilim",
                column: "hastaneId",
                principalTable: "Hastaneler",
                principalColumn: "hastaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
