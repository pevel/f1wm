using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1WM.Migrations.F1WM
{
    public partial class BroadcastsTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BroadcastedSessions_BroadcastedSessionNames_BroadcastedSessi~",
                table: "BroadcastedSessions");

            migrationBuilder.DropTable(
                name: "BroadcastedSessionNames");

            migrationBuilder.DropIndex(
                name: "IX_BroadcastedSessions_BroadcastedSessionNameId",
                table: "BroadcastedSessions");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "BroadcastedSessions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BroadcastedSessionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BroadcastedSessionTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BroadcastedSessions_TypeId",
                table: "BroadcastedSessions",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BroadcastedSessionTypes_Name",
                table: "BroadcastedSessionTypes",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BroadcastedSessions_BroadcastedSessionTypes_TypeId",
                table: "BroadcastedSessions",
                column: "TypeId",
                principalTable: "BroadcastedSessionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BroadcastedSessions_BroadcastedSessionTypes_TypeId",
                table: "BroadcastedSessions");

            migrationBuilder.DropTable(
                name: "BroadcastedSessionTypes");

            migrationBuilder.DropIndex(
                name: "IX_BroadcastedSessions_TypeId",
                table: "BroadcastedSessions");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "BroadcastedSessions");

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
    }
}
