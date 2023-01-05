using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogAPI.Migrations
{
    public partial class AddProductsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO Products(Name, Description, Price, UrlImage, Stock, RegistrationDate, CategoryId) " +
                "VALUES('Coca-Cola Diet', 'Refrigerante de cola 350ml', 5.45, 'cocacola.jpg', 50, now(), 1)");
            
            migrationBuilder.Sql(
                "INSERT INTO Products(Name, Description, Price, UrlImage, Stock, RegistrationDate, CategoryId) " +
                "VALUES('Lanche de atum', 'Lanche de atum com maionese', 8.50, 'atum.jpg', 10, now(), 2)");
            
            migrationBuilder.Sql(
                "INSERT INTO Products(Name, Description, Price, UrlImage, Stock, RegistrationDate, CategoryId) " +
                "VALUES('Pudim 100g', 'Pudim de leite condensado 100g', 6.75, 'pudim.jpg', 20, now(), 3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
