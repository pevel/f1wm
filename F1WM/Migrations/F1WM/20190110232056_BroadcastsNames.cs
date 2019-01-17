using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1WM.Migrations.F1WM
{
    public partial class BroadcastsNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "BroadcastedSessions");

            migrationBuilder.AddColumn<int>(
                name: "BroadcastedSessionNameId",
                table: "BroadcastedSessions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BroadcastedSessionNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BroadcastedSessionNames", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BroadcastedSessions_BroadcastedSessionNameId",
                table: "BroadcastedSessions",
                column: "BroadcastedSessionNameId");

            migrationBuilder.CreateIndex(
                name: "IX_BroadcastedSessionNames_Name",
                table: "BroadcastedSessionNames",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BroadcastedSessions_BroadcastedSessionNames_BroadcastedSessi~",
                table: "BroadcastedSessions",
                column: "BroadcastedSessionNameId",
                principalTable: "BroadcastedSessionNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BroadcastedSessions_BroadcastedSessionNames_BroadcastedSessi~",
                table: "BroadcastedSessions");

            migrationBuilder.DropTable(
                name: "BroadcastedSessionNames");

            migrationBuilder.DropIndex(
                name: "IX_BroadcastedSessions_BroadcastedSessionNameId",
                table: "BroadcastedSessions");

            migrationBuilder.DropColumn(
                name: "BroadcastedSessionNameId",
                table: "BroadcastedSessions");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BroadcastedSessions",
                maxLength: 255,
                nullable: true);
        }
    }
}
