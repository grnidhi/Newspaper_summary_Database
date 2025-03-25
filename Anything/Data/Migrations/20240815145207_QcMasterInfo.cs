using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anything.Data.Migrations
{
    /// <inheritdoc />
    public partial class QcMasterInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QcMasters",
                columns: table => new
                {
                    QcMId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StageId = table.Column<int>(type: "int", nullable: false),
                    ParameterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParameterTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParameterType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Min = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Max = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QcMasters", x => x.QcMId);
                    table.ForeignKey(
                        name: "FK_QcMasters_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QcMasters_ProductMasters_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductMasters",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QcMasters_StageMasters_StageId",
                        column: x => x.StageId,
                        principalTable: "StageMasters",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QcMasters_CustomerId",
                table: "QcMasters",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_QcMasters_ProductId",
                table: "QcMasters",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_QcMasters_StageId",
                table: "QcMasters",
                column: "StageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QcMasters");
        }
    }
}