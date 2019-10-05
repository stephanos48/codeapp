using Microsoft.EntityFrameworkCore.Migrations;

namespace codeapp.API.Migrations
{
    public partial class addscrumstatusrev120190929 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scrums_ScrumStatuses_ScrumStatusId",
                table: "Scrums");

            migrationBuilder.DropIndex(
                name: "IX_Scrums_ScrumStatusId",
                table: "Scrums");

            migrationBuilder.DropColumn(
                name: "ScrumStatausId",
                table: "Scrums");

            migrationBuilder.DropColumn(
                name: "ScrumStatusId",
                table: "Scrums");

            migrationBuilder.AddColumn<string>(
                name: "ClosedStatus",
                table: "Scrums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScrumStatus",
                table: "Scrums",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosedStatus",
                table: "Scrums");

            migrationBuilder.DropColumn(
                name: "ScrumStatus",
                table: "Scrums");

            migrationBuilder.AddColumn<int>(
                name: "ScrumStatausId",
                table: "Scrums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScrumStatusId",
                table: "Scrums",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scrums_ScrumStatusId",
                table: "Scrums",
                column: "ScrumStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scrums_ScrumStatuses_ScrumStatusId",
                table: "Scrums",
                column: "ScrumStatusId",
                principalTable: "ScrumStatuses",
                principalColumn: "ScrumStatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
