using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1WM.Migrations.F1WM
{
	public partial class Broadcasts : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("ALTER TABLE `f1races` CHANGE `date` `date` DATE NOT NULL;");
			migrationBuilder.Sql("ALTER TABLE `f1races` ENGINE=InnoDB;");
			migrationBuilder.CreateTable(
				name: "BroadcastedSessions",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					Name = table.Column<string>(maxLength: 255, nullable: true),
					Start = table.Column<DateTime>(nullable: false),
					RaceId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BroadcastedSessions", x => x.Id);
					table.ForeignKey(
						name: "FK_BroadcastedSessions_f1races_RaceId",
						column: x => x.RaceId,
						principalTable: "f1races",
						principalColumn: "raceid",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Broadcasters",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					Url = table.Column<string>(maxLength: 255, nullable: true),
					Name = table.Column<string>(maxLength: 255, nullable: true),
					Icon = table.Column<string>(maxLength: 255, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Broadcasters", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Broadcasts",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					BroadcasterId = table.Column<int>(nullable: false),
					BroadcastedSessionId = table.Column<int>(nullable: false),
					Start = table.Column<DateTime>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Broadcasts", x => x.Id);
					table.ForeignKey(
						name: "FK_Broadcasts_BroadcastedSessions_BroadcastedSessionId",
						column: x => x.BroadcastedSessionId,
						principalTable: "BroadcastedSessions",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Broadcasts_Broadcasters_BroadcasterId",
						column: x => x.BroadcasterId,
						principalTable: "Broadcasters",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_BroadcastedSessions_RaceId",
				table: "BroadcastedSessions",
				column: "RaceId");

			migrationBuilder.CreateIndex(
				name: "IX_Broadcasts_BroadcastedSessionId",
				table: "Broadcasts",
				column: "BroadcastedSessionId");

			migrationBuilder.CreateIndex(
				name: "IX_Broadcasts_BroadcasterId",
				table: "Broadcasts",
				column: "BroadcasterId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Broadcasts");

			migrationBuilder.DropTable(
				name: "BroadcastedSessions");

			migrationBuilder.DropTable(
				name: "Broadcasters");
		}
	}
}
