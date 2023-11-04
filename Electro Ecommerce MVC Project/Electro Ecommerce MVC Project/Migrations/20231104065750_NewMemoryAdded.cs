using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electro_Ecommerce_MVC_Project.Migrations
{
    public partial class NewMemoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Memories",
                columns: new[] { "Id", "Count", "CreatedDate", "UpdatedDate" },
                values: new object[] { -6, "2 TB", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Memories",
                keyColumn: "Id",
                keyValue: -6);
        }
    }
}
