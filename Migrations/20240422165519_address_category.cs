using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeComfort.Migrations
{
    /// <inheritdoc />
    public partial class address_category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entrance = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appliances = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plumbing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Electrical = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Heating_and_Cooling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Handyman_Services = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Carpentry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Landscaping = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cleaning = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AddressId",
                table: "Applications",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CategoryId",
                table: "Applications",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Address_AddressId",
                table: "Applications",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Category_CategoryId",
                table: "Applications",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Address_AddressId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Category_CategoryId",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Applications_AddressId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_CategoryId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Applications");
        }
    }
}
