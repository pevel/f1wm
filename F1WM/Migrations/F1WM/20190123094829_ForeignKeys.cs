using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1WM.Migrations.F1WM
{
    public partial class ForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "thirddriver",
                table: "f1entries",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValueSql: "'0'");

            migrationBuilder.AlterColumn<int>(
                name: "comm_count",
                table: "f1_news",
                nullable: false,
                defaultValueSql: "'0'",
                oldClrType: typeof(ushort),
                oldDefaultValueSql: "'0'");

            migrationBuilder.AddForeignKey(
                name: "FK_f1_news_topicmatch_f1_news_news_id",
                table: "f1_news_topicmatch",
                column: "news_id",
                principalTable: "f1_news",
                principalColumn: "news_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_f1_news_topicmatch_f1_news_topics_topic_id",
                table: "f1_news_topicmatch",
                column: "topic_id",
                principalTable: "f1_news_topics",
                principalColumn: "topic_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_f1entries_f1engines_engineid",
                table: "f1entries",
                column: "engineid",
                principalTable: "f1engines",
                principalColumn: "engineid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_f1entries_f1teams_teamid",
                table: "f1entries",
                column: "teamid",
                principalTable: "f1teams",
                principalColumn: "teamid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_f1_news_topicmatch_f1_news_news_id",
                table: "f1_news_topicmatch");

            migrationBuilder.DropForeignKey(
                name: "FK_f1_news_topicmatch_f1_news_topics_topic_id",
                table: "f1_news_topicmatch");

            migrationBuilder.DropForeignKey(
                name: "FK_f1entries_f1engines_engineid",
                table: "f1entries");

            migrationBuilder.DropForeignKey(
                name: "FK_f1entries_f1teams_teamid",
                table: "f1entries");

            migrationBuilder.AlterColumn<bool>(
                name: "thirddriver",
                table: "f1entries",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<ushort>(
                name: "comm_count",
                table: "f1_news",
                nullable: false,
                defaultValueSql: "'0'",
                oldClrType: typeof(int),
                oldDefaultValueSql: "'0'");
        }
    }
}
