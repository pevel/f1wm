using F1WM.DatabaseModel.Constants;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1WM.Migrations.F1WM
{
	public partial class RSS : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql($"INSERT INTO f1_config_sections(name) VALUES ('{ConfigSectionName.RSS}');");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql($"DELETE FROM f1_config_sections WHERE name = '{ConfigSectionName.RSS}';");
		}
	}
}
