using Microsoft.EntityFrameworkCore.Migrations;

namespace F1WM.Migrations.F1WM
{
	public partial class DbEngineMigration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("ALTER TABLE `inne_zasady` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `inne_terminy` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `inne_serie` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `inne_rezultaty_bk` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `inne_rezultaty` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `inne_listystart` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `inne_klaskier` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `inne_kierowcy` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `inne_imprezy` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `inne_dodpktza` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `gpm_zwyciezcy` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `gpm_zespoly` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `gpm_sklady` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `gpm_ligi_koms` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `gpm_ligi` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `gpm_klaswszech` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `gpm_klastyp` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `gpm_klasgenpoz` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `gpm_klasgen` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `gpm_admwyscigi` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `gpm_admskladniki` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `gpm_admkonfig` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_zgloszone_bledy` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_texts` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_subskr` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_rezerwacje` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_redakcja` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_news_types` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_news_topics` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_news_topicmatch` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_news_comstext` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_news_coms` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_news_cats` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_newseditordata` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_newseditorcats` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_news` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_log_zmian` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_linki` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_ligna` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_hideusercoms` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_config_varchar` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_config_text` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_config_sections` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_arts_cats` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1_arts` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1tyres` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1tracks` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1teams` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1teamnames` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1seasons` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1results` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1quotes` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1quals` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1othersessions` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1newsgp` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1nations` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1lapsled` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1grids` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1glossary` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1fastestlaps` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1entries` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1enginesspecs` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1engines` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1enginemakes` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1driversid3` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1drivers` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1driverpoints` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1drivercs` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1constrpoints` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1constrcs` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1carsspecs` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1cars` ENGINE=InnoDB;");
			migrationBuilder.Sql("ALTER TABLE `f1carmakes` ENGINE=InnoDB;");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
