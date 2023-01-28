﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorDeck.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cards");
        }
    }
}
