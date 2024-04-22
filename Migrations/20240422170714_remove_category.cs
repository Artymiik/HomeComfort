using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeComfort.Migrations
{
    /// <inheritdoc />
    public partial class remove_category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Address_AddressId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Category_CategoryId",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Applications_CategoryId",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Applications",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Addresses_AddressId",
                table: "Applications",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Addresses_AddressId",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Applications",
                newName: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appliances = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Carpentry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cleaning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Electrical = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Handyman_Services = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Heating_and_Cooling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Landscaping = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plumbing = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

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
    }
}
