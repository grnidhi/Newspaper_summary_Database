using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anything.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderMasterDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderMasters",
                columns: table => new
                {
                    Oid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    KeyDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DrawingId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderQty = table.Column<int>(type: "int", nullable: false),
                    Revision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSNcode = table.Column<int>(type: "int", nullable: false),
                    Itemcode = table.Column<int>(type: "int", nullable: false),
                    AddInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BarcodesSerialized = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    len = table.Column<int>(type: "int", nullable: false),
                    Po = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMasters", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_OrderMasters_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderMasters_Draws_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Draws",
                        principalColumn: "DrawingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderMasters_ProductMasters_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductMasters",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderMasters_CustomerId",
                table: "OrderMasters",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMasters_DrawingId",
                table: "OrderMasters",
                column: "DrawingId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMasters_ProductId",
                table: "OrderMasters",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderMasters");
        }
    }
}
