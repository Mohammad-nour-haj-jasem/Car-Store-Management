using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DominC11.Migrations
{
    /// <inheritdoc />
    public partial class Add_table_Cars_Parts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarPart");

            migrationBuilder.CreateTable(
                name: "Cars_Parts",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars_Parts", x => new { x.CarId, x.PartId });
                    table.ForeignKey(
                        name: "FK_Cars_Parts_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Parts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Parts_PartId",
                table: "Cars_Parts",
                column: "PartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars_Parts");

            migrationBuilder.CreateTable(
                name: "CarPart",
                columns: table => new
                {
                    CarsId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPart", x => new { x.CarsId, x.PartId });
                    table.ForeignKey(
                        name: "FK_CarPart_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarPart_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarPart_PartId",
                table: "CarPart",
                column: "PartId");
        }
    }
}
