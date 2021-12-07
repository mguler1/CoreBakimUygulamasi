using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreBakimUygulamasi.Data.Migrations
{
    public partial class create_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BakimHizmetiGenel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakineSayacSaat = table.Column<double>(type: "float", nullable: false),
                    ToplamFiyat = table.Column<double>(type: "float", nullable: false),
                    Detaylar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MakineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakimHizmetiGenel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BakimHizmetiGenel_Makine_MakineId",
                        column: x => x.MakineId,
                        principalTable: "Makine",
                        principalColumn: "MakineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BakimHizmetKart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakineId = table.Column<int>(type: "int", nullable: false),
                    BakımTipiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakimHizmetKart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BakimHizmetKart_BakimTipi_BakımTipiId",
                        column: x => x.BakımTipiId,
                        principalTable: "BakimTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BakimHizmetKart_Makine_MakineId",
                        column: x => x.MakineId,
                        principalTable: "Makine",
                        principalColumn: "MakineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BakimHizmetDetay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BakimHizmetiGenelId = table.Column<int>(type: "int", nullable: false),
                    BakimTipiId = table.Column<int>(type: "int", nullable: false),
                    BakimFiyati = table.Column<double>(type: "float", nullable: false),
                    BakimAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakimHizmetDetay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BakimHizmetDetay_BakimHizmetiGenel_BakimHizmetiGenelId",
                        column: x => x.BakimHizmetiGenelId,
                        principalTable: "BakimHizmetiGenel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BakimHizmetDetay_BakimTipi_BakimTipiId",
                        column: x => x.BakimTipiId,
                        principalTable: "BakimTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BakimHizmetDetay_BakimHizmetiGenelId",
                table: "BakimHizmetDetay",
                column: "BakimHizmetiGenelId");

            migrationBuilder.CreateIndex(
                name: "IX_BakimHizmetDetay_BakimTipiId",
                table: "BakimHizmetDetay",
                column: "BakimTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_BakimHizmetiGenel_MakineId",
                table: "BakimHizmetiGenel",
                column: "MakineId");

            migrationBuilder.CreateIndex(
                name: "IX_BakimHizmetKart_BakımTipiId",
                table: "BakimHizmetKart",
                column: "BakımTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_BakimHizmetKart_MakineId",
                table: "BakimHizmetKart",
                column: "MakineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BakimHizmetDetay");

            migrationBuilder.DropTable(
                name: "BakimHizmetKart");

            migrationBuilder.DropTable(
                name: "BakimHizmetiGenel");
        }
    }
}
