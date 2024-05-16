using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IUNRWARepository.Migrations
{
    /// <inheritdoc />
    public partial class measurementunit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "TheMeasurements",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "TheMeasurements");
        }
    }
}
