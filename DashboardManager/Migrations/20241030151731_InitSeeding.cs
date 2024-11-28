using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DashboardManager.Migrations
{
    /// <inheritdoc />
    public partial class InitSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Images", "Name" },
                values: new object[,]
                {
                    { 1, "brandA.jpg", "Brand A" },
                    { 2, "brandB.jpg", "Brand B" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Images", "Name" },
                values: new object[,]
                {
                    { 1, "electronics.jpg", "Electronics" },
                    { 2, "clothing.jpg", "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Avatar", "Birthday", "CreatedAt", "Description", "DistrictId", "Email", "EmailVerifiedAt", "FullName", "Ip", "Password", "Phone", "ProvinceId", "Role", "UpdatedAt", "UserAgent", "WardId" },
                values: new object[,]
                {
                    { 1, "123 Admin St", "avatar1.png", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(2985), "Administrator", "001", "admin@example.com", new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(2984), "Admin User", "192.168.1.1", "hashed_password", "0123456789", "01", (byte)1, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(2985), "Mozilla/5.0", "0001" },
                    { 2, "456 User St", "avatar2.png", new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(2990), "Regular user", "002", "user@example.com", new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(2989), "Normal User", "192.168.1.2", "hashed_password", "0987654321", "02", (byte)0, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(2990), "Mozilla/5.0", "0002" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedAt", "Note", "Status", "Total", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3116), "Urgent delivery", (byte)1, 149.98m, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3116), 1 },
                    { 2, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3119), "Regular delivery", (byte)0, 49.99m, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3119), 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "CategoryId", "CreatedAt", "Description", "Images", "Name", "OldPrice", "Price", "PurchaseCount", "Quantity", "Specification", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3096), "Description for Product 1", "product1.jpg", "Product 1", 120.00m, 99.99m, 100, 10, "Specs for Product 1", new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3097) },
                    { 2, 2, 2, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3100), "Description for Product 2", "product2.jpg", "Product 2", 70.00m, 49.99m, 200, 20, "Specs for Product 2", new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3101) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "FeedbackId", "Content", "CreatedAt", "ProductId", "Star", "Status", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "Excellent product!", new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3163), 1, (byte)5, (byte)1, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3164), 1 },
                    { 2, "Good value for money.", new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3166), 2, (byte)4, (byte)1, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3167), 2 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "CreatedAt", "OrderId", "Price", "ProductId", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3179), 1, 99.99m, 1, 1, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3180) },
                    { 2, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3182), 1, 49.99m, 2, 1, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3182) },
                    { 3, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3184), 2, 49.99m, 2, 1, new DateTime(2024, 10, 30, 22, 17, 31, 290, DateTimeKind.Local).AddTicks(3184) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeName" },
                values: new object[,]
                {
                    { 1, "Grade 1" },
                    { 2, "Grade 2" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "GradeId", "StudentName" },
                values: new object[,]
                {
                    { 1, 1, "John Doe" },
                    { 2, 1, "Jane Smith" },
                    { 3, 2, "Samuel Brown" }
                });
        }
    }
}
