using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace radioKPI_D_infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EpisodeStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuestInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlacesOfWorkOrStudy = table.Column<string>(type: "varchar(200)", nullable: false),
                    JobTitlesOrSpecializations = table.Column<string>(type: "varchar(200)", nullable: false),
                    GuestDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    ReleaseNotes = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_EpisodeStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "EpisodeStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_GuestInfo_GuestId",
                        column: x => x.GuestId,
                        principalTable: "GuestInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proposals_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SessionReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionReports_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuestInfoSubject",
                columns: table => new
                {
                    GuestsId = table.Column<int>(type: "int", nullable: false),
                    SubjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestInfoSubject", x => new { x.GuestsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_GuestInfoSubject_GuestInfo_GuestsId",
                        column: x => x.GuestsId,
                        principalTable: "GuestInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestInfoSubject_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestSubjects",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestSubjects", x => new { x.SubjectId, x.GuestId });
                    table.ForeignKey(
                        name: "FK_GuestSubjects_GuestInfo_GuestId",
                        column: x => x.GuestId,
                        principalTable: "GuestInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suffleres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProposalId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suffleres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suffleres_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suffleres_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartialReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    SessionReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartialReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartialReports_SessionReports_SessionReportId",
                        column: x => x.SessionReportId,
                        principalTable: "SessionReports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartialReports_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recordings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechNotes = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    SufflereId = table.Column<int>(type: "int", nullable: false),
                    EpisodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recordings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recordings_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recordings_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recordings_Suffleres_SufflereId",
                        column: x => x.SufflereId,
                        principalTable: "Suffleres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EpisodeStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Planned" },
                    { 2, "InScripting" },
                    { 3, "InProduction" },
                    { 4, "InPost" },
                    { 5, "PreRelease" },
                    { 6, "Released" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "STEM" },
                    { 2, "Military" },
                    { 3, "Politics" },
                    { 4, "Activism" },
                    { 5, "Education" },
                    { 6, "VisualArts" },
                    { 7, "Music" },
                    { 8, "Entertainment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_StatusId",
                table: "Episodes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestInfoSubject_SubjectsId",
                table: "GuestInfoSubject",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestSubjects_GuestId",
                table: "GuestSubjects",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_PartialReports_SessionId",
                table: "PartialReports",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PartialReports_SessionReportId",
                table: "PartialReports",
                column: "SessionReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_GuestId",
                table: "Proposals",
                column: "GuestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_SessionId",
                table: "Proposals",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Recordings_EpisodeId",
                table: "Recordings",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recordings_SessionId",
                table: "Recordings",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Recordings_SufflereId",
                table: "Recordings",
                column: "SufflereId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionReports_SessionId",
                table: "SessionReports",
                column: "SessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suffleres_ProposalId",
                table: "Suffleres",
                column: "ProposalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suffleres_SessionId",
                table: "Suffleres",
                column: "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestInfoSubject");

            migrationBuilder.DropTable(
                name: "GuestSubjects");

            migrationBuilder.DropTable(
                name: "PartialReports");

            migrationBuilder.DropTable(
                name: "Recordings");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "SessionReports");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Suffleres");

            migrationBuilder.DropTable(
                name: "EpisodeStatuses");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "GuestInfo");

            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
