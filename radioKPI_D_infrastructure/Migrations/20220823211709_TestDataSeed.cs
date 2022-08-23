using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace radioKPI_D_infrastructure.Migrations
{
    public partial class TestDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "Id", "Description", "ReleaseDate", "ReleaseNotes", "StatusId" },
                values: new object[,]
                {
                    { 1, "AI pod", null, null, 4 },
                    { 2, "Music pod", null, null, 4 },
                    { 3, "Something with BIKES", null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "GuestInfo",
                columns: new[] { "Id", "GuestDetails", "JobTitlesOrSpecializations", "PlacesOfWorkOrStudy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "Junior year student at System Analysis Institute at KPI.", "Engineer", "KPI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Officer of the Armed Forces of Ukraine.", "Captain", "AFU", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Jazz drummer at Phronesis.", "Drummer", "Phronesis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "RecordingDate", "UpdatedOn" },
                values: new object[] { 1, new DateTime(2022, 9, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "Description", "GuestId", "OrgNotes", "SessionId", "UpdatedOn" },
                values: new object[] { 1, "Engineering at KPI, robotics, AI", 1, "Free on weekends after 13:00", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "Description", "GuestId", "OrgNotes", "SessionId", "UpdatedOn" },
                values: new object[] { 2, "Jazz music, art of improvisation, performer's community.", 2, "Only available on Saturday Sep.10 from 15:30 to 17:00", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Suffleres",
                columns: new[] { "Id", "DataJson", "ProposalId", "SessionId", "UpdatedOn" },
                values: new object[] { 1, "JSON string with sufflere data for podcast with AI and robotics engineering student form KPI.", 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Suffleres",
                columns: new[] { "Id", "DataJson", "ProposalId", "SessionId", "UpdatedOn" },
                values: new object[] { 2, "JSON string with sufflere data for podcast with Phronesis drummer.", 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Recordings",
                columns: new[] { "Id", "EpisodeId", "SessionId", "SufflereId", "TechNotes" },
                values: new object[] { 1, 1, 1, 1, "AI pod" });

            migrationBuilder.InsertData(
                table: "Recordings",
                columns: new[] { "Id", "EpisodeId", "SessionId", "SufflereId", "TechNotes" },
                values: new object[] { 2, 2, 1, 2, "Music pod" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GuestInfo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recordings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recordings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suffleres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suffleres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GuestInfo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GuestInfo",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
