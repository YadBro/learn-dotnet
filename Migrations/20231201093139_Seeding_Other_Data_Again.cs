using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Seeding_Other_Data_Again : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("08cb7b16-b9d2-4562-936a-f288d887023a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3879809c-4301-42f2-9910-01826de051a9"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6d1eaf2a-00bf-4356-adee-f8360a0dc38b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("05400c25-be52-4bab-ab21-edb931ec6e88"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4c57f343-ead8-4f5a-828f-8694f2a3d214"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a51b3ed2-f5e6-455e-b0e6-02f92357c5f6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f00958b0-8493-4aab-bea1-15e381f91e42"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f6d5d40-95df-4643-984f-2648f7e881fa"), "Hard" },
                    { new Guid("1cb4b809-95a0-4295-9c21-50c1a0555262"), "Medium" },
                    { new Guid("48efa303-f83c-48cb-b0cc-4159add849f4"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageURL" },
                values: new object[,]
                {
                    { new Guid("00862174-10e6-413f-820c-92f3d52219bf"), "MY", "Malaysia", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/66/Flag_of_Malaysia.svg/510px-Flag_of_Malaysia.svg.png" },
                    { new Guid("9662132f-c46c-46d1-855c-7280e6556c01"), "PS", "Palestine", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/00/Flag_of_Palestine.svg/510px-Flag_of_Palestine.svg.png" },
                    { new Guid("c71cab5c-816e-4fa1-b173-78bd1594b035"), "ID", "Indonesia", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/Flag_of_Indonesia.svg/510px-Flag_of_Indonesia.svg.png" },
                    { new Guid("e20c8c35-8220-41fc-b416-9b5726156f3e"), "TG", "Testing", null }
                });

            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageURL" },
                values: new object[,]
                {
                    { new Guid("36eaa8b0-2c0a-4032-a07a-555ad238a56c"), "This scenic walk takes you around the top of Mount Victoria, offering stunning views of Wellington and its harbor.", new Guid("48efa303-f83c-48cb-b0cc-4159add849f4"), 3.5, "Mount Victoria Loop", new Guid("c71cab5c-816e-4fa1-b173-78bd1594b035"), "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("9d6c4d8a-d2e1-43c2-b656-c56f4279d8ed"), "This walk takes you along the wild and rugged coastline of Makara Beach, with breathtaking views of the Tasman Sea.", new Guid("1cb4b809-95a0-4295-9c21-50c1a0555262"), 8.1999999999999993, "Makara Beach Walkway", new Guid("00862174-10e6-413f-820c-92f3d52219bf"), "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("cb47d5fc-aa88-47ad-8e86-02c3b1fffa2b"), "Explore the beautiful Botanic Garden of Wellington on this leisurely walk, with a wide variety of plants and flowers to admire.", new Guid("0f6d5d40-95df-4643-984f-2648f7e881fa"), 0.0, "Botanic Garden Walk", new Guid("9662132f-c46c-46d1-855c-7280e6556c01"), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e20c8c35-8220-41fc-b416-9b5726156f3e"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("36eaa8b0-2c0a-4032-a07a-555ad238a56c"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("9d6c4d8a-d2e1-43c2-b656-c56f4279d8ed"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("cb47d5fc-aa88-47ad-8e86-02c3b1fffa2b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0f6d5d40-95df-4643-984f-2648f7e881fa"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1cb4b809-95a0-4295-9c21-50c1a0555262"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("48efa303-f83c-48cb-b0cc-4159add849f4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("00862174-10e6-413f-820c-92f3d52219bf"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9662132f-c46c-46d1-855c-7280e6556c01"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c71cab5c-816e-4fa1-b173-78bd1594b035"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("08cb7b16-b9d2-4562-936a-f288d887023a"), "Easy" },
                    { new Guid("3879809c-4301-42f2-9910-01826de051a9"), "Medium" },
                    { new Guid("6d1eaf2a-00bf-4356-adee-f8360a0dc38b"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageURL" },
                values: new object[,]
                {
                    { new Guid("05400c25-be52-4bab-ab21-edb931ec6e88"), "PS", "Palestine", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/00/Flag_of_Palestine.svg/510px-Flag_of_Palestine.svg.png" },
                    { new Guid("4c57f343-ead8-4f5a-828f-8694f2a3d214"), "MY", "Malaysia", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/66/Flag_of_Malaysia.svg/510px-Flag_of_Malaysia.svg.png" },
                    { new Guid("a51b3ed2-f5e6-455e-b0e6-02f92357c5f6"), "TG", "Testing", null },
                    { new Guid("f00958b0-8493-4aab-bea1-15e381f91e42"), "ID", "Indonesia", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/Flag_of_Indonesia.svg/510px-Flag_of_Indonesia.svg.png" }
                });
        }
    }
}
