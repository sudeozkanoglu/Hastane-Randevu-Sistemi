using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webProjeOdev.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnaBilimDallari",
                columns: table => new
                {
                    anaBilimDaliId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    anaBilimDaliAdi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaBilimDallari", x => x.anaBilimDaliId);
                });

            migrationBuilder.CreateTable(
                name: "Hastalar",
                columns: table => new
                {
                    hastaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hastaTC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    hastaAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    hastaSoyadi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cinsiyet = table.Column<int>(type: "int", nullable: false),
                    medeniHal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastalar", x => x.hastaId);
                });

            migrationBuilder.CreateTable(
                name: "Hastaneler",
                columns: table => new
                {
                    hastaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hastaneAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    anaBilimDaliAdi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    klinikAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    poliklinikAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastaneler", x => x.hastaneId);
                });

            migrationBuilder.CreateTable(
                name: "Klinikler",
                columns: table => new
                {
                    klinikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    klinikAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    anaBilimDaliId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klinikler", x => x.klinikId);
                    table.ForeignKey(
                        name: "FK_Klinikler_AnaBilimDallari_anaBilimDaliId",
                        column: x => x.anaBilimDaliId,
                        principalTable: "AnaBilimDallari",
                        principalColumn: "anaBilimDaliId");
                });

            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    doktorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doktorAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    doktorSoyadi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cinsiyet = table.Column<int>(type: "int", nullable: false),
                    medeniHal = table.Column<int>(type: "int", nullable: false),
                    calismaGunleri = table.Column<int>(type: "int", nullable: false),
                    calismaSaat = table.Column<TimeSpan>(type: "time", nullable: false),
                    brans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    doktorKlinik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    doktorPoliklinik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anaBilimDaliId = table.Column<int>(type: "int", nullable: false),
                    klinikId = table.Column<int>(type: "int", nullable: false),
                    hastaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.doktorId);
                    table.ForeignKey(
                        name: "FK_Doktorlar_AnaBilimDallari_anaBilimDaliId",
                        column: x => x.anaBilimDaliId,
                        principalTable: "AnaBilimDallari",
                        principalColumn: "anaBilimDaliId");
                    table.ForeignKey(
                        name: "FK_Doktorlar_Hastaneler_hastaneId",
                        column: x => x.hastaneId,
                        principalTable: "Hastaneler",
                        principalColumn: "hastaneId");
                    table.ForeignKey(
                        name: "FK_Doktorlar_Klinikler_klinikId",
                        column: x => x.klinikId,
                        principalTable: "Klinikler",
                        principalColumn: "klinikId");
                });

            migrationBuilder.CreateTable(
                name: "IletisimBilgileri",
                columns: table => new
                {
                    iletisimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    telefonNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iller = table.Column<int>(type: "int", nullable: false),
                    hastaId = table.Column<int>(type: "int", nullable: false),
                    doktorId = table.Column<int>(type: "int", nullable: false),
                    hastaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IletisimBilgileri", x => x.iletisimId);
                    table.ForeignKey(
                        name: "FK_IletisimBilgileri_Doktorlar_doktorId",
                        column: x => x.doktorId,
                        principalTable: "Doktorlar",
                        principalColumn: "doktorId");
                    table.ForeignKey(
                        name: "FK_IletisimBilgileri_Hastalar_hastaId",
                        column: x => x.hastaId,
                        principalTable: "Hastalar",
                        principalColumn: "hastaId");
                    table.ForeignKey(
                        name: "FK_IletisimBilgileri_Hastaneler_hastaneId",
                        column: x => x.hastaneId,
                        principalTable: "Hastaneler",
                        principalColumn: "hastaneId");
                });

            migrationBuilder.CreateTable(
                name: "Poliklinikler",
                columns: table => new
                {
                    poliklinikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    poliklinikAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    klinikId = table.Column<int>(type: "int", nullable: false),
                    doktorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliklinikler", x => x.poliklinikId);
                    table.ForeignKey(
                        name: "FK_Poliklinikler_Doktorlar_doktorId",
                        column: x => x.doktorId,
                        principalTable: "Doktorlar",
                        principalColumn: "doktorId");
                    table.ForeignKey(
                        name: "FK_Poliklinikler_Klinikler_klinikId",
                        column: x => x.klinikId,
                        principalTable: "Klinikler",
                        principalColumn: "klinikId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_anaBilimDaliId",
                table: "Doktorlar",
                column: "anaBilimDaliId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_hastaneId",
                table: "Doktorlar",
                column: "hastaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_klinikId",
                table: "Doktorlar",
                column: "klinikId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Klinikler_anaBilimDaliId",
                table: "Klinikler",
                column: "anaBilimDaliId");

            migrationBuilder.CreateIndex(
                name: "IX_Poliklinikler_doktorId",
                table: "Poliklinikler",
                column: "doktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Poliklinikler_klinikId",
                table: "Poliklinikler",
                column: "klinikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IletisimBilgileri");

            migrationBuilder.DropTable(
                name: "Poliklinikler");

            migrationBuilder.DropTable(
                name: "Hastalar");

            migrationBuilder.DropTable(
                name: "Doktorlar");

            migrationBuilder.DropTable(
                name: "Hastaneler");

            migrationBuilder.DropTable(
                name: "Klinikler");

            migrationBuilder.DropTable(
                name: "AnaBilimDallari");
        }
    }
}
