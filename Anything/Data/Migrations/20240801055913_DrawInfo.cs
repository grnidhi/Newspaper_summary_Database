using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anything.Data.Migrations
{
    /// <inheritdoc />
    public partial class DrawInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Draws",
                columns: table => new
                {
                    DrawingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draws", x => x.DrawingId);
                    table.ForeignKey(
                        name: "FK_Draws_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Draws_processMs_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "processMs",
                        principalColumn: "ProcessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Draws_CustomerId",
                table: "Draws",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Draws_ProcessId",
                table: "Draws",
                column: "ProcessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Draws");
        }
    }
}
