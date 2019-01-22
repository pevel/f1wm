using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace F1WM.DatabaseModel
{
	public class F1WMContext : DbContext
	{
		public virtual DbSet<Broadcast> Broadcasts { get; set; }
		public virtual DbSet<Broadcaster> Broadcasters { get; set; }
		public virtual DbSet<BroadcastedSession> BroadcastedSessions { get; set; }
		public virtual DbSet<BroadcastedSessionType> BroadcastedSessionTypes { get; set; }
		public virtual DbSet<F1Arts> F1Arts { get; set; }
		public virtual DbSet<F1ArtsCats> F1ArtsCats { get; set; }
		public virtual DbSet<Constructor> Constructors { get; set; }
		public virtual DbSet<Car> Cars { get; set; }
		public virtual DbSet<F1carsspecs> F1carsspecs { get; set; }
		public virtual DbSet<F1ConfigSections> F1ConfigSections { get; set; }
		public virtual DbSet<ConfigText> ConfigTexts { get; set; }
		public virtual DbSet<F1ConfigVarchar> F1ConfigVarchar { get; set; }
		public virtual DbSet<ConstructorStandingsPosition> ConstructorStandingsPositions { get; set; }
		public virtual DbSet<F1constrcsLastpos> F1constrcsLastpos { get; set; }
		public virtual DbSet<F1constrpoints> F1constrpoints { get; set; }
		public virtual DbSet<DriverStandingsPosition> DriverStandingsPositions { get; set; }
		public virtual DbSet<F1drivercsLastpos> F1drivercsLastpos { get; set; }
		public virtual DbSet<F1driverpoints> F1driverpoints { get; set; }
		public virtual DbSet<Driver> Drivers { get; set; }
		public virtual DbSet<F1driversid3> F1driversid3 { get; set; }
		public virtual DbSet<F1enginemakes> F1enginemakes { get; set; }
		public virtual DbSet<Engine> Engines { get; set; }
		public virtual DbSet<F1enginesspecs> F1enginesspecs { get; set; }
		public virtual DbSet<Entry> Entries { get; set; }
		public virtual DbSet<FastestLap> FastestLaps { get; set; }
		public virtual DbSet<F1glossary> F1glossary { get; set; }
		public virtual DbSet<Grid> Grids { get; set; }
		public virtual DbSet<F1Hideusercoms> F1Hideusercoms { get; set; }
		public virtual DbSet<F1lapsled> F1lapsled { get; set; }
		public virtual DbSet<F1Ligna> F1Ligna { get; set; }
		public virtual DbSet<F1Linki> F1Linki { get; set; }
		public virtual DbSet<F1LogZmian> F1LogZmian { get; set; }
		public virtual DbSet<Country> Countries { get; set; }
		public virtual DbSet<News> News { get; set; }
		public virtual DbSet<NewsTagCategory> NewsCategories { get; set; }
		public virtual DbSet<NewsComment> NewsComments { get; set; }
		public virtual DbSet<NewsCommentText> NewsCommentTexts { get; set; }
		public virtual DbSet<F1Newseditorcats> F1Newseditorcats { get; set; }
		public virtual DbSet<F1Newseditordata> F1Newseditordata { get; set; }
		public virtual DbSet<RaceNews> RaceNews { get; set; }
		public virtual DbSet<NewsTagMatch> NewsTagMatches { get; set; }
		public virtual DbSet<NewsTag> NewsTags { get; set; }
		public virtual DbSet<NewsType> NewsTypes { get; set; }
		public virtual DbSet<OtherSession> OtherSessions { get; set; }
		public virtual DbSet<Qualifying> Qualifying { get; set; }
		public virtual DbSet<F1quotes> F1quotes { get; set; }
		public virtual DbSet<Race> Races { get; set; }
		public virtual DbSet<F1Redakcja> F1Redakcja { get; set; }
		public virtual DbSet<Result> Results { get; set; }
		public virtual DbSet<F1Rezerwacje> F1Rezerwacje { get; set; }
		public virtual DbSet<Season> Seasons { get; set; }
		public virtual DbSet<F1Subskr> F1Subskr { get; set; }
		public virtual DbSet<F1teamnames> F1teamnames { get; set; }
		public virtual DbSet<Team> Teams { get; set; }
		public virtual DbSet<F1Texts> F1Texts { get; set; }
		public virtual DbSet<Track> Tracks { get; set; }
		public virtual DbSet<Tyres> Tyres { get; set; }
		public virtual DbSet<F1ZgloszoneBledy> F1ZgloszoneBledy { get; set; }
		public virtual DbSet<GpmAdmkonfig> GpmAdmkonfig { get; set; }
		public virtual DbSet<GpmAdmskladniki> GpmAdmskladniki { get; set; }
		public virtual DbSet<GpmAdmwyscigi> GpmAdmwyscigi { get; set; }
		public virtual DbSet<GpmKlasgen> GpmKlasgen { get; set; }
		public virtual DbSet<GpmKlasgenpoz> GpmKlasgenpoz { get; set; }
		public virtual DbSet<GpmKlastyp> GpmKlastyp { get; set; }
		public virtual DbSet<GpmKlaswszech> GpmKlaswszech { get; set; }
		public virtual DbSet<GpmLigi> GpmLigi { get; set; }
		public virtual DbSet<GpmLigiKoms> GpmLigiKoms { get; set; }
		public virtual DbSet<GpmSklady> GpmSklady { get; set; }
		public virtual DbSet<GpmZespoly> GpmZespoly { get; set; }
		public virtual DbSet<GpmZwyciezcy> GpmZwyciezcy { get; set; }
		public virtual DbSet<OtherAdditionalPointsReason> OtherAdditionalPointsReasons { get; set; }
		public virtual DbSet<Event> Events { get; set; }
		public virtual DbSet<OtherDriver> OtherDrivers { get; set; }
		public virtual DbSet<InneKlaskier> InneKlaskier { get; set; }
		public virtual DbSet<OtherEntry> OtherEntries { get; set; }
		public virtual DbSet<OtherResult> OtherResults { get; set; }
		public virtual DbSet<InneRezultatyBk> InneRezultatyBk { get; set; }
		public virtual DbSet<OtherSeries> OtherSeries { get; set; }
		public virtual DbSet<InneTerminy> InneTerminy { get; set; }
		public virtual DbSet<InneZasady> InneZasady { get; set; }
		public virtual DbSet<StatLog> StatLog { get; set; }
		public virtual DbSet<StatRef> StatRef { get; set; }
		public virtual DbSet<StatRefdom> StatRefdom { get; set; }
		public virtual DbSet<StatSesje> StatSesje { get; set; }
		public virtual DbSet<StatStrony> StatStrony { get; set; }
		public virtual DbSet<SympollAuth> SympollAuth { get; set; }
		public virtual DbSet<SympollList> SympollList { get; set; }

		public F1WMContext(DbContextOptions<F1WMContext> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(F1WMContext)));

			modelBuilder.Entity<F1Arts>(entity =>
			{
				entity.HasKey(e => e.Artid);

				entity.ToTable("f1_arts");

				entity.HasIndex(e => e.Arttitle)
					.HasName("arttitle");

				entity.HasIndex(e => e.Catid)
					.HasName("catid");

				entity.Property(e => e.Artid)
					.HasColumnName("artid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Arthidden)
					.HasColumnName("arthidden")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Artposter)
					.IsRequired()
					.HasColumnName("artposter")
					.HasMaxLength(64);

				entity.Property(e => e.Artpreview)
					.HasColumnName("artpreview")
					.HasMaxLength(255);

				entity.Property(e => e.Arttext)
					.HasColumnName("arttext")
					.HasColumnType("text");

				entity.Property(e => e.Arttitle)
					.IsRequired()
					.HasColumnName("arttitle")
					.HasMaxLength(80);

				entity.Property(e => e.Artviews)
					.HasColumnName("artviews")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Catid)
					.HasColumnName("catid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Newsid)
					.HasColumnName("newsid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<F1ArtsCats>(entity =>
			{
				entity.HasKey(e => e.Catid);

				entity.ToTable("f1_arts_cats");

				entity.HasIndex(e => e.Lastartid)
					.HasName("lastartid");

				entity.HasIndex(e => e.Ord)
					.HasName("ord");

				entity.Property(e => e.Catid)
					.HasColumnName("catid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Arts)
					.HasColumnName("arts")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Lastartid)
					.HasColumnName("lastartid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasColumnName("name")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Ord)
					.HasColumnName("ord")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<F1carsspecs>(entity =>
			{
				entity.HasKey(e => e.Carid);

				entity.ToTable("f1carsspecs");

				entity.Property(e => e.Carid)
					.HasColumnName("carid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Carspecs)
					.HasColumnName("carspecs")
					.HasColumnType("text");
			});

			modelBuilder.Entity<F1ConfigSections>(entity =>
			{
				entity.ToTable("f1_config_sections");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Name)
					.IsRequired()
					.HasColumnName("name")
					.HasMaxLength(45);
			});

			modelBuilder.Entity<F1ConfigVarchar>(entity =>
			{
				entity.ToTable("f1_config_varchar");

				entity.HasIndex(e => e.Name)
					.HasName("name");

				entity.HasIndex(e => e.Section)
					.HasName("section");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Description)
					.IsRequired()
					.HasColumnName("description")
					.HasColumnType("text");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasColumnName("name")
					.HasMaxLength(45);

				entity.Property(e => e.Section)
					.HasColumnName("section")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Type)
					.HasColumnName("type")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Value)
					.IsRequired()
					.HasColumnName("value")
					.HasMaxLength(255);
			});

			modelBuilder.Entity<F1constrcsLastpos>(entity =>
			{
				entity.ToTable("f1constrcs_lastpos");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("int(11)");

				entity.Property(e => e.Carmakeid)
					.HasColumnName("carmakeid")
					.HasColumnType("int(11)");

				entity.Property(e => e.Cspos)
					.HasColumnName("cspos")
					.HasColumnType("int(11)");

				entity.Property(e => e.Raceid)
					.HasColumnName("raceid")
					.HasColumnType("int(11)");

				entity.Property(e => e.Seasonid)
					.HasColumnName("seasonid")
					.HasColumnType("int(11)");
			});

			modelBuilder.Entity<F1constrpoints>(entity =>
			{
				entity.ToTable("f1constrpoints");

				entity.HasIndex(e => e.Carmakeid)
					.HasName("carmakeid");

				entity.HasIndex(e => e.Enginemakeid)
					.HasName("enginemakeid");

				entity.HasIndex(e => e.Raceid)
					.HasName("raceid");

				entity.HasIndex(e => e.Seasonid)
					.HasName("seasonid");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Carmakeid)
					.HasColumnName("carmakeid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Enginemakeid)
					.HasColumnName("enginemakeid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Raceid)
					.HasColumnName("raceid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Seasonid)
					.HasColumnName("seasonid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<F1drivercsLastpos>(entity =>
			{
				entity.ToTable("f1drivercs_lastpos");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("int(11)");

				entity.Property(e => e.Cspos)
					.HasColumnName("cspos")
					.HasColumnType("int(11)");

				entity.Property(e => e.Driverid)
					.HasColumnName("driverid")
					.HasColumnType("int(11)");

				entity.Property(e => e.Raceid)
					.HasColumnName("raceid")
					.HasColumnType("int(11)");

				entity.Property(e => e.Seasonid)
					.HasColumnName("seasonid")
					.HasColumnType("int(11)");
			});

			modelBuilder.Entity<F1driverpoints>(entity =>
			{
				entity.ToTable("f1driverpoints");

				entity.HasIndex(e => e.Driverid)
					.HasName("driverid");

				entity.HasIndex(e => e.Raceid)
					.HasName("raceid");

				entity.HasIndex(e => e.Seasonid)
					.HasName("seasonid");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Driverid)
					.HasColumnName("driverid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Raceid)
					.HasColumnName("raceid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Seasonid)
					.HasColumnName("seasonid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<F1driversid3>(entity =>
			{
				entity.HasKey(e => e.Id3);

				entity.ToTable("f1driversid3");

				entity.Property(e => e.Id3)
					.HasColumnName("id3")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Id4)
					.IsRequired()
					.HasColumnName("id4")
					.HasColumnType("char(4)")
					.HasDefaultValueSql("''");
			});

			modelBuilder.Entity<F1enginemakes>(entity =>
			{
				entity.HasKey(e => e.Enginemakeid);

				entity.ToTable("f1enginemakes");

				entity.HasIndex(e => e.Ascid)
					.HasName("ascid")
					.IsUnique();

				entity.HasIndex(e => e.Enginemake)
					.HasName("enginemake");

				entity.HasIndex(e => e.Litera)
					.HasName("litera");

				entity.HasIndex(e => e.Status)
					.HasName("status");

				entity.Property(e => e.Enginemakeid)
					.HasColumnName("enginemakeid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Ascid)
					.IsRequired()
					.HasColumnName("ascid")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Enginemake)
					.IsRequired()
					.HasColumnName("enginemake")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Litera)
					.IsRequired()
					.HasColumnName("litera")
					.HasColumnType("char(1)");

				entity.Property(e => e.Nat)
					.IsRequired()
					.HasColumnName("nat")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Status)
					.HasColumnName("status")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<F1enginesspecs>(entity =>
			{
				entity.HasKey(e => e.Engineid);

				entity.ToTable("f1enginesspecs");

				entity.Property(e => e.Engineid)
					.HasColumnName("engineid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Enginespecs)
					.HasColumnName("enginespecs")
					.HasColumnType("text");
			});

			modelBuilder.Entity<F1glossary>(entity =>
			{
				entity.ToTable("f1glossary");

				entity.HasIndex(e => e.Nameen)
					.HasName("nameen");

				entity.HasIndex(e => e.Namepl)
					.HasName("namepl");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Descr)
					.IsRequired()
					.HasColumnName("descr")
					.HasColumnType("text");

				entity.Property(e => e.Extlink)
					.IsRequired()
					.HasColumnName("extlink")
					.HasMaxLength(255);

				entity.Property(e => e.Nameen)
					.IsRequired()
					.HasColumnName("nameen")
					.HasMaxLength(45);

				entity.Property(e => e.Namepl)
					.IsRequired()
					.HasColumnName("namepl")
					.HasMaxLength(64);
			});

			modelBuilder.Entity<F1Hideusercoms>(entity =>
			{
				entity.ToTable("f1_hideusercoms");

				entity.HasIndex(e => e.Userid)
					.HasName("userid");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Hideuserid)
					.HasColumnName("hideuserid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Userid)
					.HasColumnName("userid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<F1lapsled>(entity =>
			{
				entity.HasKey(e => e.Entryid);

				entity.ToTable("f1lapsled");

				entity.HasIndex(e => e.Raceid)
					.HasName("raceid");

				entity.Property(e => e.Entryid)
					.HasColumnName("entryid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Lapsled)
					.HasColumnName("lapsled")
					.HasColumnType("smallint(3)")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Raceid)
					.HasColumnName("raceid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<F1Ligna>(entity =>
			{
				entity.HasKey(e => e.LUid);

				entity.ToTable("f1_ligna");

				entity.HasIndex(e => e.LId)
					.HasName("l_id");

				entity.HasIndex(e => e.LSezon)
					.HasName("l_sezon");

				entity.Property(e => e.LUid)
					.HasColumnName("l_uid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.LDane)
					.HasColumnName("l_dane")
					.HasColumnType("text");

				entity.Property(e => e.LId)
					.HasColumnName("l_id")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.LSezon)
					.HasColumnName("l_sezon")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<F1Linki>(entity =>
			{
				entity.HasKey(e => e.LId);

				entity.ToTable("f1_linki");

				entity.HasIndex(e => e.LCatgrp)
					.HasName("l_catgrp");

				entity.HasIndex(e => e.LCatstr)
					.HasName("l_catstr");

				entity.HasIndex(e => e.LData)
					.HasName("l_data");

				entity.HasIndex(e => e.LNazwa)
					.HasName("l_nazwa");

				entity.HasIndex(e => e.LOcena)
					.HasName("l_ocena");

				entity.HasIndex(e => e.LOdslony)
					.HasName("l_odslony");

				entity.Property(e => e.LId)
					.HasColumnName("l_id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.LBanurl)
					.HasColumnName("l_banurl")
					.HasMaxLength(128);

				entity.Property(e => e.LCatgrp)
					.HasColumnName("l_catgrp")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.LCatstr)
					.HasColumnName("l_catstr")
					.HasMaxLength(64);

				entity.Property(e => e.LData)
					.HasColumnName("l_data")
					.HasColumnType("datetime")
					.HasDefaultValueSql("'0000-00-00 00:00:00'");

				entity.Property(e => e.LJezyki)
					.HasColumnName("l_jezyki")
					.HasMaxLength(64);

				entity.Property(e => e.LNazwa)
					.IsRequired()
					.HasColumnName("l_nazwa")
					.HasMaxLength(255)
					.HasDefaultValueSql("''");

				entity.Property(e => e.LOcena)
					.HasColumnName("l_ocena")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.LOdslony)
					.HasColumnName("l_odslony")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.LOpis)
					.HasColumnName("l_opis")
					.HasMaxLength(255);

				entity.Property(e => e.LRotator)
					.HasColumnName("l_rotator")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.LStatus)
					.HasColumnName("l_status")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.LUrl)
					.IsRequired()
					.HasColumnName("l_url")
					.HasMaxLength(128)
					.HasDefaultValueSql("''");
			});

			modelBuilder.Entity<F1LogZmian>(entity =>
			{
				entity.ToTable("f1_log_zmian");

				entity.HasIndex(e => e.ArtId)
					.HasName("art_id");

				entity.HasIndex(e => e.CommId)
					.HasName("comm_id");

				entity.HasIndex(e => e.Data)
					.HasName("data");

				entity.HasIndex(e => e.NewsId)
					.HasName("news_id");

				entity.HasIndex(e => e.TextId)
					.HasName("text_id");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("char(32)");

				entity.Property(e => e.ArtId)
					.HasColumnName("art_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Autor)
					.IsRequired()
					.HasColumnName("autor")
					.HasMaxLength(64);

				entity.Property(e => e.CommId)
					.HasColumnName("comm_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Data)
					.HasColumnName("data")
					.HasColumnType("datetime");

				entity.Property(e => e.NewsId)
					.HasColumnName("news_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.TextId)
					.HasColumnName("text_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.UserId)
					.HasColumnName("user_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Zmiany)
					.IsRequired()
					.HasColumnName("zmiany")
					.HasColumnType("text");
			});

			modelBuilder.Entity<F1Newseditorcats>(entity =>
			{
				entity.HasKey(e => e.Catid);

				entity.ToTable("f1_newseditorcats");

				entity.Property(e => e.Catid)
					.HasColumnName("catid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasColumnName("name")
					.HasMaxLength(40)
					.HasDefaultValueSql("''");
			});

			modelBuilder.Entity<F1Newseditordata>(entity =>
			{
				entity.HasKey(e => e.Dataid);

				entity.ToTable("f1_newseditordata");

				entity.HasIndex(e => e.Name1)
					.HasName("name1");

				entity.Property(e => e.Dataid)
					.HasColumnName("dataid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Catid)
					.HasColumnName("catid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Image)
					.IsRequired()
					.HasColumnName("image")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Name1)
					.IsRequired()
					.HasColumnName("name1")
					.HasMaxLength(40)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Name2)
					.IsRequired()
					.HasColumnName("name2")
					.HasMaxLength(40)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Url)
					.IsRequired()
					.HasColumnName("url")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");
			});

			modelBuilder.Entity<F1quotes>(entity =>
			{
				entity.ToTable("f1quotes");

				entity.HasIndex(e => e.Date)
					.HasName("date");

				entity.HasIndex(e => e.Raceid)
					.HasName("raceid");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Date)
					.HasColumnName("date")
					.HasColumnType("datetime");

				entity.Property(e => e.Hidden).HasColumnName("hidden");

				entity.Property(e => e.Poster)
					.IsRequired()
					.HasColumnName("poster")
					.HasMaxLength(45);

				entity.Property(e => e.Q1name)
					.IsRequired()
					.HasColumnName("q1name")
					.HasMaxLength(30);

				entity.Property(e => e.Q1nameadd)
					.IsRequired()
					.HasColumnName("q1nameadd")
					.HasMaxLength(60);

				entity.Property(e => e.Q1text)
					.IsRequired()
					.HasColumnName("q1text")
					.HasColumnType("text");

				entity.Property(e => e.Q2name)
					.IsRequired()
					.HasColumnName("q2name")
					.HasMaxLength(30);

				entity.Property(e => e.Q2nameadd)
					.IsRequired()
					.HasColumnName("q2nameadd")
					.HasMaxLength(60);

				entity.Property(e => e.Q2text)
					.IsRequired()
					.HasColumnName("q2text")
					.HasColumnType("text");

				entity.Property(e => e.Q3name)
					.IsRequired()
					.HasColumnName("q3name")
					.HasMaxLength(30);

				entity.Property(e => e.Q3nameadd)
					.IsRequired()
					.HasColumnName("q3nameadd")
					.HasMaxLength(60);

				entity.Property(e => e.Q3text)
					.IsRequired()
					.HasColumnName("q3text")
					.HasColumnType("text");

				entity.Property(e => e.Q4name)
					.IsRequired()
					.HasColumnName("q4name")
					.HasMaxLength(30);

				entity.Property(e => e.Q4nameadd)
					.IsRequired()
					.HasColumnName("q4nameadd")
					.HasMaxLength(60);

				entity.Property(e => e.Q4text)
					.IsRequired()
					.HasColumnName("q4text")
					.HasColumnType("text");

				entity.Property(e => e.Qtype).HasColumnName("qtype");

				entity.Property(e => e.Raceid)
					.HasColumnName("raceid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Redid)
					.HasColumnName("redid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Teamascid)
					.IsRequired()
					.HasColumnName("teamascid")
					.HasColumnType("char(3)");

				entity.Property(e => e.Teaminfo)
					.IsRequired()
					.HasColumnName("teaminfo")
					.HasMaxLength(255);

				entity.Property(e => e.Teampos).HasColumnName("teampos");
			});

			modelBuilder.Entity<F1Redakcja>(entity =>
			{
				entity.ToTable("f1_redakcja");

				entity.HasIndex(e => e.Grupa)
					.HasName("grupa");

				entity.HasIndex(e => e.Skroty)
					.HasName("skroty");

				entity.HasIndex(e => e.Userid)
					.HasName("userid");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Email)
					.IsRequired()
					.HasColumnName("email")
					.HasMaxLength(64);

				entity.Property(e => e.F1db)
					.HasColumnName("f1db")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Funkcja)
					.IsRequired()
					.HasColumnName("funkcja")
					.HasMaxLength(64);

				entity.Property(e => e.Gpm)
					.HasColumnName("gpm")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Grupa).HasColumnName("grupa");

				entity.Property(e => e.Informacje)
					.IsRequired()
					.HasColumnName("informacje")
					.HasColumnType("text");

				entity.Property(e => e.Isdb)
					.HasColumnName("isdb")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Korekta)
					.HasColumnName("korekta")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.L)
					.HasColumnName("l")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Ligna)
					.HasColumnName("ligna")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Modkom)
					.HasColumnName("modkom")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.N)
					.IsRequired()
					.HasColumnName("n")
					.HasMaxLength(45);

				entity.Property(e => e.Portret)
					.IsRequired()
					.HasColumnName("portret")
					.HasMaxLength(64);

				entity.Property(e => e.Skroty)
					.IsRequired()
					.HasColumnName("skroty")
					.HasMaxLength(45);

				entity.Property(e => e.Tylkoligna)
					.HasColumnName("tylkoligna")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Userid)
					.HasColumnName("userid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Www)
					.IsRequired()
					.HasColumnName("www")
					.HasMaxLength(64);
			});

			modelBuilder.Entity<F1Rezerwacje>(entity =>
			{
				entity.ToTable("f1_rezerwacje");

				entity.HasIndex(e => e.Datarez)
					.HasName("datarez");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("char(32)");

				entity.Property(e => e.Datadod)
					.HasColumnName("datadod")
					.HasColumnType("datetime");

				entity.Property(e => e.Datarez)
					.HasColumnName("datarez")
					.HasColumnType("datetime");

				entity.Property(e => e.Linki)
					.IsRequired()
					.HasColumnName("linki")
					.HasColumnType("tinytext");

				entity.Property(e => e.Newsid)
					.HasColumnName("newsid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Notatki)
					.IsRequired()
					.HasColumnName("notatki")
					.HasColumnType("tinytext");

				entity.Property(e => e.Pilne).HasColumnName("pilne");

				entity.Property(e => e.Redaktor)
					.HasColumnName("redaktor")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Rsscrc)
					.HasColumnName("rsscrc")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Status).HasColumnName("status");

				entity.Property(e => e.Tytul)
					.IsRequired()
					.HasColumnName("tytul")
					.HasMaxLength(255);

				entity.Property(e => e.Zglaszajacy)
					.HasColumnName("zglaszajacy")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<F1Subskr>(entity =>
			{
				entity.HasKey(e => e.SId);

				entity.ToTable("f1_subskr");

				entity.HasIndex(e => e.STime)
					.HasName("s_time");

				entity.Property(e => e.SId)
					.HasColumnName("s_id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.SEmail)
					.IsRequired()
					.HasColumnName("s_email")
					.HasMaxLength(100)
					.HasDefaultValueSql("''");

				entity.Property(e => e.SStatus)
					.HasColumnName("s_status")
					.HasColumnType("tinyint(1)")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.STime)
					.HasColumnName("s_time")
					.HasColumnType("int(11)")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<F1teamnames>(entity =>
			{
				entity.HasKey(e => e.Teamnameid);

				entity.ToTable("f1teamnames");

				entity.HasIndex(e => e.Teamid)
					.HasName("teamid");

				entity.HasIndex(e => e.Teamname)
					.HasName("teamname");

				entity.Property(e => e.Teamnameid)
					.HasColumnName("teamnameid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Teamid)
					.HasColumnName("teamid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Teamname)
					.IsRequired()
					.HasColumnName("teamname")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");
			});

			modelBuilder.Entity<F1Texts>(entity =>
			{
				entity.ToTable("f1_texts");

				entity.HasIndex(e => e.Grupa)
					.HasName("grupa");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Grupa)
					.IsRequired()
					.HasColumnName("grupa")
					.HasMaxLength(32);

				entity.Property(e => e.Tresc)
					.IsRequired()
					.HasColumnName("tresc")
					.HasColumnType("text");

				entity.Property(e => e.Tytul)
					.IsRequired()
					.HasColumnName("tytul")
					.HasMaxLength(80);

				entity.Property(e => e.Uprawnienia)
					.HasColumnName("uprawnienia")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Zmieniony)
					.HasColumnName("zmieniony")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<F1ZgloszoneBledy>(entity =>
			{
				entity.ToTable("f1_zgloszone_bledy");

				entity.HasIndex(e => e.ArtId)
					.HasName("art_id");

				entity.HasIndex(e => e.CommId)
					.HasName("comm_id");

				entity.HasIndex(e => e.Data)
					.HasName("data");

				entity.HasIndex(e => e.NewsId)
					.HasName("news_id");

				entity.HasIndex(e => e.Typ)
					.HasName("typ");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("char(32)");

				entity.Property(e => e.ArtId)
					.HasColumnName("art_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.CommId)
					.HasColumnName("comm_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Data)
					.HasColumnName("data")
					.HasColumnType("datetime");

				entity.Property(e => e.NewsId)
					.HasColumnName("news_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.OpisBledu)
					.IsRequired()
					.HasColumnName("opis_bledu")
					.HasColumnType("text");

				entity.Property(e => e.Typ).HasColumnName("typ");

				entity.Property(e => e.UserId)
					.HasColumnName("user_id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Zglaszajacy)
					.IsRequired()
					.HasColumnName("zglaszajacy")
					.HasMaxLength(64);
			});

			modelBuilder.Entity<GpmAdmkonfig>(entity =>
			{
				entity.ToTable("gpm_admkonfig");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasDefaultValueSql("'1'");

				entity.Property(e => e.Cenapunktu).HasColumnName("cenapunktu");

				entity.Property(e => e.Kier3cenamnoz).HasColumnName("kier3cenamnoz");

				entity.Property(e => e.Kier3cenamnozprzed).HasColumnName("kier3cenamnozprzed");

				entity.Property(e => e.Kier3zwrotmnoz).HasColumnName("kier3zwrotmnoz");

				entity.Property(e => e.Komunikaty)
					.IsRequired()
					.HasColumnName("komunikaty")
					.HasColumnType("text");

				entity.Property(e => e.Koniec1fazy).HasColumnName("koniec1fazy");

				entity.Property(e => e.Krokinicjalizacji).HasColumnName("krokinicjalizacji");

				entity.Property(e => e.Powodblokady)
					.IsRequired()
					.HasColumnName("powodblokady")
					.HasMaxLength(255);

				entity.Property(e => e.Przelcennik1)
					.IsRequired()
					.HasColumnName("przelcennik1")
					.HasMaxLength(90);

				entity.Property(e => e.Przelcennik2)
					.IsRequired()
					.HasColumnName("przelcennik2")
					.HasMaxLength(90);

				entity.Property(e => e.Rok).HasColumnName("rok");

				entity.Property(e => e.Sponsorzy)
					.IsRequired()
					.HasColumnName("sponsorzy")
					.HasColumnType("text");

				entity.Property(e => e.Startmoney).HasColumnName("startmoney");

				entity.Property(e => e.Typowanie)
					.IsRequired()
					.HasColumnName("typowanie")
					.HasMaxLength(90);

				entity.Property(e => e.Typpktpomylka).HasColumnName("typpktpomylka");

				entity.Property(e => e.Wymusblokade).HasColumnName("wymusblokade");

				entity.Property(e => e.Zwrotmnoz).HasColumnName("zwrotmnoz");

				entity.Property(e => e.Zwrotmnoz1faza).HasColumnName("zwrotmnoz1faza");
			});

			modelBuilder.Entity<GpmAdmskladniki>(entity =>
			{
				entity.ToTable("gpm_admskladniki");

				entity.HasIndex(e => e.Nazwa)
					.HasName("nazwa");

				entity.HasIndex(e => new { e.Typ, e.Cena })
					.HasName("typ_cena");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Ascid)
					.IsRequired()
					.HasColumnName("ascid")
					.HasMaxLength(4);

				entity.Property(e => e.Cena).HasColumnName("cena");

				entity.Property(e => e.Idmodelu)
					.HasColumnName("idmodelu")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Kierzesp)
					.IsRequired()
					.HasColumnName("kierzesp")
					.HasMaxLength(3);

				entity.Property(e => e.Nazwa)
					.IsRequired()
					.HasColumnName("nazwa")
					.HasMaxLength(45);

				entity.Property(e => e.Niestartuje).HasColumnName("niestartuje");

				entity.Property(e => e.Nrstart).HasColumnName("nrstart");

				entity.Property(e => e.Staryzespol)
					.IsRequired()
					.HasColumnName("staryzespol")
					.HasMaxLength(3);

				entity.Property(e => e.Typ).HasColumnName("typ");

				entity.Property(e => e.Wymuszona).HasColumnName("wymuszona");
			});

			modelBuilder.Entity<GpmAdmwyscigi>(entity =>
			{
				entity.HasKey(e => e.Nr);

				entity.ToTable("gpm_admwyscigi");

				entity.Property(e => e.Nr).HasColumnName("nr");

				entity.Property(e => e.Ceny)
					.HasColumnName("ceny")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Kontuzje)
					.IsRequired()
					.HasColumnName("kontuzje")
					.HasMaxLength(45);

				entity.Property(e => e.Kraj)
					.IsRequired()
					.HasColumnName("kraj")
					.HasColumnType("char(3)");

				entity.Property(e => e.Kwaldzien).HasColumnName("kwaldzien");

				entity.Property(e => e.Kwalgodz).HasColumnName("kwalgodz");

				entity.Property(e => e.Kwalmies).HasColumnName("kwalmies");

				entity.Property(e => e.Kwalmin)
					.HasColumnName("kwalmin")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Punkty)
					.HasColumnName("punkty")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Wyplata)
					.HasColumnName("wyplata")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Wyscdzien).HasColumnName("wyscdzien");

				entity.Property(e => e.Wyscmies).HasColumnName("wyscmies");
			});

			modelBuilder.Entity<GpmKlasgen>(entity =>
			{
				entity.HasKey(e => e.Zespolid);

				entity.ToTable("gpm_klasgen");

				entity.HasIndex(e => e.Miejsce)
					.HasName("miejsce");

				entity.HasIndex(e => e.Nieaktywny)
					.HasName("nieaktywny");

				entity.HasIndex(e => e.Suma)
					.HasName("suma");

				entity.Property(e => e.Zespolid)
					.HasColumnName("zespolid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Miejsce)
					.HasColumnName("miejsce")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Nieaktywny)
					.HasColumnName("nieaktywny")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Suma)
					.HasColumnName("suma")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.W1).HasColumnName("w1");

				entity.Property(e => e.W10).HasColumnName("w10");

				entity.Property(e => e.W11).HasColumnName("w11");

				entity.Property(e => e.W12).HasColumnName("w12");

				entity.Property(e => e.W13).HasColumnName("w13");

				entity.Property(e => e.W14).HasColumnName("w14");

				entity.Property(e => e.W15).HasColumnName("w15");

				entity.Property(e => e.W16).HasColumnName("w16");

				entity.Property(e => e.W17).HasColumnName("w17");

				entity.Property(e => e.W18).HasColumnName("w18");

				entity.Property(e => e.W19).HasColumnName("w19");

				entity.Property(e => e.W2).HasColumnName("w2");

				entity.Property(e => e.W20).HasColumnName("w20");

				entity.Property(e => e.W21).HasColumnName("w21");

				entity.Property(e => e.W3).HasColumnName("w3");

				entity.Property(e => e.W4).HasColumnName("w4");

				entity.Property(e => e.W5).HasColumnName("w5");

				entity.Property(e => e.W6).HasColumnName("w6");

				entity.Property(e => e.W7).HasColumnName("w7");

				entity.Property(e => e.W8).HasColumnName("w8");

				entity.Property(e => e.W9).HasColumnName("w9");

				entity.Property(e => e.Zmiana)
					.HasColumnName("zmiana")
					.HasColumnType("smallint(3)");
			});

			modelBuilder.Entity<GpmKlasgenpoz>(entity =>
			{
				entity.HasKey(e => e.Zespolid);

				entity.ToTable("gpm_klasgenpoz");

				entity.Property(e => e.Zespolid)
					.HasColumnName("zespolid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P1)
					.HasColumnName("p1")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P10)
					.HasColumnName("p10")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P11)
					.HasColumnName("p11")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P12)
					.HasColumnName("p12")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P13)
					.HasColumnName("p13")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P14)
					.HasColumnName("p14")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P15)
					.HasColumnName("p15")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P16)
					.HasColumnName("p16")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P17)
					.HasColumnName("p17")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P18)
					.HasColumnName("p18")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P19)
					.HasColumnName("p19")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P2)
					.HasColumnName("p2")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P20)
					.HasColumnName("p20")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P21)
					.HasColumnName("p21")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P3)
					.HasColumnName("p3")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P4)
					.HasColumnName("p4")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P5)
					.HasColumnName("p5")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P6)
					.HasColumnName("p6")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P7)
					.HasColumnName("p7")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P8)
					.HasColumnName("p8")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.P9)
					.HasColumnName("p9")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<GpmKlastyp>(entity =>
			{
				entity.HasKey(e => e.Zespolid);

				entity.ToTable("gpm_klastyp");

				entity.HasIndex(e => e.Sumatyp)
					.HasName("sumatyp");

				entity.Property(e => e.Zespolid)
					.HasColumnName("zespolid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Sumatyp)
					.HasColumnName("sumatyp")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.T1).HasColumnName("t1");

				entity.Property(e => e.T10).HasColumnName("t10");

				entity.Property(e => e.T11).HasColumnName("t11");

				entity.Property(e => e.T12).HasColumnName("t12");

				entity.Property(e => e.T13).HasColumnName("t13");

				entity.Property(e => e.T14).HasColumnName("t14");

				entity.Property(e => e.T15).HasColumnName("t15");

				entity.Property(e => e.T16).HasColumnName("t16");

				entity.Property(e => e.T17).HasColumnName("t17");

				entity.Property(e => e.T18).HasColumnName("t18");

				entity.Property(e => e.T19).HasColumnName("t19");

				entity.Property(e => e.T2).HasColumnName("t2");

				entity.Property(e => e.T20).HasColumnName("t20");

				entity.Property(e => e.T21).HasColumnName("t21");

				entity.Property(e => e.T3).HasColumnName("t3");

				entity.Property(e => e.T4).HasColumnName("t4");

				entity.Property(e => e.T5).HasColumnName("t5");

				entity.Property(e => e.T6).HasColumnName("t6");

				entity.Property(e => e.T7).HasColumnName("t7");

				entity.Property(e => e.T8).HasColumnName("t8");

				entity.Property(e => e.T9).HasColumnName("t9");
			});

			modelBuilder.Entity<GpmKlaswszech>(entity =>
			{
				entity.HasKey(e => e.Zespolid);

				entity.ToTable("gpm_klaswszech");

				entity.Property(e => e.Zespolid)
					.HasColumnName("zespolid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Miejsce)
					.HasColumnName("miejsce")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.S2005)
					.HasColumnName("s2005")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.S2006)
					.HasColumnName("s2006")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.S2007)
					.HasColumnName("s2007")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.S2008)
					.HasColumnName("s2008")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.S2009)
					.HasColumnName("s2009")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.S2010)
					.HasColumnName("s2010")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.S2011)
					.HasColumnName("s2011")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.S2012)
					.HasColumnName("s2012")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.S2013)
					.HasColumnName("s2013")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.S2014)
					.HasColumnName("s2014")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.S2015)
					.HasColumnName("s2015")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.S2016)
					.HasColumnName("s2016")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.S2017)
					.HasColumnName("s2017")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.S2018)
					.HasColumnName("s2018")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Suma)
					.HasColumnName("suma")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Zmiana)
					.HasColumnName("zmiana")
					.HasColumnType("smallint(6)")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<GpmLigi>(entity =>
			{
				entity.HasKey(e => e.Ligaid);

				entity.ToTable("gpm_ligi");

				entity.HasIndex(e => e.Komentarze)
					.HasName("komentarze");

				entity.HasIndex(e => e.Nazwa)
					.HasName("nazwa");

				entity.HasIndex(e => e.Zespoly)
					.HasName("zespoly");

				entity.Property(e => e.Ligaid)
					.HasColumnName("ligaid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Komentarze)
					.HasColumnName("komentarze")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Limitzespolow)
					.HasColumnName("limitzespolow")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Nazwa)
					.IsRequired()
					.HasColumnName("nazwa")
					.HasMaxLength(45);

				entity.Property(e => e.Sumapkt)
					.HasColumnName("sumapkt")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Zalozycielid)
					.HasColumnName("zalozycielid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Zamknieta)
					.HasColumnName("zamknieta")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Zespoly)
					.HasColumnName("zespoly")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'1'");
			});

			modelBuilder.Entity<GpmLigiKoms>(entity =>
			{
				entity.HasKey(e => e.Komid);

				entity.ToTable("gpm_ligi_koms");

				entity.HasIndex(e => e.Czas)
					.HasName("time");

				entity.HasIndex(e => e.Ligaid)
					.HasName("ligaid");

				entity.Property(e => e.Komid)
					.HasColumnName("komid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Autor)
					.IsRequired()
					.HasColumnName("autor")
					.HasMaxLength(255);

				entity.Property(e => e.Czas)
					.HasColumnName("czas")
					.HasColumnType("datetime");

				entity.Property(e => e.Ligaid)
					.HasColumnName("ligaid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Status)
					.HasColumnName("status")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Tresc)
					.IsRequired()
					.HasColumnName("tresc")
					.HasColumnType("text");

				entity.Property(e => e.Zespolid)
					.HasColumnName("zespolid")
					.HasColumnType("mediumint unsigned");
			});

			modelBuilder.Entity<GpmSklady>(entity =>
			{
				entity.ToTable("gpm_sklady");

				entity.HasIndex(e => e.Wyscnr)
					.HasName("wyscnr");

				entity.HasIndex(e => e.Zespolid)
					.HasName("zespolid");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Bolid)
					.HasColumnName("bolid")
					.HasColumnType("char(3)");

				entity.Property(e => e.Kier1)
					.HasColumnName("kier1")
					.HasColumnType("char(4)");

				entity.Property(e => e.Kier2)
					.HasColumnName("kier2")
					.HasColumnType("char(4)");

				entity.Property(e => e.Kier3)
					.HasColumnName("kier3")
					.HasColumnType("char(4)");

				entity.Property(e => e.Silnik)
					.HasColumnName("silnik")
					.HasColumnType("char(3)");

				entity.Property(e => e.Typ0)
					.HasColumnName("typ0")
					.HasColumnType("char(4)");

				entity.Property(e => e.Typ1)
					.HasColumnName("typ1")
					.HasColumnType("char(4)");

				entity.Property(e => e.Typ10)
					.HasColumnName("typ10")
					.HasColumnType("char(4)");

				entity.Property(e => e.Typ2)
					.HasColumnName("typ2")
					.HasColumnType("char(4)");

				entity.Property(e => e.Typ3)
					.HasColumnName("typ3")
					.HasColumnType("char(4)");

				entity.Property(e => e.Typ4)
					.HasColumnName("typ4")
					.HasColumnType("char(4)");

				entity.Property(e => e.Typ5)
					.HasColumnName("typ5")
					.HasColumnType("char(4)");

				entity.Property(e => e.Typ6)
					.HasColumnName("typ6")
					.HasColumnType("char(4)");

				entity.Property(e => e.Typ7)
					.HasColumnName("typ7")
					.HasColumnType("char(4)");

				entity.Property(e => e.Typ8)
					.HasColumnName("typ8")
					.HasColumnType("char(4)");

				entity.Property(e => e.Typ9)
					.HasColumnName("typ9")
					.HasColumnType("char(4)");

				entity.Property(e => e.Wyscnr)
					.HasColumnName("wyscnr")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Zespolid)
					.HasColumnName("zespolid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<GpmZespoly>(entity =>
			{
				entity.HasKey(e => e.Zespolid);

				entity.ToTable("gpm_zespoly");

				entity.HasIndex(e => e.Email)
					.HasName("email")
					.IsUnique();

				entity.HasIndex(e => e.Haslo)
					.HasName("haslo");

				entity.HasIndex(e => e.Ligaid)
					.HasName("ligaid");

				entity.HasIndex(e => e.Login)
					.HasName("login")
					.IsUnique();

				entity.HasIndex(e => e.Nazwa)
					.HasName("nazwa");

				entity.HasIndex(e => e.Wartosc)
					.HasName("wartosc");

				entity.Property(e => e.Zespolid)
					.HasColumnName("zespolid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Adresip)
					.IsRequired()
					.HasColumnName("adresip")
					.HasMaxLength(8)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Agentcrc)
					.HasColumnName("agentcrc")
					.HasColumnType("int(11)")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Aktywacja)
					.HasColumnName("aktywacja")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Email)
					.IsRequired()
					.HasColumnName("email")
					.HasMaxLength(255)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Gg).HasColumnName("gg");

				entity.Property(e => e.Gotowka)
					.HasColumnName("gotowka")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Haslo)
					.IsRequired()
					.HasColumnName("haslo")
					.HasMaxLength(34)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Ligaid)
					.HasColumnName("ligaid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Ligaidzapr)
					.HasColumnName("ligaidzapr")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Login)
					.IsRequired()
					.HasColumnName("login")
					.HasMaxLength(30)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Nazwa)
					.IsRequired()
					.HasColumnName("nazwa")
					.HasMaxLength(20)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Nazwisko)
					.HasColumnName("nazwisko")
					.HasMaxLength(30);

				entity.Property(e => e.Nowehaslo)
					.IsRequired()
					.HasColumnName("nowehaslo")
					.HasMaxLength(34);

				entity.Property(e => e.Ostwizyta)
					.HasColumnName("ostwizyta")
					.HasColumnType("int(11)")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Plec)
					.HasColumnName("plec")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Pokazujemail)
					.HasColumnName("pokazujemail")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Pokazujsklad)
					.HasColumnName("pokazujsklad")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Siedziba)
					.HasColumnName("siedziba")
					.HasMaxLength(30);

				entity.Property(e => e.Typavatara)
					.HasColumnName("typavatara")
					.HasMaxLength(4);

				entity.Property(e => e.Ulubkier)
					.IsRequired()
					.HasColumnName("ulubkier")
					.HasMaxLength(4)
					.HasDefaultValueSql("'brak'");

				entity.Property(e => e.Ulubtor)
					.IsRequired()
					.HasColumnName("ulubtor")
					.HasMaxLength(30)
					.HasDefaultValueSql("'brak'");

				entity.Property(e => e.Ulubzesp)
					.IsRequired()
					.HasColumnName("ulubzesp")
					.HasMaxLength(4)
					.HasDefaultValueSql("'brak'");

				entity.Property(e => e.Wartosc)
					.HasColumnName("wartosc")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<GpmZwyciezcy>(entity =>
			{
				entity.ToTable("gpm_zwyciezcy");

				entity.HasIndex(e => e.Wyscnr)
					.HasName("wyscnr");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Punkty)
					.HasColumnName("punkty")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Wyscnr)
					.HasColumnName("wyscnr")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Zespolid)
					.HasColumnName("zespolid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<InneKlaskier>(entity =>
			{
				entity.ToTable("inne_klaskier");

				entity.HasIndex(e => e.Kierowcaid)
					.HasName("kierowcaid");

				entity.HasIndex(e => e.Mistrz)
					.HasName("mistrz");

				entity.HasIndex(e => e.Seriaid)
					.HasName("seriaid");

				entity.HasIndex(e => e.Sezon)
					.HasName("sezon");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Kierowcaid)
					.HasColumnName("kierowcaid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Klasa)
					.IsRequired()
					.HasColumnName("klasa")
					.HasColumnType("char(10)");

				entity.Property(e => e.Mistrz)
					.HasColumnName("mistrz")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Pozycja)
					.HasColumnName("pozycja")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Seriaid)
					.HasColumnName("seriaid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Sezon)
					.IsRequired()
					.HasColumnName("sezon")
					.HasColumnType("char(7)");
			});

			modelBuilder.Entity<InneRezultatyBk>(entity =>
			{
				entity.ToTable("inne_rezultaty_bk");

				entity.HasIndex(e => e.Imprezaid)
					.HasName("imprezaid");

				entity.HasIndex(e => e.Pozycja)
					.HasName("pozycja");

				entity.HasIndex(e => e.Zgloszenieid)
					.HasName("zgloszenieid");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Czas).HasColumnName("czas");

				entity.Property(e => e.Dodpktza)
					.HasColumnName("dodpktza")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Imprezaid)
					.HasColumnName("imprezaid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Okrazenia).HasColumnName("okrazenia");

				entity.Property(e => e.Pozklasa)
					.HasColumnName("pozklasa")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Pozycja).HasColumnName("pozycja");

				entity.Property(e => e.Status)
					.IsRequired()
					.HasColumnName("status")
					.HasColumnType("char(2)");

				entity.Property(e => e.Zgloszenieid)
					.HasColumnName("zgloszenieid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<InneTerminy>(entity =>
			{
				entity.ToTable("inne_terminy");

				entity.HasIndex(e => e.Rokmies)
					.HasName("rokmies");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Godzina)
					.IsRequired()
					.HasColumnName("godzina")
					.HasMaxLength(5);

				entity.Property(e => e.Nazwa)
					.IsRequired()
					.HasColumnName("nazwa")
					.HasMaxLength(80);

				entity.Property(e => e.Rokmies)
					.IsRequired()
					.HasColumnName("rokmies")
					.HasColumnType("char(6)");

				entity.Property(e => e.Skrotnazwy)
					.IsRequired()
					.HasColumnName("skrotnazwy")
					.HasMaxLength(20);

				entity.Property(e => e.Url)
					.IsRequired()
					.HasColumnName("url")
					.HasMaxLength(255);
			});

			modelBuilder.Entity<InneZasady>(entity =>
			{
				entity.ToTable("inne_zasady");

				entity.HasIndex(e => new { e.Seriaid, e.Sezon })
					.HasName("seriasezon");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Seriaid)
					.HasColumnName("seriaid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Sezon)
					.IsRequired()
					.HasColumnName("sezon")
					.HasColumnType("char(7)");

				entity.Property(e => e.Zasady)
					.IsRequired()
					.HasColumnName("zasady")
					.HasColumnType("text");
			});

			modelBuilder.Entity<StatLog>(entity =>
			{
				entity.HasKey(e => e.LogId);

				entity.ToTable("stat_log");

				entity.Property(e => e.LogId)
					.HasColumnName("log_id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.LogAgent)
					.IsRequired()
					.HasColumnName("log_agent")
					.HasMaxLength(128)
					.HasDefaultValueSql("''");

				entity.Property(e => e.LogDataiczas)
					.HasColumnName("log_dataiczas")
					.HasColumnType("datetime")
					.HasDefaultValueSql("'0000-00-00 00:00:00'");

				entity.Property(e => e.LogHost)
					.IsRequired()
					.HasColumnName("log_host")
					.HasMaxLength(100)
					.HasDefaultValueSql("''");

				entity.Property(e => e.LogIp)
					.IsRequired()
					.HasColumnName("log_ip")
					.HasMaxLength(15)
					.HasDefaultValueSql("'0.0.0.0'");

				entity.Property(e => e.LogStronaid)
					.HasColumnName("log_stronaid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<StatRef>(entity =>
			{
				entity.HasKey(e => e.RefId);

				entity.ToTable("stat_ref");

				entity.HasIndex(e => e.RefCzas)
					.HasName("ref_czas");

				entity.HasIndex(e => e.RefRefdomid)
					.HasName("ref_refdomid");

				entity.HasIndex(e => e.RefSciezka)
					.HasName("ref_sciezka");

				entity.Property(e => e.RefId)
					.HasColumnName("ref_id")
					.HasColumnType("char(32)");

				entity.Property(e => e.RefCzas)
					.HasColumnName("ref_czas")
					.HasColumnType("int(11)")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.RefRefdomid)
					.IsRequired()
					.HasColumnName("ref_refdomid")
					.HasColumnType("char(32)")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.RefSciezka)
					.IsRequired()
					.HasColumnName("ref_sciezka")
					.HasMaxLength(255)
					.HasDefaultValueSql("''");

				entity.Property(e => e.RefStronaid)
					.HasColumnName("ref_stronaid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<StatRefdom>(entity =>
			{
				entity.HasKey(e => e.RefdomId);

				entity.ToTable("stat_refdom");

				entity.HasIndex(e => e.RefdomNazwa)
					.HasName("refdom_nazwa");

				entity.Property(e => e.RefdomId)
					.HasColumnName("refdom_id")
					.HasColumnType("char(32)");

				entity.Property(e => e.RefdomNazwa)
					.IsRequired()
					.HasColumnName("refdom_nazwa")
					.HasMaxLength(255)
					.HasDefaultValueSql("''");

				entity.Property(e => e.RefdomOdslony)
					.HasColumnName("refdom_odslony")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<StatSesje>(entity =>
			{
				entity.HasKey(e => e.SesjaId);

				entity.ToTable("stat_sesje");

				entity.HasIndex(e => e.SesjaAgentcrc)
					.HasName("sesja_agentcrc");

				entity.HasIndex(e => e.SesjaCzas)
					.HasName("sesja_czas");

				entity.HasIndex(e => e.SesjaIp)
					.HasName("sesja_ip");

				entity.HasIndex(e => e.SesjaStart)
					.HasName("sesja_start");

				entity.Property(e => e.SesjaId)
					.HasColumnName("sesja_id")
					.HasColumnType("char(32)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.SesjaAgentcrc)
					.HasColumnName("sesja_agentcrc")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.SesjaCzas)
					.HasColumnName("sesja_czas")
					.HasColumnType("int(11)")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.SesjaIp)
					.IsRequired()
					.HasColumnName("sesja_ip")
					.HasColumnType("char(8)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.SesjaStart)
					.HasColumnName("sesja_start")
					.HasColumnType("int(11)")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.SesjaStronaid)
					.HasColumnName("sesja_stronaid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<StatStrony>(entity =>
			{
				entity.HasKey(e => e.StronaId);

				entity.ToTable("stat_strony");

				entity.HasIndex(e => e.StronaNazwa)
					.HasName("strona_nazwa");

				entity.Property(e => e.StronaId)
					.HasColumnName("strona_id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.StronaCzas)
					.HasColumnName("strona_czas")
					.HasColumnType("int(11)")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.StronaNazwa)
					.IsRequired()
					.HasColumnName("strona_nazwa")
					.HasMaxLength(100)
					.HasDefaultValueSql("''");

				entity.Property(e => e.StronaOdslony)
					.HasColumnName("strona_odslony")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<SympollAuth>(entity =>
			{
				entity.HasKey(e => e.Uid);

				entity.ToTable("sympoll_auth");

				entity.Property(e => e.Uid)
					.HasColumnName("uid")
					.HasColumnType("int(11)");

				entity.Property(e => e.Access).HasColumnName("access");

				entity.Property(e => e.Pass)
					.IsRequired()
					.HasColumnName("pass")
					.HasMaxLength(32);

				entity.Property(e => e.Secret)
					.HasColumnName("secret")
					.HasMaxLength(32);

				entity.Property(e => e.User)
					.IsRequired()
					.HasColumnName("user")
					.HasMaxLength(32);
			});

			modelBuilder.Entity<SympollList>(entity =>
			{
				entity.HasKey(e => e.Pid);

				entity.ToTable("sympoll_list");

				entity.Property(e => e.Pid).HasColumnName("pid");

				entity.Property(e => e.CookieStamp).HasColumnName("cookieStamp");

				entity.Property(e => e.Nextcid)
					.HasColumnName("nextcid")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Question)
					.IsRequired()
					.HasColumnName("question")
					.HasMaxLength(250);

				entity.Property(e => e.Status).HasColumnName("status");

				entity.Property(e => e.TimeStamp).HasColumnName("timeStamp");
			});
		}
	}
}
