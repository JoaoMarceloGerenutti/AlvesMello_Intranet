using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlvesMello_IntraNet.Migrations
{
    public partial class CategoryColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FavoriteUserId",
                table: "FavoriteUserSites",
                newName: "FavoriteSiteId");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Categories",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "FavoriteSiteId",
                table: "FavoriteUserSites",
                newName: "FavoriteUserId");
        }
    }
}
