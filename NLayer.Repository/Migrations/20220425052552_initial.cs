using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(5175), true, "Stationary", null },
                    { 2, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(5194), true, "Technology", null },
                    { 3, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(5196), true, "Clothes", null },
                    { 4, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(5201), true, "Grocery", null }
                });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "CreatedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(6495), true, "Employee", null },
                    { 2, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(6498), true, "Affiliate", null },
                    { 3, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(6500), true, "Customer", null },
                    { 4, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(6502), true, "Other", null }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "CustomerTypeId", "Email", "IsActive", "LastName", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(6164), 1, "seftalisena@gmail.com", true, "ŞEFTALİ", "Sena", null },
                    { 2, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(6168), 2, "seftali@gmail.com", true, "ŞEFTALİ", "Fatih", null },
                    { 3, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(6170), 3, "seftali@gmail.com", true, "ŞEFTALİ", "Ayşe", null },
                    { 4, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(6172), 4, "seftali@gmail.com", true, "ŞEFTALİ", "Ekrem", null }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedDate", "CustomerTypeId", "DiscountTypeName", "IsActive", "Name", "Rate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(6791), 1, null, true, "Rate", 30m, null },
                    { 2, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(6794), 4, null, true, "Amount", 5m, null },
                    { 3, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(6796), 3, null, true, "Rate", 5m, null },
                    { 4, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(6904), 2, null, true, "Rate", 10m, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "IsActive", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(9379), true, "Kalem 1", 100m, 20, null },
                    { 2, 1, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(9382), true, "Fabel Castel Pencil", 200m, 30, null },
                    { 3, 1, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(9383), true, "Rotring Pencil", 600m, 60, null },
                    { 4, 2, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(9385), true, "Pc", 600m, 60, null },
                    { 5, 2, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(9391), true, "Phone", 6600m, 320, null },
                    { 6, 4, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(9387), true, "Pasta", 50m, 60, null },
                    { 7, 4, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(9389), true, "Meet", 100m, 60, null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "IsActive", "Status", "TotalAmount", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(9017), 1, true, 1, 1000m, null },
                    { 2, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(9020), 2, true, 1, 2000m, null },
                    { 3, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(9022), 3, true, 1, 3000m, null },
                    { 4, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(9024), 4, true, 1, 4000m, null }
                });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Width" },
                values: new object[,]
                {
                    { 1, "Kırmızı", 100, 1, 200 },
                    { 2, "Mavi", 300, 2, 500 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "IsActive", "OrderId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(8202), 1, true, 1, null },
                    { 2, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(8207), 2, true, 2, null },
                    { 3, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(8209), 3, true, 3, null },
                    { 4, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(8211), 4, true, 4, null }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 4, 0 },
                    { 2, 2, 7, 0 },
                    { 3, 3, 5, 0 },
                    { 4, 4, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceDetail",
                columns: new[] { "Id", "CreatedDate", "DiscountId", "InvoiceId", "IsActive", "Price", "Quantity", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(7194), 1, 1, true, 1500m, 3, null },
                    { 2, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(7197), 2, 2, true, 2500m, 1, null },
                    { 3, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(7199), 3, 3, true, 7500m, 5, null },
                    { 4, new DateTime(2022, 4, 25, 8, 25, 51, 226, DateTimeKind.Local).AddTicks(7201), 4, 4, true, 5500m, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_CustomerTypeId",
                table: "Discounts",
                column: "CustomerTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_DiscountId",
                table: "InvoiceDetail",
                column: "DiscountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_InvoiceId",
                table: "InvoiceDetail",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerTypes");
        }
    }
}
