using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace codeapp.API.Migrations
{
    public partial class addscrumstatus20190929 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScrumStatausId",
                table: "Scrums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScrumStatusId",
                table: "Scrums",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ScrumStatuses",
                columns: table => new
                {
                    ScrumStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScrumStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrumStatuses", x => x.ScrumStatusId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scrums_ScrumStatuses_ScrumStatusId",
                table: "Scrums");

            migrationBuilder.DropTable(
                name: "ScrumStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Scrums_ScrumStatusId",
                table: "Scrums");

            migrationBuilder.DropColumn(
                name: "ScrumStatausId",
                table: "Scrums");

            migrationBuilder.DropColumn(
                name: "ScrumStatusId",
                table: "Scrums");
        }
    }
}
