using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Asterisk.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AsteriskV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "Id",
                keyValue: new Guid("80bd60d0-a693-467c-9b94-835bf99191fd"));

            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "Id",
                keyValue: new Guid("efc8d64e-74ff-423c-b0d5-f96382829567"));

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "CreatedDate", "LineName", "MarginLeft", "MarginTop", "Width" },
                values: new object[,]
                {
                    { new Guid("3ae9f485-d10f-41bf-b11c-6438d164af3e"), new DateTime(2023, 10, 27, 0, 28, 16, 337, DateTimeKind.Local).AddTicks(5926), "Line 2", 1m, 140m, 450m },
                    { new Guid("d1ed420e-674c-455d-9a52-16a46e752fd0"), new DateTime(2023, 10, 27, 0, 28, 16, 337, DateTimeKind.Local).AddTicks(5873), "Line 1", 1m, 550m, 450m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "Id",
                keyValue: new Guid("3ae9f485-d10f-41bf-b11c-6438d164af3e"));

            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "Id",
                keyValue: new Guid("d1ed420e-674c-455d-9a52-16a46e752fd0"));

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "CreatedDate", "LineName", "MarginLeft", "MarginTop", "Width" },
                values: new object[,]
                {
                    { new Guid("80bd60d0-a693-467c-9b94-835bf99191fd"), new DateTime(2023, 10, 24, 0, 30, 58, 369, DateTimeKind.Local).AddTicks(8691), "Line 1", 1m, 550m, 450m },
                    { new Guid("efc8d64e-74ff-423c-b0d5-f96382829567"), new DateTime(2023, 10, 24, 0, 30, 58, 369, DateTimeKind.Local).AddTicks(8726), "Line 2", 1m, 140m, 450m }
                });
        }
    }
}
