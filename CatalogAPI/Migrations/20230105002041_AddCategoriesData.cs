using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogAPI.Migrations
{
    public partial class AddCategoriesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(Name, UrlImage) VALUES ('Bebidas', 'bebidas.jpg')");
            migrationBuilder.Sql("INSERT INTO Categories(Name, UrlImage) VALUES ('Lanches', 'lanches.jpg')");
            migrationBuilder.Sql("INSERT INTO Categories(Name, UrlImage) VALUES ('Sobremesas', 'sobremesas.jpg')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
