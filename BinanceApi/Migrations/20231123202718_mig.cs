using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinanceApi.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klines",
                columns: table => new
                {
                    OpenTime = table.Column<long>(type: "bigint", nullable: false),
                    Open = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Close = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klines");
        }
    }
}
