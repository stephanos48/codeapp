using Microsoft.EntityFrameworkCore.Migrations;

namespace codeapp.API.Migrations
{
    public partial class changedaudit20190908 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Audits_AuditId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_AuditId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "AuditId",
                table: "Photos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuditId",
                table: "Photos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AuditId",
                table: "Photos",
                column: "AuditId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Audits_AuditId",
                table: "Photos",
                column: "AuditId",
                principalTable: "Audits",
                principalColumn: "AuditId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
