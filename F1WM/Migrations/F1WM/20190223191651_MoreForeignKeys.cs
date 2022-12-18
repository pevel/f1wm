using Microsoft.EntityFrameworkCore.Migrations;

namespace F1WM.Migrations.F1WM
{
	public partial class MoreForeignKeys : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "teamascid",
				table: "f1drivers",
				type: "char(3)",
				nullable: true,
				defaultValueSql: "''",
				oldClrType: typeof(string),
				oldType: "char(3)",
				oldDefaultValueSql: "''");

			migrationBuilder.Sql("UPDATE `f1drivers` d SET d.teamascid = NULL WHERE d.teamascid = ''");

			migrationBuilder.AlterColumn<int>(
				name: "newsid",
				table: "f1_arts",
				type: "mediumint unsigned",
				nullable: true,
				defaultValueSql: "'0'",
				oldClrType: typeof(int),
				oldType: "mediumint unsigned",
				oldDefaultValueSql: "'0'");

			migrationBuilder.Sql("UPDATE `f1_arts` a SET a.newsid = NULL WHERE a.newsid = 0");

			migrationBuilder.AddUniqueConstraint(
				name: "AK_f1teams_ascid",
				table: "f1teams",
				column: "ascid");

			migrationBuilder.CreateIndex(
				name: "IX_f1teams_nat",
				table: "f1teams",
				column: "nat");

			migrationBuilder.CreateIndex(
				name: "IX_f1entries_teamnameid",
				table: "f1entries",
				column: "teamnameid");

			migrationBuilder.CreateIndex(
				name: "IX_f1enginemakes_nat",
				table: "f1enginemakes",
				column: "nat");

			migrationBuilder.CreateIndex(
				name: "IX_f1driverpoints_driverid_raceid",
				table: "f1driverpoints",
				columns: new[] { "driverid", "raceid" },
				unique: true);

			migrationBuilder.AddForeignKey(
				name: "FK_f1_arts_f1_news_newsid",
				table: "f1_arts",
				column: "newsid",
				principalTable: "f1_news",
				principalColumn: "news_id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_f1driverpoints_f1drivers_driverid",
				table: "f1driverpoints",
				column: "driverid",
				principalTable: "f1drivers",
				principalColumn: "driverid",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_f1driverpoints_f1races_raceid",
				table: "f1driverpoints",
				column: "raceid",
				principalTable: "f1races",
				principalColumn: "raceid",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_f1driverpoints_f1seasons_seasonid",
				table: "f1driverpoints",
				column: "seasonid",
				principalTable: "f1seasons",
				principalColumn: "seasonid",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_f1drivers_f1teams_teamascid",
				table: "f1drivers",
				column: "teamascid",
				principalTable: "f1teams",
				principalColumn: "ascid",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_f1enginemakes_f1nations_nat",
				table: "f1enginemakes",
				column: "nat",
				principalTable: "f1nations",
				principalColumn: "ascid",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_f1engines_f1enginemakes_enginemakeid",
				table: "f1engines",
				column: "enginemakeid",
				principalTable: "f1enginemakes",
				principalColumn: "enginemakeid",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_f1enginesspecs_f1engines_engineid",
				table: "f1enginesspecs",
				column: "engineid",
				principalTable: "f1engines",
				principalColumn: "engineid",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_f1entries_f1teamnames_teamnameid",
				table: "f1entries",
				column: "teamnameid",
				principalTable: "f1teamnames",
				principalColumn: "teamnameid",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_f1races_f1seasons_seasonid",
				table: "f1races",
				column: "seasonid",
				principalTable: "f1seasons",
				principalColumn: "seasonid",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_f1teams_f1nations_nat",
				table: "f1teams",
				column: "nat",
				principalTable: "f1nations",
				principalColumn: "ascid",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_f1_arts_f1_news_newsid",
				table: "f1_arts");

			migrationBuilder.DropForeignKey(
				name: "FK_f1driverpoints_f1drivers_driverid",
				table: "f1driverpoints");

			migrationBuilder.DropForeignKey(
				name: "FK_f1driverpoints_f1races_raceid",
				table: "f1driverpoints");

			migrationBuilder.DropForeignKey(
				name: "FK_f1driverpoints_f1seasons_seasonid",
				table: "f1driverpoints");

			migrationBuilder.DropForeignKey(
				name: "FK_f1drivers_f1teams_teamascid",
				table: "f1drivers");

			migrationBuilder.DropForeignKey(
				name: "FK_f1enginemakes_f1nations_nat",
				table: "f1enginemakes");

			migrationBuilder.DropForeignKey(
				name: "FK_f1engines_f1enginemakes_enginemakeid",
				table: "f1engines");

			migrationBuilder.DropForeignKey(
				name: "FK_f1enginesspecs_f1engines_engineid",
				table: "f1enginesspecs");

			migrationBuilder.DropForeignKey(
				name: "FK_f1entries_f1teamnames_teamnameid",
				table: "f1entries");

			migrationBuilder.DropForeignKey(
				name: "FK_f1races_f1seasons_seasonid",
				table: "f1races");

			migrationBuilder.DropForeignKey(
				name: "FK_f1teams_f1nations_nat",
				table: "f1teams");

			migrationBuilder.DropUniqueConstraint(
				name: "AK_f1teams_ascid",
				table: "f1teams");

			migrationBuilder.DropIndex(
				name: "IX_f1teams_nat",
				table: "f1teams");

			migrationBuilder.DropIndex(
				name: "IX_f1entries_teamnameid",
				table: "f1entries");

			migrationBuilder.DropIndex(
				name: "IX_f1enginemakes_nat",
				table: "f1enginemakes");

			migrationBuilder.DropIndex(
				name: "IX_f1driverpoints_driverid_raceid",
				table: "f1driverpoints");

			migrationBuilder.Sql("UPDATE `f1drivers` d SET d.teamascid = '' WHERE d.teamascid IS NULL");

			migrationBuilder.AlterColumn<string>(
				name: "teamascid",
				table: "f1drivers",
				type: "char(3)",
				nullable: false,
				defaultValueSql: "''",
				oldClrType: typeof(string),
				oldType: "char(3)",
				oldNullable: true,
				oldDefaultValueSql: "''");

			migrationBuilder.Sql("UPDATE `f1_arts` a SET a.newsid = 0 WHERE a.newsid IS NULL");

			migrationBuilder.AlterColumn<int>(
				name: "newsid",
				table: "f1_arts",
				type: "mediumint unsigned",
				nullable: false,
				defaultValueSql: "'0'",
				oldClrType: typeof(int),
				oldType: "mediumint unsigned",
				oldNullable: true,
				oldDefaultValueSql: "'0'");
		}
	}
}
