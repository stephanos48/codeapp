using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace codeapp.API.Migrations
{
    public partial class addauditphoto2090904 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuditId",
                table: "Photos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PhotoAudits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    PublicId = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    AuditId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoAudits_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "AuditId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AuditId",
                table: "Photos",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoAudits_AuditId",
                table: "PhotoAudits",
                column: "AuditId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Audits_AuditId",
                table: "Photos",
                column: "AuditId",
                principalTable: "Audits",
                principalColumn: "AuditId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Audits_AuditId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "PhotoAudits");

            migrationBuilder.DropIndex(
                name: "IX_Photos_AuditId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "AuditId",
                table: "Photos");
        }
    }
}
