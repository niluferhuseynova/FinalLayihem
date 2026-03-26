using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Feane.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageNameName",
                table: "DiscountedProducts");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "DiscountedProducts",
                newName: "ImageName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "DiscountedProducts",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "ImageNameName",
                table: "DiscountedProducts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
