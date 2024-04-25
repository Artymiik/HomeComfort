using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeComfort.Migrations
{
    /// <inheritdoc />
    public partial class DateTime_Application : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Applications",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Applications");
        }
    }
}
