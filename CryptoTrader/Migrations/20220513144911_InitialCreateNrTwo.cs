using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoTrader.Migrations
{
    public partial class InitialCreateNrTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoCurrencies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Logo_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoCurrencies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CryptoCurrencies",
                columns: new[] { "Id", "Logo_url", "Name", "Price", "Quantity" },
                values: new object[] { "NET", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/.NET_Logo.svg/1024px-.NET_Logo.svg.png", ".NET Coin", 100000.0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoCurrencies");
        }
    }
}
