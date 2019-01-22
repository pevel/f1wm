using Microsoft.EntityFrameworkCore.Migrations;

namespace F1WM.Migrations.F1WM
{
    public partial class IndexesForSorting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_f1results_time",
                table: "f1results",
                column: "time");

            migrationBuilder.CreateIndex(
                name: "IX_f1races_date",
                table: "f1races",
                column: "date");

            migrationBuilder.CreateIndex(
                name: "IX_f1grids_time",
                table: "f1grids",
                column: "time");

            migrationBuilder.CreateIndex(
                name: "IX_f1fastestlaps_time",
                table: "f1fastestlaps",
                column: "time");

            migrationBuilder.CreateIndex(
                name: "IX_f1drivercs_cspos",
                table: "f1drivercs",
                column: "cspos");

            migrationBuilder.CreateIndex(
                name: "IX_f1constrcs_cspos",
                table: "f1constrcs",
                column: "cspos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_f1results_time",
                table: "f1results");

            migrationBuilder.DropIndex(
                name: "IX_f1races_date",
                table: "f1races");

            migrationBuilder.DropIndex(
                name: "IX_f1grids_time",
                table: "f1grids");

            migrationBuilder.DropIndex(
                name: "IX_f1fastestlaps_time",
                table: "f1fastestlaps");

            migrationBuilder.DropIndex(
                name: "IX_f1drivercs_cspos",
                table: "f1drivercs");

            migrationBuilder.DropIndex(
                name: "IX_f1constrcs_cspos",
                table: "f1constrcs");
        }
    }
}
