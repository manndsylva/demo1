using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web1.Migrations
{
    /// <inheritdoc />
    public partial class RoleSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5fc77d6a-7d25-4398-95b5-5be4ed115fbc", "3", "HR", "HR" },
                    { "8d161744-c2d4-41a9-9df9-555894b9e4ea", "1", "Admin", "Admin" },
                    { "a8dfffad-535b-4a4f-b66b-671223188a96", "2", "User", "USer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fc77d6a-7d25-4398-95b5-5be4ed115fbc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d161744-c2d4-41a9-9df9-555894b9e4ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8dfffad-535b-4a4f-b66b-671223188a96");
        }
    }
}
