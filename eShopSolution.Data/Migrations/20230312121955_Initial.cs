using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    DiscountPercent = table.Column<float>(nullable: false),
                    Brand = table.Column<string>(maxLength: 50, nullable: true),
                    Category = table.Column<string>(maxLength: 50, nullable: true),
                    StockQuantity = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Path_Img = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Deleted = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true),
                    Role = table.Column<int>(nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Contact = table.Column<string>(maxLength: 50, nullable: true),
                    Path_Img = table.Column<string>(maxLength: 50, nullable: true),
                    VerifyEmail = table.Column<bool>(nullable: false),
                    VerifyContact = table.Column<bool>(nullable: false),
                    Deleted = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    VerifyToken = table.Column<string>(maxLength: 100, nullable: true),
                    VerifyAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Paided = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    Deleted = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(nullable: true),
                    ProductID = table.Column<int>(nullable: true),
                    Paided = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    Deleted = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserID",
                table: "Order",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
