using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anything.Data.Migrations
{
    /// <inheritdoc />
    public partial class StageDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StageMasters",
                columns: table => new
                {
                    StageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StageDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    DrawingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageMasters", x => x.StageId);
                    table.ForeignKey(
                        name: "FK_StageMasters_Draws_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Draws",
                        principalColumn: "DrawingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StageMasters_processMs_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "processMs",
                        principalColumn: "ProcessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StageMasters_DrawingId",
                table: "StageMasters",
                column: "DrawingId");

            migrationBuilder.CreateIndex(
                name: "IX_StageMasters_ProcessId",
                table: "StageMasters",
                column: "ProcessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StageMasters");
        }
    }
}
