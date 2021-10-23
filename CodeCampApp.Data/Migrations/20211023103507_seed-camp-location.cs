using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeCampApp.Data.Migrations
{
    public partial class seedcamplocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "LocationId", "Address1", "Address2", "Address3", "CityTown", "Country", "PostalCode", "StateProvince", "VenueName" },
                values: new object[] { 1, null, null, null, null, null, null, null, "BOgi oiid" });

            migrationBuilder.UpdateData(
                table: "Camps",
                keyColumn: "CampId",
                keyValue: 1,
                columns: new[] { "EventDate", "LocationId" },
                values: new object[] { new DateTime(2021, 10, 23, 21, 5, 6, 881, DateTimeKind.Local).AddTicks(9218), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "LocationId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Camps",
                keyColumn: "CampId",
                keyValue: 1,
                columns: new[] { "EventDate", "LocationId" },
                values: new object[] { new DateTime(2021, 10, 23, 19, 1, 56, 382, DateTimeKind.Local).AddTicks(194), null });
        }
    }
}
