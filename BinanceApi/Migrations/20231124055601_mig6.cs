using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinanceApi.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Klines",
                table: "Klines");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Klines");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenTime",
                table: "Klines",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Klines",
                table: "Klines",
                column: "OpenTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Klines",
                table: "Klines");

            migrationBuilder.AlterColumn<int>(
                name: "OpenTime",
                table: "Klines",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Klines",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Klines",
                table: "Klines",
                column: "Id");
        }
    }
}
