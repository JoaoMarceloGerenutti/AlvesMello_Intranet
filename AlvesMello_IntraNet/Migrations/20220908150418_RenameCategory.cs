using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlvesMello_IntraNet.Migrations
{
    public partial class RenameCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Categories_CategoryId",
                table: "Sites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Departments");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Sites",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Sites_CategoryId",
                table: "Sites",
                newName: "IX_Sites_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Departments",
                newName: "DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Departments_DepartmentId",
                table: "Sites",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Departments_DepartmentId",
                table: "Sites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Sites",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Sites_DepartmentId",
                table: "Sites",
                newName: "IX_Sites_CategoryId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Categories_CategoryId",
                table: "Sites",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
