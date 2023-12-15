using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webProjeOdev2.Migrations
{
    /// <inheritdoc />
    public partial class tekrarYeniDeneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "calismaGunleri",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "calismaSaat",
                table: "Doktorlar");

            migrationBuilder.CreateTable(
                name: "DoktorCalismaGunleri",
                columns: table => new
                {
                    doktorCalismaGunleriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    calismaGunleri = table.Column<int>(type: "int", nullable: false),
                    calismaSaat = table.Column<TimeSpan>(type: "time", nullable: false),
                    doktorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoktorCalismaGunleri", x => x.doktorCalismaGunleriId);
                    table.ForeignKey(
                        name: "FK_DoktorCalismaGunleri_Doktorlar_doktorId",
                        column: x => x.doktorId,
                        principalTable: "Doktorlar",
                        principalColumn: "doktorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoktorCalismaGunleri_doktorId",
                table: "DoktorCalismaGunleri",
                column: "doktorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoktorCalismaGunleri");

            migrationBuilder.AddColumn<int>(
                name: "calismaGunleri",
                table: "Doktorlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "calismaSaat",
                table: "Doktorlar",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
