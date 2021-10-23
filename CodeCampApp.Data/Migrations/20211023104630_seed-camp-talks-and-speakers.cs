using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeCampApp.Data.Migrations
{
    public partial class seedcamptalksandspeakers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Camps",
                keyColumn: "CampId",
                keyValue: 1,
                column: "EventDate",
                value: new DateTime(2021, 10, 23, 21, 16, 29, 912, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "SpeakerId", "BlogUrl", "Company", "CompanyUrl", "FirstName", "GitHub", "LastName", "MiddleName", "Twitter" },
                values: new object[] { 2, "http://shawnandresa.com", "Wilder Minds LLC", "http://wilderminds.com", "Resa", "resawildermuth", "Wildermuth", null, "resawildermuth" });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "SpeakerId", "BlogUrl", "Company", "CompanyUrl", "FirstName", "GitHub", "LastName", "MiddleName", "Twitter" },
                values: new object[] { 1, "http://wildermuth.com", "Wilder Minds LLC", "http://wilderminds.com", "Shawn", "shawnwildermuth", "Wildermuth", null, "shawnwildermuth" });

            migrationBuilder.InsertData(
                table: "Talks",
                columns: new[] { "TalkId", "Abstract", "CampId", "Level", "SpeakerId", "Title" },
                values: new object[] { 1, "Entity Framework from scratch in an hour. Probably cover it all", 1, 100, 1, "Entity Framework From Scratch" });

            migrationBuilder.InsertData(
                table: "Talks",
                columns: new[] { "TalkId", "Abstract", "CampId", "Level", "SpeakerId", "Title" },
                values: new object[] { 2, "Thinking of good sample data examples is tiring.", 1, 200, 2, "Writing Sample Data Made Easy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Talks",
                keyColumn: "TalkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Talks",
                keyColumn: "TalkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "SpeakerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "SpeakerId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Camps",
                keyColumn: "CampId",
                keyValue: 1,
                column: "EventDate",
                value: new DateTime(2021, 10, 23, 21, 5, 6, 881, DateTimeKind.Local).AddTicks(9218));
        }
    }
}
