using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlvesMello_IntraNet.Migrations
{
    public partial class PopulateSites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Sites(Name, Description, ImageUrl, SiteUrl, IsFavorite, IsActive, CategoryId) " +
                "VALUES('ECAC - Receita Federal', 'Centro de Atendimento Virtual da Receita Federal.', 'C:\\Users\\MATHEUS\\Desktop\\AlvesMello_IntraNet\\AlvesMello_IntraNet\\wwwroot\\images\\Ecac.png', 'https://cav.receita.fazenda.gov.br/autenticacao/Login/Logout', 1, 1, 4)");

            migrationBuilder.Sql("INSERT INTO Sites(Name, Description, ImageUrl, SiteUrl, IsFavorite, IsActive, CategoryId) " +
                "VALUES('Atendimento WhatsApp - SMBOT', 'Sistema de Atendimento Multicanal por WhatsApp', 'C:\\Users\\MATHEUS\\Desktop\\AlvesMello_IntraNet\\AlvesMello_IntraNet\\wwwroot\\images\\WhatsappWeb.png', 'https://www.smsolucoesdigital.com.br/#/bots/bot', 0, 1, 5)");

            migrationBuilder.Sql("INSERT INTO Sites(Name, Description, ImageUrl, SiteUrl, IsFavorite, IsActive, CategoryId) " +
                "VALUES('Contmatic - Sistemas Contábeis', 'A Contmatic Phoenix desenvolve, há mais de 30 anos (e mesmo assim, consegue ser horrivel - J.M.), softwares de contabilidade, administração e gestão (ERP).', 'C:\\Users\\MATHEUS\\Desktop\\AlvesMello_IntraNet\\AlvesMello_IntraNet\\wwwroot\\images\\Contmatic.png', 'https://cliente.contmatic.com.br/login', 1, 1, 6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Sites");
        }
    }
}
