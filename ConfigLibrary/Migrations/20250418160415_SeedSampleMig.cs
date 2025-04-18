using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConfigLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeedSampleMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Configs",
                columns: new[] { "Id", "ApplicationName", "IsActive", "LastModified", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "SERVICE-A", true, new DateTime(2025, 4, 18, 19, 4, 15, 365, DateTimeKind.Local).AddTicks(6906), "SiteName", "string", "soty.io" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "SERVICE-B", true, new DateTime(2025, 4, 18, 19, 4, 15, 365, DateTimeKind.Local).AddTicks(7106), "IsBasketEnabled", "bool", "1" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "SERVICE-A", false, new DateTime(2025, 4, 18, 19, 4, 15, 365, DateTimeKind.Local).AddTicks(7114), "MaxItemCount", "int", "50" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Configs",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Configs",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Configs",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));
        }
    }
}
