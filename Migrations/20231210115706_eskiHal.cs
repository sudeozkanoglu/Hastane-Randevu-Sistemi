using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webProjeOdev2.Migrations
{
    /// <inheritdoc />
    public partial class eskiHal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "calismaGunleri",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "calismaSaat",
                table: "Doktorlar");


        }
    }
}
