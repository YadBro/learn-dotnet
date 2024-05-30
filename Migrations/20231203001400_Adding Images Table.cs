using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileDescription = table.Column<string>(type: "text", nullable: true),
                    FileExtension = table.Column<string>(type: "text", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1b5ae5d5-f1b6-4f0b-8ade-e2566f543c69"), "Hard" },
                    { new Guid("8e3f492b-4138-44f2-92a2-1e07e55ac362"), "Easy" },
                    { new Guid("9eb9344d-289c-43b0-9a55-12ec36958499"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageURL" },
                values: new object[,]
                {
                    { new Guid("942f65d8-edbe-4eb6-9903-13bdd9e1f6e5"), "ID", "Indonesia", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/Flag_of_Indonesia.svg/510px-Flag_of_Indonesia.svg.png" },
                    { new Guid("ac21b38f-a6a8-42fb-a4ad-7d765233ff8e"), "TG", "Testing", null },
                    { new Guid("cd6f5294-e0a6-4958-a2ea-ad2f7990ac5c"), "PS", "Palestine", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/00/Flag_of_Palestine.svg/510px-Flag_of_Palestine.svg.png" },
                    { new Guid("cd95dfe6-6356-4955-902f-2ea7edd60bab"), "MY", "Malaysia", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/66/Flag_of_Malaysia.svg/510px-Flag_of_Malaysia.svg.png" }
                });

            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageURL" },
                values: new object[,]
                {
                    { new Guid("1431b016-1b82-4edc-aef5-b327a7e55f75"), "This walk takes you along the wild and rugged coastline of Makara Beach, with breathtaking views of the Tasman Sea.", new Guid("9eb9344d-289c-43b0-9a55-12ec36958499"), 8.1999999999999993, "Makara Beach Walkway", new Guid("cd95dfe6-6356-4955-902f-2ea7edd60bab"), "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("235fa61a-b6dd-4dd5-8e32-2523fd15bdb8"), "Explore the beautiful Botanic Garden of Wellington on this leisurely walk, with a wide variety of plants and flowers to admire.", new Guid("1b5ae5d5-f1b6-4f0b-8ade-e2566f543c69"), 0.0, "Botanic Garden Walk", new Guid("cd6f5294-e0a6-4958-a2ea-ad2f7990ac5c"), null },
                    { new Guid("6439d890-5acd-4199-b13b-3710011b9667"), "This scenic walk takes you around the top of Mount Victoria, offering stunning views of Wellington and its harbor.", new Guid("8e3f492b-4138-44f2-92a2-1e07e55ac362"), 3.5, "Mount Victoria Loop", new Guid("942f65d8-edbe-4eb6-9903-13bdd9e1f6e5"), "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ac21b38f-a6a8-42fb-a4ad-7d765233ff8e"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("1431b016-1b82-4edc-aef5-b327a7e55f75"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("235fa61a-b6dd-4dd5-8e32-2523fd15bdb8"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("6439d890-5acd-4199-b13b-3710011b9667"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1b5ae5d5-f1b6-4f0b-8ade-e2566f543c69"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8e3f492b-4138-44f2-92a2-1e07e55ac362"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9eb9344d-289c-43b0-9a55-12ec36958499"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("942f65d8-edbe-4eb6-9903-13bdd9e1f6e5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cd6f5294-e0a6-4958-a2ea-ad2f7990ac5c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cd95dfe6-6356-4955-902f-2ea7edd60bab"));

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
    }
}
