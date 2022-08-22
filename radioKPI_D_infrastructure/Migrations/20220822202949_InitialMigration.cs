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
                name: "EpisodeStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeStatus", x => x.Id);
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
                name: "ProcessStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", nullable: false),
                    GuestInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_GuestInfo_GuestInfoId",
                        column: x => x.GuestInfoId,
                        principalTable: "GuestInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostProdProcesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostProdProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostProdProcesses_ProcessStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ProcessStatuses",
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
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProposalId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleaseNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    PostProdProcessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_EpisodeStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "EpisodeStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Episodes_PostProdProcesses_PostProdProcessId",
                        column: x => x.PostProdProcessId,
                        principalTable: "PostProdProcesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProposalId = table.Column<int>(type: "int", nullable: false),
                    SufflereId = table.Column<int>(type: "int", nullable: false),
                    PostProdProcessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_PostProdProcesses_PostProdProcessId",
                        column: x => x.PostProdProcessId,
                        principalTable: "PostProdProcesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sessions_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Suffleres_SufflereId",
                        column: x => x.SufflereId,
                        principalTable: "Suffleres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "ProdProcesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    GuestInfoId = table.Column<int>(type: "int", nullable: false),
                    ProposalId = table.Column<int>(type: "int", nullable: true),
                    SufflereId = table.Column<int>(type: "int", nullable: true),
                    SessionId = table.Column<int>(type: "int", nullable: true),
                    SessionReportId = table.Column<int>(type: "int", nullable: true),
                    EpisodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdProcesses_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProdProcesses_GuestInfo_GuestInfoId",
                        column: x => x.GuestInfoId,
                        principalTable: "GuestInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdProcesses_ProcessStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ProcessStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdProcesses_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProdProcesses_SessionReports_SessionReportId",
                        column: x => x.SessionReportId,
                        principalTable: "SessionReports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProdProcesses_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProdProcesses_Suffleres_SufflereId",
                        column: x => x.SufflereId,
                        principalTable: "Suffleres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_PostProdProcessId",
                table: "Episodes",
                column: "PostProdProcessId",
                unique: true,
                filter: "[PostProdProcessId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_StatusId",
                table: "Episodes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PartialReports_SessionId",
                table: "PartialReports",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PartialReports_SessionReportId",
                table: "PartialReports",
                column: "SessionReportId");

            migrationBuilder.CreateIndex(
                name: "IX_PostProdProcesses_StatusId",
                table: "PostProdProcesses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProcesses_EpisodeId",
                table: "ProdProcesses",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProcesses_GuestInfoId",
                table: "ProdProcesses",
                column: "GuestInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProdProcesses_ProposalId",
                table: "ProdProcesses",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProcesses_SessionId",
                table: "ProdProcesses",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProcesses_SessionReportId",
                table: "ProdProcesses",
                column: "SessionReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProcesses_StatusId",
                table: "ProdProcesses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProcesses_SufflereId",
                table: "ProdProcesses",
                column: "SufflereId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_GuestId",
                table: "Proposals",
                column: "GuestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionReports_SessionId",
                table: "SessionReports",
                column: "SessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_PostProdProcessId",
                table: "Sessions",
                column: "PostProdProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ProposalId",
                table: "Sessions",
                column: "ProposalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SufflereId",
                table: "Sessions",
                column: "SufflereId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_GuestInfoId",
                table: "Subjects",
                column: "GuestInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Suffleres_ProposalId",
                table: "Suffleres",
                column: "ProposalId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartialReports");

            migrationBuilder.DropTable(
                name: "ProdProcesses");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "SessionReports");

            migrationBuilder.DropTable(
                name: "EpisodeStatus");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "PostProdProcesses");

            migrationBuilder.DropTable(
                name: "Suffleres");

            migrationBuilder.DropTable(
                name: "ProcessStatuses");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "GuestInfo");
        }
    }
}
