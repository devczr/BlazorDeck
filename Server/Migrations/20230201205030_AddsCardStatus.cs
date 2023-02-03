using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorDeck.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddsCardStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Cards",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Guid", "Status" },
                values: new object[] { new Guid("4c855461-0fd9-4d8b-8491-f80d57ce1185"), "" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Guid", "Status" },
                values: new object[] { new Guid("743dc82e-ecd4-4a52-a0ab-ce7de91bd1f0"), "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Cards");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
