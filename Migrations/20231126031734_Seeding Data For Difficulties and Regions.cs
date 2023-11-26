using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegionImageURL",
                table: "Regions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05e427f9-528a-45a0-acb3-2e88a6622373"), "Medium" },
                    { new Guid("1fa80d41-f2f6-469e-b8d7-ae4a43f579f8"), "Hard" },
                    { new Guid("35fdc8e3-7e98-4c75-8bd4-f992bc222951"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageURL" },
                values: new object[,]
                {
                    { new Guid("477ed622-1e0d-4649-a11a-dfe43f06d868"), "PS", "Palestine", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/00/Flag_of_Palestine.svg/510px-Flag_of_Palestine.svg.png" },
                    { new Guid("59c3cbe6-e480-4e92-9a4b-0d069ef7c230"), "MY", "Malaysia", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/66/Flag_of_Malaysia.svg/510px-Flag_of_Malaysia.svg.png" },
                    { new Guid("c2eb7d91-a9fb-4740-8e31-c0f2fa7ab2bc"), "TG", "Testing", null },
                    { new Guid("ca0c3446-415f-4385-be83-d6e1b3524939"), "ID", "Indonesia", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/Flag_of_Indonesia.svg/510px-Flag_of_Indonesia.svg.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("05e427f9-528a-45a0-acb3-2e88a6622373"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1fa80d41-f2f6-469e-b8d7-ae4a43f579f8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("35fdc8e3-7e98-4c75-8bd4-f992bc222951"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("477ed622-1e0d-4649-a11a-dfe43f06d868"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("59c3cbe6-e480-4e92-9a4b-0d069ef7c230"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c2eb7d91-a9fb-4740-8e31-c0f2fa7ab2bc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ca0c3446-415f-4385-be83-d6e1b3524939"));

            migrationBuilder.AlterColumn<string>(
                name: "RegionImageURL",
                table: "Regions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
