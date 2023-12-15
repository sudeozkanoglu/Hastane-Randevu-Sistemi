using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webProjeOdev2.Migrations
{
    /// <inheritdoc />
    public partial class poliklinikDuzeltme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "doktorId",
                table: "Poliklinikler");

            migrationBuilder.DropColumn(
                name: "poliklinikId",
                table: "Doktorlar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "doktorId",
                table: "Poliklinikler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "poliklinikId",
                table: "Doktorlar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
