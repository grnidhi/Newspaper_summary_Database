using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anything.Data.Migrations
{
    /// <inheritdoc />
    public partial class OperateDeatils : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operates",
                columns: table => new
                {
                    OpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawingId = table.Column<int>(type: "int", nullable: false),
                    StageId = table.Column<int>(type: "int", nullable: false),
                    OperatorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperatorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operates", x => x.OpId);
                    table.ForeignKey(
                        name: "FK_Operates_Draws_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Draws",
                        principalColumn: "DrawingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operates_LineMasters_LineId",
                        column: x => x.LineId,
                        principalTable: "LineMasters",
                        principalColumn: "LineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operates_SelectShifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "SelectShifts",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operates_StageMasters_StageId",
                        column: x => x.StageId,
                        principalTable: "StageMasters",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operates_DrawingId",
                table: "Operates",
                column: "DrawingId");

            migrationBuilder.CreateIndex(
                name: "IX_Operates_LineId",
                table: "Operates",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Operates_ShiftId",
                table: "Operates",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Operates_StageId",
                table: "Operates",
                column: "StageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operates");
        }
    }
}
