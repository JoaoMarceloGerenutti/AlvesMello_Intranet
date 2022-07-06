using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlvesMello_IntraNet.Migrations
{
    public partial class FavoriteUserSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteUserSites",
                columns: table => new
                {
                    FavoriteUserSiteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<int>(type: "int", nullable: true),
                    FavoriteUserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteUserSites", x => x.FavoriteUserSiteId);
                    table.ForeignKey(
                        name: "FK_FavoriteUserSites_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "SiteId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteUserSites_SiteId",
                table: "FavoriteUserSites",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteUserSites");
        }
    }
}
