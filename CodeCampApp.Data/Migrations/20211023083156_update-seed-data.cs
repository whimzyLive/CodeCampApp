using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeCampApp.Data.Migrations
{
    public partial class updateseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Camps",
                keyColumn: "CampId",
                keyValue: 1,
                columns: new[] { "EventDate", "Moniker" },
                values: new object[] { new DateTime(2021, 10, 23, 19, 1, 56, 382, DateTimeKind.Local).AddTicks(194), "ATL2021" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Camps",
                keyColumn: "CampId",
                keyValue: 1,
                columns: new[] { "EventDate", "Moniker" },
                values: new object[] { new DateTime(2021, 10, 23, 18, 54, 34, 107, DateTimeKind.Local).AddTicks(8400), null });
        }
    }
}
