using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinanceApi.Migrations
{
    /// <inheritdoc />
    public partial class mig14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Klines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Klines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
