using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace codeapp.API.Migrations
{
    public partial class addauditfindings20190902 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditTypes",
                columns: table => new
                {
                    AuditTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTypes", x => x.AuditTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FindingTypes",
                columns: table => new
                {
                    FindingTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FindingTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FindingTypes", x => x.FindingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    AuditId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditNo = table.Column<string>(nullable: true),
                    AuditTypeId = table.Column<int>(nullable: false),
                    AuditName = table.Column<string>(nullable: true),
                    AuditScope = table.Column<string>(nullable: true),
                    PlannedAuditStartDate = table.Column<DateTime>(nullable: false),
                    PlannedAuditEndDate = table.Column<DateTime>(nullable: false),
                    ActualAuditStartDate = table.Column<DateTime>(nullable: false),
                    ActualAuditEndDate = table.Column<DateTime>(nullable: false),
                    Auditors = table.Column<string>(nullable: true),
                    AuditReason = table.Column<string>(nullable: true),
                    AuditSummary = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.AuditId);
                    table.ForeignKey(
                        name: "FK_Audits_AuditTypes_AuditTypeId",
                        column: x => x.AuditTypeId,
                        principalTable: "AuditTypes",
                        principalColumn: "AuditTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Findings",
                columns: table => new
                {
                    FindingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsoClauseProcess = table.Column<string>(nullable: true),
                    FindingTypeId = table.Column<int>(nullable: false),
                    FindingDetails = table.Column<string>(nullable: true),
                    Auditor = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    AuditId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Findings", x => x.FindingId);
                    table.ForeignKey(
                        name: "FK_Findings_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "AuditId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Findings_FindingTypes_FindingTypeId",
                        column: x => x.FindingTypeId,
                        principalTable: "FindingTypes",
                        principalColumn: "FindingTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audits_AuditTypeId",
                table: "Audits",
                column: "AuditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_AuditId",
                table: "Findings",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_FindingTypeId",
                table: "Findings",
                column: "FindingTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Findings");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "FindingTypes");

            migrationBuilder.DropTable(
                name: "AuditTypes");
        }
    }
}
