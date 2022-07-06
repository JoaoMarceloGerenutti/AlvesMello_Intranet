using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlvesMello_IntraNet.Migrations
{
    public partial class PopulateCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(Color, Name, Description) " +
                "VALUES('FF6232', 'Fiscal', 'Departamento responsável pela parte Fiscal dos clientes.')");

            migrationBuilder.Sql("INSERT INTO Categories(Color, Name, Description) " +
                "VALUES('A586F5', 'Contábil', 'Departamento responsável pela parte Contábil dos clientes.')");

            migrationBuilder.Sql("INSERT INTO Categories(Color, Name, Description) " +
                "VALUES('4EB4F3', 'Departamento Pessoal', 'Departamento responsável pela parte referente aos funcionários dos clientes.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
