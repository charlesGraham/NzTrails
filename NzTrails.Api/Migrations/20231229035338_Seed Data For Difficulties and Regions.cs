using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NzTrails.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2616c7a2-361e-4bfe-8fb1-7e6b78613110"), "Easy" },
                    { new Guid("a67fd31c-48b4-4512-af85-a5026b9dc8ac"), "Medium" },
                    { new Guid("b909e102-859a-403f-ba9e-94630407ca1e"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("170c6236-1b93-43ee-a27b-9c698c5214d3"), "NSN", "Nelson", "nelson-region-img.jpg" },
                    { new Guid("6a12ef70-b748-40a3-8033-307ae17da5fa"), "STL", "Southland", "southland-region-img.jpg" },
                    { new Guid("739d1a2e-d7a3-4c8d-aa7b-b57087ce001f"), "WGN", "Wellington", "wellington-region-img.jpg" },
                    { new Guid("f78584b4-ba8e-40e8-82a7-6e4aa86db26d"), "AKL", "Auckland", "auckland-region-img.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2616c7a2-361e-4bfe-8fb1-7e6b78613110"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a67fd31c-48b4-4512-af85-a5026b9dc8ac"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b909e102-859a-403f-ba9e-94630407ca1e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("170c6236-1b93-43ee-a27b-9c698c5214d3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6a12ef70-b748-40a3-8033-307ae17da5fa"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("739d1a2e-d7a3-4c8d-aa7b-b57087ce001f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f78584b4-ba8e-40e8-82a7-6e4aa86db26d"));
        }
    }
}
