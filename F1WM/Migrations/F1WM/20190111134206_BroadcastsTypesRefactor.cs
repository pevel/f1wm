using Microsoft.EntityFrameworkCore.Migrations;

namespace F1WM.Migrations.F1WM
{
    public partial class BroadcastsTypesRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BroadcastedSessions_BroadcastedSessionTypes_TypeId",
                table: "BroadcastedSessions");

            migrationBuilder.DropIndex(
                name: "IX_BroadcastedSessions_TypeId",
                table: "BroadcastedSessions");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "BroadcastedSessions");

            migrationBuilder.RenameColumn(
                name: "BroadcastedSessionNameId",
                table: "BroadcastedSessions",
                newName: "BroadcastedSessionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BroadcastedSessions_BroadcastedSessionTypeId",
                table: "BroadcastedSessions",
                column: "BroadcastedSessionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BroadcastedSessions_BroadcastedSessionTypes_BroadcastedSessi~",
                table: "BroadcastedSessions",
                column: "BroadcastedSessionTypeId",
                principalTable: "BroadcastedSessionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BroadcastedSessions_BroadcastedSessionTypes_BroadcastedSessi~",
                table: "BroadcastedSessions");

            migrationBuilder.DropIndex(
                name: "IX_BroadcastedSessions_BroadcastedSessionTypeId",
                table: "BroadcastedSessions");

            migrationBuilder.RenameColumn(
                name: "BroadcastedSessionTypeId",
                table: "BroadcastedSessions",
                newName: "BroadcastedSessionNameId");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "BroadcastedSessions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BroadcastedSessions_TypeId",
                table: "BroadcastedSessions",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BroadcastedSessions_BroadcastedSessionTypes_TypeId",
                table: "BroadcastedSessions",
                column: "TypeId",
                principalTable: "BroadcastedSessionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
