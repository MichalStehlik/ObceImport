using Microsoft.EntityFrameworkCore.Migrations;

namespace ObceImport.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    LAU2 = table.Column<string>(maxLength: 6, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LAU1 = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.LAU2);
                });

            migrationBuilder.CreateTable(
                name: "Populations",
                columns: table => new
                {
                    LAU2 = table.Column<string>(maxLength: 6, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    Men = table.Column<int>(nullable: false),
                    Women = table.Column<int>(nullable: false),
                    Age = table.Column<double>(nullable: false),
                    MensAge = table.Column<double>(nullable: false),
                    WomensAge = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Populations", x => new { x.LAU2, x.Year });
                    table.ForeignKey(
                        name: "FK_Populations_Municipalities_LAU2",
                        column: x => x.LAU2,
                        principalTable: "Municipalities",
                        principalColumn: "LAU2",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    NUTS3 = table.Column<string>(maxLength: 5, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LAU2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.NUTS3);
                    table.ForeignKey(
                        name: "FK_Regions_Municipalities_LAU2",
                        column: x => x.LAU2,
                        principalTable: "Municipalities",
                        principalColumn: "LAU2",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    LAU1 = table.Column<string>(maxLength: 6, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NUTS3 = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.LAU1);
                    table.ForeignKey(
                        name: "FK_Districts_Regions_NUTS3",
                        column: x => x.NUTS3,
                        principalTable: "Regions",
                        principalColumn: "NUTS3",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_NUTS3",
                table: "Districts",
                column: "NUTS3");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_LAU1",
                table: "Municipalities",
                column: "LAU1");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_LAU2",
                table: "Regions",
                column: "LAU2");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipalities_Districts_LAU1",
                table: "Municipalities",
                column: "LAU1",
                principalTable: "Districts",
                principalColumn: "LAU1",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Regions_NUTS3",
                table: "Districts");

            migrationBuilder.DropTable(
                name: "Populations");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}
