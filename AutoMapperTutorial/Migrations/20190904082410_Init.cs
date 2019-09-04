using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMapperTutorial.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nev = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emberek",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VezetekNev = table.Column<string>(nullable: true),
                    KeresztNev = table.Column<string>(nullable: true),
                    Kor = table.Column<decimal>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    HajSzin = table.Column<string>(nullable: true),
                    SzemSzin = table.Column<string>(nullable: true),
                    BaratId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emberek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emberek_Barat_BaratId",
                        column: x => x.BaratId,
                        principalTable: "Barat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Emberek",
                columns: new[] { "Id", "Discriminator", "KeresztNev", "Kor", "VezetekNev" },
                values: new object[] { new Guid("774d5bf8-d080-4a48-9e9a-bfa13a286781"), "Ember", "József", 30m, "Kovács" });

            migrationBuilder.InsertData(
                table: "Emberek",
                columns: new[] { "Id", "Discriminator", "KeresztNev", "Kor", "VezetekNev", "BaratId", "HajSzin", "SzemSzin" },
                values: new object[] { new Guid("85474139-82ac-4d23-957d-255f7e799687"), "Leszarmazott", "Ferenc", 6m, "Kovács", null, "Barna", "Kék" });

            migrationBuilder.CreateIndex(
                name: "IX_Emberek_BaratId",
                table: "Emberek",
                column: "BaratId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emberek");

            migrationBuilder.DropTable(
                name: "Barat");
        }
    }
}
