using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anything.Data.Migrations
{
    /// <inheritdoc />
    public partial class Details : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StageConns",
                columns: table => new
                {
                    SCid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GId = table.Column<int>(type: "int", nullable: false),
                    CurrentStageId = table.Column<int>(type: "int", nullable: false),
                    FailStageId = table.Column<int>(type: "int", nullable: false),
                    PassStageId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageConns", x => x.SCid);
                    table.ForeignKey(
                        name: "FK_StageConns_Group_GId",
                        column: x => x.GId,
                        principalTable: "Group",
                        principalColumn: "GId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StageConns_StageMasters_CurrentStageId",
                        column: x => x.CurrentStageId,
                        principalTable: "StageMasters",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StageConns_StageMasters_FailStageId",
                        column: x => x.FailStageId,
                        principalTable: "StageMasters",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StageConns_StageMasters_PassStageId",
                        column: x => x.PassStageId,
                        principalTable: "StageMasters",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StageConns_CurrentStageId",
                table: "StageConns",
                column: "CurrentStageId");

            migrationBuilder.CreateIndex(
                name: "IX_StageConns_FailStageId",
                table: "StageConns",
                column: "FailStageId");

            migrationBuilder.CreateIndex(
                name: "IX_StageConns_GId",
                table: "StageConns",
                column: "GId");

            migrationBuilder.CreateIndex(
                name: "IX_StageConns_PassStageId",
                table: "StageConns",
                column: "PassStageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StageConns");
        }
    }
}
