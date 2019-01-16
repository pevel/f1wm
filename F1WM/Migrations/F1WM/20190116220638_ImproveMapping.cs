using Microsoft.EntityFrameworkCore.Migrations;

namespace F1WM.Migrations.F1WM
{
    public partial class ImproveMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "raceid",
                table: "f1fastestlaps");

            migrationBuilder.CreateIndex(
                name: "IX_inne_imprezy_kraj",
                table: "inne_imprezy",
                column: "kraj");

            migrationBuilder.CreateIndex(
                name: "IX_f1tyres_nat",
                table: "f1tyres",
                column: "nat");

            migrationBuilder.CreateIndex(
                name: "IX_f1tracks_country",
                table: "f1tracks",
                column: "country");

            migrationBuilder.CreateIndex(
                name: "raceid",
                table: "f1fastestlaps",
                column: "raceid");

            migrationBuilder.AddForeignKey(
                name: "FK_f1cars_f1carmakes_carmakeid",
                table: "f1cars",
                column: "carmakeid",
                principalTable: "f1carmakes",
                principalColumn: "carmakeid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_f1constrcs_f1seasons_seasonid",
                table: "f1constrcs",
                column: "seasonid",
                principalTable: "f1seasons",
                principalColumn: "seasonid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_f1drivercs_f1seasons_seasonid",
                table: "f1drivercs",
                column: "seasonid",
                principalTable: "f1seasons",
                principalColumn: "seasonid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_f1othersessions_f1races_raceid",
                table: "f1othersessions",
                column: "raceid",
                principalTable: "f1races",
                principalColumn: "raceid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_f1tracks_f1nations_country",
                table: "f1tracks",
                column: "country",
                principalTable: "f1nations",
                principalColumn: "ascid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_f1tyres_f1nations_nat",
                table: "f1tyres",
                column: "nat",
                principalTable: "f1nations",
                principalColumn: "ascid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inne_imprezy_f1nations_kraj",
                table: "inne_imprezy",
                column: "kraj",
                principalTable: "f1nations",
                principalColumn: "ascid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inne_imprezy_inne_serie_seriaid",
                table: "inne_imprezy",
                column: "seriaid",
                principalTable: "inne_serie",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_f1cars_f1carmakes_carmakeid",
                table: "f1cars");

            migrationBuilder.DropForeignKey(
                name: "FK_f1constrcs_f1seasons_seasonid",
                table: "f1constrcs");

            migrationBuilder.DropForeignKey(
                name: "FK_f1drivercs_f1seasons_seasonid",
                table: "f1drivercs");

            migrationBuilder.DropForeignKey(
                name: "FK_f1othersessions_f1races_raceid",
                table: "f1othersessions");

            migrationBuilder.DropForeignKey(
                name: "FK_f1tracks_f1nations_country",
                table: "f1tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_f1tyres_f1nations_nat",
                table: "f1tyres");

            migrationBuilder.DropForeignKey(
                name: "FK_inne_imprezy_f1nations_kraj",
                table: "inne_imprezy");

            migrationBuilder.DropForeignKey(
                name: "FK_inne_imprezy_inne_serie_seriaid",
                table: "inne_imprezy");

            migrationBuilder.DropIndex(
                name: "IX_inne_imprezy_kraj",
                table: "inne_imprezy");

            migrationBuilder.DropIndex(
                name: "IX_f1tyres_nat",
                table: "f1tyres");

            migrationBuilder.DropIndex(
                name: "IX_f1tracks_country",
                table: "f1tracks");

            migrationBuilder.DropIndex(
                name: "raceid",
                table: "f1fastestlaps");

            migrationBuilder.CreateIndex(
                name: "raceid",
                table: "f1fastestlaps",
                column: "raceid",
                unique: true);
        }
    }
}
