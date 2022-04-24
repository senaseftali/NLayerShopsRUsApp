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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
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
                name: "CustomerCustomerType",
                columns: table => new
                {
                    CustomerTypesId = table.Column<int>(type: "int", nullable: false),
                    CustomersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCustomerType", x => new { x.CustomerTypesId, x.CustomersId });
                    table.ForeignKey(
                        name: "FK_CustomerCustomerType_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCustomerType_CustomerTypes_CustomerTypesId",
                        column: x => x.CustomerTypesId,
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
                name: "OrderDetail",
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
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Products_ProductId",
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
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Stationary", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Technology", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Clothes", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Grocery", null }
                });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "CreatedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(7976), true, "Employee", null },
                    { 2, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(7978), true, "Affiliate", null },
                    { 3, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(7979), true, "Customer", null },
                    { 4, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(7980), true, "Other", null }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "Email", "IsActive", "LastName", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(7832), "seftalisena@gmail.com", true, "ŞEFTALİ", "Sena", null },
                    { 2, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(7841), "seftali@gmail.com", true, "ŞEFTALİ", "Fatih", null },
                    { 3, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(7843), "seftali@gmail.com", true, "ŞEFTALİ", "Ayşe", null },
                    { 4, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(7843), "seftali@gmail.com", true, "ŞEFTALİ", "Ekrem", null },
                    { 5, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(7846), "seftali@gmail.com", true, "ŞEFTALİ", "Ömer", null },
                    { 6, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(7844), "seftali@gmail.com", true, "ŞEFTALİ", "Elif", null },
                    { 7, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(7845), "seftali@gmail.com", true, "ŞEFTALİ", "Şeyma", null }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedDate", "CustomerTypeId", "IsActive", "Name", "Rate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8112), 1, true, "Percentage Discount", 30m, null },
                    { 2, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8113), 4, true, "Flat Discount", 5m, null },
                    { 3, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8114), 3, true, "Percentage Discount", 5m, null },
                    { 4, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8114), 2, true, "Percentage Discount", 10m, null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "IsActive", "Status", "TotalAmount", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8677), 1, true, 1, 1000m, null },
                    { 2, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8681), 2, true, 1, 2000m, null },
                    { 3, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8682), 3, true, 1, 3000m, null },
                    { 4, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8683), 4, true, 1, 4000m, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "IsActive", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8800), true, "Kalem 1", 100m, 20, null },
                    { 2, 1, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8802), true, "Fabel Castel Pencil", 200m, 30, null },
                    { 3, 1, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8802), true, "Rotring Pencil", 600m, 60, null },
                    { 4, 2, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8803), true, "Pc", 600m, 60, null },
                    { 5, 2, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8809), true, "Phone", 6600m, 320, null },
                    { 6, 4, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8807), true, "Pasta", 50m, 60, null },
                    { 7, 4, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8808), true, "Meet", 100m, 60, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "IsActive", "OrderId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8405), 1, true, 1, null },
                    { 2, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8406), 2, true, 2, null },
                    { 3, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8407), 3, true, 3, null },
                    { 4, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8407), 4, true, 4, null }
                });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 4, 0 },
                    { 2, 2, 7, 0 },
                    { 3, 3, 5, 0 },
                    { 4, 4, 3, 0 }
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
                table: "InvoiceDetail",
                columns: new[] { "Id", "CreatedDate", "DiscountId", "InvoiceId", "IsActive", "Price", "Quantity", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8237), 1, 1, true, 1500m, 3, null },
                    { 2, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8239), 2, 2, true, 2500m, 1, null },
                    { 3, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8240), 3, 3, true, 7500m, 5, null },
                    { 4, new DateTime(2022, 4, 24, 18, 35, 57, 680, DateTimeKind.Local).AddTicks(8241), 4, 4, true, 5500m, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCustomerType_CustomersId",
                table: "CustomerCustomerType",
                column: "CustomersId");

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
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
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
                name: "CustomerCustomerType");

            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CustomerTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
