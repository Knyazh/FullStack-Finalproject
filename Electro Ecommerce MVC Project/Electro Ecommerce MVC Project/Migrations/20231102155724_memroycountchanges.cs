using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electro_Ecommerce_MVC_Project.Migrations
{
    public partial class memroycountchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Count",
                table: "Memory",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { -10, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), " The iPhone 13 Pro is Apple's flagship smartphone, offering a stunning Super Retina XDR display, a powerful A15 Bionic chip, and a versatile triple-camera system for capturing high-quality photos and videos. With 5G connectivity, Face ID, and the latest iOS features, it's a top choice for those who demand performance and cutting-edge technology.", "Laptop", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -9, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), " The iPhone 13 Pro is Apple's flagship smartphone, offering a stunning Super Retina XDR display, a powerful A15 Bionic chip, and a versatile triple-camera system for capturing high-quality photos and videos. With 5G connectivity, Face ID, and the latest iOS features, it's a top choice for those who demand performance and cutting-edge technology.", "Phone", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -8, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), " The iPhone 13 Pro is Apple's flagship smartphone, offering a stunning Super Retina XDR display, a powerful A15 Bionic chip, and a versatile triple-camera system for capturing high-quality photos and videos. With 5G connectivity, Face ID, and the latest iOS features, it's a top choice for those who demand performance and cutting-edge technology.", "SmartWatches", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -7, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), " The iPhone 13 Pro is Apple's flagship smartphone, offering a stunning Super Retina XDR display, a powerful A15 Bionic chip, and a versatile triple-camera system for capturing high-quality photos and videos. With 5G connectivity, Face ID, and the latest iOS features, it's a top choice for those who demand performance and cutting-edge technology.", "4k Smart Tv", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -6, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), " The iPhone 13 Pro is Apple's flagship smartphone, offering a stunning Super Retina XDR display, a powerful A15 Bionic chip, and a versatile triple-camera system for capturing high-quality photos and videos. With 5G connectivity, Face ID, and the latest iOS features, it's a top choice for those who demand performance and cutting-edge technology.", "Gaming Consoles", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Code", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { -7, "#fbff00", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Yellow", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -5, "#000000", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Black", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -4, "#666666", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Gray", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -3, "#0052d6", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Blue", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -2, "#ffffff", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "White", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -1, "#ff0000", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Red", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Memory",
                columns: new[] { "Id", "Count", "CreatedDate", "UpdatedDate" },
                values: new object[,]
                {
                    { -5, "64 GB", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -4, "128 GB", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -3, "256 GB", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -2, "512GB", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -1, "1 TB", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Memory",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Memory",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Memory",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Memory",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Memory",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AlterColumn<decimal>(
                name: "Count",
                table: "Memory",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
