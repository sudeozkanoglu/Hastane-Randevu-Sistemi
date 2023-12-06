using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webProjeOdev.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "anaBilimDaliAdi",
                table: "Hastaneler");

            migrationBuilder.DropColumn(
                name: "klinikAdi",
                table: "Hastaneler");

            migrationBuilder.DropColumn(
                name: "poliklinikAdi",
                table: "Hastaneler");

            migrationBuilder.DropColumn(
                name: "brans",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "doktorKlinik",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "doktorPoliklinik",
                table: "Doktorlar");

            migrationBuilder.AddColumn<string>(
                name: "hastaSifre",
                table: "Hastalar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.DropColumn(
                name: "hastaSifre",
                table: "Hastalar");

            migrationBuilder.AddColumn<string>(
                name: "anaBilimDaliAdi",
                table: "Hastaneler",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "klinikAdi",
                table: "Hastaneler",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "poliklinikAdi",
                table: "Hastaneler",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "brans",
                table: "Doktorlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "doktorKlinik",
                table: "Doktorlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "doktorPoliklinik",
                table: "Doktorlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
