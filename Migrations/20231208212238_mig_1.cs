using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webProjeOdev2.Migrations
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
                    medeniHal = table.Column<int>(type: "int", nullable: false),
                    telefonNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iller = table.Column<int>(type: "int", nullable: false),
                    hastaSifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "user")
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
                    telefonNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iller = table.Column<int>(type: "int", nullable: false)
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
                name: "HastaneAnaBilim",
                columns: table => new
                {
                    hastaneId = table.Column<int>(type: "int", nullable: false),
                    anaBilimDaliId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HastaneAnaBilim", x => new { x.anaBilimDaliId, x.hastaneId });
                    table.ForeignKey(
                        name: "FK_HastaneAnaBilim_AnaBilimDallari_anaBilimDaliId",
                        column: x => x.anaBilimDaliId,
                        principalTable: "AnaBilimDallari",
                        principalColumn: "anaBilimDaliId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HastaneAnaBilim_Hastaneler_hastaneId",
                        column: x => x.hastaneId,
                        principalTable: "Hastaneler",
                        principalColumn: "hastaneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HastaneHasta",
                columns: table => new
                {
                    hastaneId = table.Column<int>(type: "int", nullable: false),
                    hastaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HastaneHasta", x => new { x.hastaId, x.hastaneId });
                    table.ForeignKey(
                        name: "FK_HastaneHasta_Hastalar_hastaId",
                        column: x => x.hastaId,
                        principalTable: "Hastalar",
                        principalColumn: "hastaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HastaneHasta_Hastaneler_hastaneId",
                        column: x => x.hastaneId,
                        principalTable: "Hastaneler",
                        principalColumn: "hastaneId",
                        onDelete: ReferentialAction.Cascade);
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
                    telefonNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iller = table.Column<int>(type: "int", nullable: false),
                    calismaGunleri = table.Column<int>(type: "int", nullable: false),
                    calismaSaat = table.Column<TimeSpan>(type: "time", nullable: false),
                    anaBilimDaliId = table.Column<int>(type: "int", nullable: false),
                    klinikId = table.Column<int>(type: "int", nullable: false),
                    hastaneId = table.Column<int>(type: "int", nullable: false),
                    poliklinikId = table.Column<int>(type: "int", nullable: false)
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
                name: "Poliklinikler",
                columns: table => new
                {
                    poliklinikId = table.Column<int>(type: "int", nullable: false),
                    poliklinikAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    klinikId = table.Column<int>(type: "int", nullable: false),
                    doktorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliklinikler", x => x.poliklinikId);
                    table.ForeignKey(
                        name: "FK_Poliklinikler_Doktorlar_poliklinikId",
                        column: x => x.poliklinikId,
                        principalTable: "Doktorlar",
                        principalColumn: "doktorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poliklinikler_Klinikler_klinikId",
                        column: x => x.klinikId,
                        principalTable: "Klinikler",
                        principalColumn: "klinikId");
                });

            migrationBuilder.CreateTable(
                name: "HastaneKlinik",
                columns: table => new
                {
                    hastaneId = table.Column<int>(type: "int", nullable: false),
                    klinikId = table.Column<int>(type: "int", nullable: false),
                    poliklinikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HastaneKlinik", x => new { x.hastaneId, x.klinikId });
                    table.ForeignKey(
                        name: "FK_HastaneKlinik_Hastaneler_hastaneId",
                        column: x => x.hastaneId,
                        principalTable: "Hastaneler",
                        principalColumn: "hastaneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HastaneKlinik_Klinikler_klinikId",
                        column: x => x.klinikId,
                        principalTable: "Klinikler",
                        principalColumn: "klinikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HastaneKlinik_Poliklinikler_poliklinikId",
                        column: x => x.poliklinikId,
                        principalTable: "Poliklinikler",
                        principalColumn: "poliklinikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HastanePoliklinik",
                columns: table => new
                {
                    hastaneId = table.Column<int>(type: "int", nullable: false),
                    poliklinikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HastanePoliklinik", x => new { x.hastaneId, x.poliklinikId });
                    table.ForeignKey(
                        name: "FK_HastanePoliklinik_Hastaneler_hastaneId",
                        column: x => x.hastaneId,
                        principalTable: "Hastaneler",
                        principalColumn: "hastaneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HastanePoliklinik_Poliklinikler_poliklinikId",
                        column: x => x.poliklinikId,
                        principalTable: "Poliklinikler",
                        principalColumn: "poliklinikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    randevuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    randevuTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    randevuSaat = table.Column<TimeSpan>(type: "time", nullable: false),
                    hastaneId = table.Column<int>(type: "int", nullable: false),
                    anaBilimDaliId = table.Column<int>(type: "int", nullable: false),
                    klinikId = table.Column<int>(type: "int", nullable: false),
                    poliklinikId = table.Column<int>(type: "int", nullable: false),
                    doktorId = table.Column<int>(type: "int", nullable: false),
                    hastaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.randevuId);
                    table.ForeignKey(
                        name: "FK_Randevular_AnaBilimDallari_anaBilimDaliId",
                        column: x => x.anaBilimDaliId,
                        principalTable: "AnaBilimDallari",
                        principalColumn: "anaBilimDaliId");
                    table.ForeignKey(
                        name: "FK_Randevular_Doktorlar_doktorId",
                        column: x => x.doktorId,
                        principalTable: "Doktorlar",
                        principalColumn: "doktorId");
                    table.ForeignKey(
                        name: "FK_Randevular_Hastalar_hastaId",
                        column: x => x.hastaId,
                        principalTable: "Hastalar",
                        principalColumn: "hastaId");
                    table.ForeignKey(
                        name: "FK_Randevular_Hastaneler_hastaneId",
                        column: x => x.hastaneId,
                        principalTable: "Hastaneler",
                        principalColumn: "hastaneId");
                    table.ForeignKey(
                        name: "FK_Randevular_Klinikler_klinikId",
                        column: x => x.klinikId,
                        principalTable: "Klinikler",
                        principalColumn: "klinikId");
                    table.ForeignKey(
                        name: "FK_Randevular_Poliklinikler_poliklinikId",
                        column: x => x.poliklinikId,
                        principalTable: "Poliklinikler",
                        principalColumn: "poliklinikId");
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
                name: "IX_HastaneAnaBilim_hastaneId",
                table: "HastaneAnaBilim",
                column: "hastaneId");

            migrationBuilder.CreateIndex(
                name: "IX_HastaneHasta_hastaneId",
                table: "HastaneHasta",
                column: "hastaneId");

            migrationBuilder.CreateIndex(
                name: "IX_HastaneKlinik_klinikId",
                table: "HastaneKlinik",
                column: "klinikId");

            migrationBuilder.CreateIndex(
                name: "IX_HastaneKlinik_poliklinikId",
                table: "HastaneKlinik",
                column: "poliklinikId");

            migrationBuilder.CreateIndex(
                name: "IX_HastanePoliklinik_poliklinikId",
                table: "HastanePoliklinik",
                column: "poliklinikId");

            migrationBuilder.CreateIndex(
                name: "IX_Klinikler_anaBilimDaliId",
                table: "Klinikler",
                column: "anaBilimDaliId");

            migrationBuilder.CreateIndex(
                name: "IX_Poliklinikler_klinikId",
                table: "Poliklinikler",
                column: "klinikId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_anaBilimDaliId",
                table: "Randevular",
                column: "anaBilimDaliId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_doktorId",
                table: "Randevular",
                column: "doktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_hastaId",
                table: "Randevular",
                column: "hastaId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_hastaneId",
                table: "Randevular",
                column: "hastaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_klinikId",
                table: "Randevular",
                column: "klinikId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_poliklinikId",
                table: "Randevular",
                column: "poliklinikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HastaneAnaBilim");

            migrationBuilder.DropTable(
                name: "HastaneHasta");

            migrationBuilder.DropTable(
                name: "HastaneKlinik");

            migrationBuilder.DropTable(
                name: "HastanePoliklinik");

            migrationBuilder.DropTable(
                name: "Randevular");

            migrationBuilder.DropTable(
                name: "Hastalar");

            migrationBuilder.DropTable(
                name: "Poliklinikler");

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
