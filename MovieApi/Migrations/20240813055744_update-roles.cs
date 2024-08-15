using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Migrations
{
    public partial class updateroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0a1ab76c-f48f-4a5c-bb96-322f0b94328a"),
                column: "Name",
                value: "user");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("79e41692-64f5-4789-ac63-f266f7b8ac8e"),
                column: "Name",
                value: "admin");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("c005b7d5-ffc0-45a2-bd74-12a780fd9b61"), "vip user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c005b7d5-ffc0-45a2-bd74-12a780fd9b61"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0a1ab76c-f48f-4a5c-bb96-322f0b94328a"),
                column: "Name",
                value: "writer");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("79e41692-64f5-4789-ac63-f266f7b8ac8e"),
                column: "Name",
                value: "reader");
        }
    }
}
