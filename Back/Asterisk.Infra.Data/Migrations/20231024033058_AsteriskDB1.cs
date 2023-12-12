using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Asterisk.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AsteriskDB1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AmountOfPeople = table.Column<int>(type: "int", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LineName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Width = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    MarginTop = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    MarginLeft = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Degrees = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "CreatedDate", "LineName", "MarginLeft", "MarginTop", "Width" },
                values: new object[,]
                {
                    { new Guid("80bd60d0-a693-467c-9b94-835bf99191fd"), new DateTime(2023, 10, 24, 0, 30, 58, 369, DateTimeKind.Local).AddTicks(8691), "Line 1", 1m, 550m, 450m },
                    { new Guid("efc8d64e-74ff-423c-b0d5-f96382829567"), new DateTime(2023, 10, 24, 0, 30, 58, 369, DateTimeKind.Local).AddTicks(8726), "Line 2", 1m, 140m, 450m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lines_LineName",
                table: "Lines",
                column: "LineName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Lines");

            migrationBuilder.DropTable(
                name: "Temperatures");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
