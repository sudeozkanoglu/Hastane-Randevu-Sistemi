using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webProjeOdev.Migrations
{
    /// <inheritdoc />
    public partial class upDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IletisimBilgileri_Doktorlar_doktorId",
                table: "IletisimBilgileri");

            migrationBuilder.DropForeignKey(
                name: "FK_IletisimBilgileri_Hastalar_hastaId",
                table: "IletisimBilgileri");

            migrationBuilder.DropForeignKey(
                name: "FK_IletisimBilgileri_Hastaneler_hastaneId",
                table: "IletisimBilgileri");

            migrationBuilder.DropIndex(
                name: "IX_IletisimBilgileri_doktorId",
                table: "IletisimBilgileri");

            migrationBuilder.DropIndex(
                name: "IX_IletisimBilgileri_hastaId",
                table: "IletisimBilgileri");

            migrationBuilder.DropIndex(
                name: "IX_IletisimBilgileri_hastaneId",
                table: "IletisimBilgileri");

            migrationBuilder.DropColumn(
                name: "doktorId",
                table: "IletisimBilgileri");

            migrationBuilder.DropColumn(
                name: "hastaId",
                table: "IletisimBilgileri");

            migrationBuilder.DropColumn(
                name: "hastaneId",
                table: "IletisimBilgileri");

            migrationBuilder.AddColumn<int>(
                name: "iletisimId",
                table: "Hastaneler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "iletisimId",
                table: "Hastalar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "iletisimId",
                table: "Doktorlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hastaneler_iletisimId",
                table: "Hastaneler",
                column: "iletisimId");

            migrationBuilder.CreateIndex(
                name: "IX_Hastalar_iletisimId",
                table: "Hastalar",
                column: "iletisimId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_iletisimId",
                table: "Doktorlar",
                column: "iletisimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktorlar_IletisimBilgileri_iletisimId",
                table: "Doktorlar",
                column: "iletisimId",
                principalTable: "IletisimBilgileri",
                principalColumn: "iletisimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hastalar_IletisimBilgileri_iletisimId",
                table: "Hastalar",
                column: "iletisimId",
                principalTable: "IletisimBilgileri",
                principalColumn: "iletisimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hastaneler_IletisimBilgileri_iletisimId",
                table: "Hastaneler",
                column: "iletisimId",
                principalTable: "IletisimBilgileri",
                principalColumn: "iletisimId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_IletisimBilgileri_iletisimId",
                table: "Doktorlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Hastalar_IletisimBilgileri_iletisimId",
                table: "Hastalar");

            migrationBuilder.DropForeignKey(
                name: "FK_Hastaneler_IletisimBilgileri_iletisimId",
                table: "Hastaneler");

            migrationBuilder.DropIndex(
                name: "IX_Hastaneler_iletisimId",
                table: "Hastaneler");

            migrationBuilder.DropIndex(
                name: "IX_Hastalar_iletisimId",
                table: "Hastalar");

            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_iletisimId",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "iletisimId",
                table: "Hastaneler");

            migrationBuilder.DropColumn(
                name: "iletisimId",
                table: "Hastalar");

            migrationBuilder.DropColumn(
                name: "iletisimId",
                table: "Doktorlar");

            migrationBuilder.AddColumn<int>(
                name: "doktorId",
                table: "IletisimBilgileri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "hastaId",
                table: "IletisimBilgileri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "hastaneId",
                table: "IletisimBilgileri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IletisimBilgileri_doktorId",
                table: "IletisimBilgileri",
                column: "doktorId");

            migrationBuilder.CreateIndex(
                name: "IX_IletisimBilgileri_hastaId",
                table: "IletisimBilgileri",
                column: "hastaId");

            migrationBuilder.CreateIndex(
                name: "IX_IletisimBilgileri_hastaneId",
                table: "IletisimBilgileri",
                column: "hastaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_IletisimBilgileri_Doktorlar_doktorId",
                table: "IletisimBilgileri",
                column: "doktorId",
                principalTable: "Doktorlar",
                principalColumn: "doktorId");

            migrationBuilder.AddForeignKey(
                name: "FK_IletisimBilgileri_Hastalar_hastaId",
                table: "IletisimBilgileri",
                column: "hastaId",
                principalTable: "Hastalar",
                principalColumn: "hastaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IletisimBilgileri_Hastaneler_hastaneId",
                table: "IletisimBilgileri",
                column: "hastaneId",
                principalTable: "Hastaneler",
                principalColumn: "hastaneId");
        }
    }
}
