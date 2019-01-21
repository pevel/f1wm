using Microsoft.EntityFrameworkCore.Migrations;

namespace F1WM.Migrations.F1WM
{
    public partial class NewsTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_f1_news_topicmatch_f1_news_news_id",
                table: "f1_news_topicmatch");

            migrationBuilder.DropForeignKey(
                name: "FK_f1_news_topicmatch_f1_news_topics_topic_id",
                table: "f1_news_topicmatch");
        }
    }
}
