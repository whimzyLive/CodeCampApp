using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeCampApp.Data.Migrations
{
    public partial class seedcamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Camps",
                columns: new[] { "CampId", "EventDate", "Length", "LocationId", "Moniker", "Name" },
                values: new object[] { 1, new DateTime(2021, 10, 23, 18, 54, 34, 107, DateTimeKind.Local).AddTicks(8400), 15, null, null, "Atlanta 2021" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Camps",
                keyColumn: "CampId",
                keyValue: 1);
        }
    }
}
