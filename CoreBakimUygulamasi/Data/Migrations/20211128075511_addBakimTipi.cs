using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreBakimUygulamasi.Data.Migrations
{
    public partial class addBakimTipi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BakimTipi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BakimAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BakimFiyati = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakimTipi", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BakimTipi");
        }
    }
}
