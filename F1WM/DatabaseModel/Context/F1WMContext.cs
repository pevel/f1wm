using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace F1WM.DatabaseModel
{
	public class F1WMContext : DbContext
	{
		public virtual DbSet<AjaxChatMessages> AjaxChatMessages { get; set; }
		public virtual DbSet<F1Arts> F1Arts { get; set; }
		public virtual DbSet<F1ArtsCats> F1ArtsCats { get; set; }
		public virtual DbSet<Constructor> Constructors { get; set; }
		public virtual DbSet<F1cars> F1cars { get; set; }
		public virtual DbSet<F1carsspecs> F1carsspecs { get; set; }
		public virtual DbSet<F1ConfigSections> F1ConfigSections { get; set; }
		public virtual DbSet<F1ConfigText> F1ConfigText { get; set; }
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
		public virtual DbSet<F1engines> F1engines { get; set; }
		public virtual DbSet<F1enginesspecs> F1enginesspecs { get; set; }
		public virtual DbSet<Entry> Entries { get; set; }
		public virtual DbSet<F1fastestlaps> F1fastestlaps { get; set; }
		public virtual DbSet<F1glossary> F1glossary { get; set; }
		public virtual DbSet<Grid> Grids { get; set; }
		public virtual DbSet<F1Hideusercoms> F1Hideusercoms { get; set; }
		public virtual DbSet<F1lapsled> F1lapsled { get; set; }
		public virtual DbSet<F1Ligna> F1Ligna { get; set; }
		public virtual DbSet<F1Linki> F1Linki { get; set; }
		public virtual DbSet<F1LogZmian> F1LogZmian { get; set; }
		public virtual DbSet<Country> Countries { get; set; }
		public virtual DbSet<News> News { get; set; }
		public virtual DbSet<F1NewsCats> F1NewsCats { get; set; }
		public virtual DbSet<NewsComment> NewsComments { get; set; }
		public virtual DbSet<NewsCommentText> NewsCommentTexts { get; set; }
		public virtual DbSet<F1Newseditorcats> F1Newseditorcats { get; set; }
		public virtual DbSet<F1Newseditordata> F1Newseditordata { get; set; }
		public virtual DbSet<F1newsgp> F1newsgp { get; set; }
		public virtual DbSet<F1NewsTopicmatch> F1NewsTopicmatch { get; set; }
		public virtual DbSet<NewsTopic> NewsTopics { get; set; }
		public virtual DbSet<F1NewsTypes> F1NewsTypes { get; set; }
		public virtual DbSet<F1othersessions> F1othersessions { get; set; }
		public virtual DbSet<F1quals> F1quals { get; set; }
		public virtual DbSet<F1quotes> F1quotes { get; set; }
		public virtual DbSet<Race> Races { get; set; }
		public virtual DbSet<F1Redakcja> F1Redakcja { get; set; }
		public virtual DbSet<Result> Results { get; set; }
		public virtual DbSet<F1Rezerwacje> F1Rezerwacje { get; set; }
		public virtual DbSet<Season> Seasons { get; set; }
		public virtual DbSet<F1Subskr> F1Subskr { get; set; }
		public virtual DbSet<F1teamnames> F1teamnames { get; set; }
		public virtual DbSet<F1teams> F1teams { get; set; }
		public virtual DbSet<F1Texts> F1Texts { get; set; }
		public virtual DbSet<Track> Tracks { get; set; }
		public virtual DbSet<F1tyres> F1tyres { get; set; }
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
		public virtual DbSet<InneDodpktza> InneDodpktza { get; set; }
		public virtual DbSet<InneImprezy> InneImprezy { get; set; }
		public virtual DbSet<InneKierowcy> InneKierowcy { get; set; }
		public virtual DbSet<InneKlaskier> InneKlaskier { get; set; }
		public virtual DbSet<InneListystart> InneListystart { get; set; }
		public virtual DbSet<InneRezultaty> InneRezultaty { get; set; }
		public virtual DbSet<InneRezultatyBk> InneRezultatyBk { get; set; }
		public virtual DbSet<InneSerie> InneSerie { get; set; }
		public virtual DbSet<InneTerminy> InneTerminy { get; set; }
		public virtual DbSet<InneZasady> InneZasady { get; set; }
		public virtual DbSet<StatLog> StatLog { get; set; }
		public virtual DbSet<StatRef> StatRef { get; set; }
		public virtual DbSet<StatRefdom> StatRefdom { get; set; }
		public virtual DbSet<StatSesje> StatSesje { get; set; }
		public virtual DbSet<StatStrony> StatStrony { get; set; }
		public virtual DbSet<SympollAuth> SympollAuth { get; set; }
		public virtual DbSet<SympollList> SympollList { get; set; }

		// Unable to generate entity type for table 'ajax_chat_bans'. Please see the warning messages.
		// Unable to generate entity type for table 'ajax_chat_invitations'. Please see the warning messages.
		// Unable to generate entity type for table 'ajax_chat_online'. Please see the warning messages.
		// Unable to generate entity type for table 'stat_dni'. Please see the warning messages.
		// Unable to generate entity type for table 'stat_mies'. Please see the warning messages.
		// Unable to generate entity type for table 'sympoll_data'. Please see the warning messages.
		// Unable to generate entity type for table 'sympoll_iplog'. Please see the warning messages.

		public F1WMContext(DbContextOptions<F1WMContext> options) : base(options)
		{ }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AjaxChatMessages>(entity =>
			{
				entity.ToTable("ajax_chat_messages");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("int(11)");

				entity.Property(e => e.Channel)
					.HasColumnName("channel")
					.HasColumnType("int(11)");

				entity.Property(e => e.DateTime)
					.HasColumnName("dateTime")
					.HasColumnType("datetime");

				entity.Property(e => e.Ip)
					.IsRequired()
					.HasColumnName("ip")
					.HasMaxLength(16);

				entity.Property(e => e.Text)
					.HasColumnName("text")
					.HasColumnType("text");

				entity.Property(e => e.UserId)
					.HasColumnName("userID")
					.HasColumnType("int(11)");

				entity.Property(e => e.UserName)
					.IsRequired()
					.HasColumnName("userName")
					.HasMaxLength(64);

				entity.Property(e => e.UserRole)
					.HasColumnName("userRole")
					.HasColumnType("int(1)");
			});

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

			modelBuilder.Entity<Constructor>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.ToTable("f1carmakes");

				entity.HasIndex(e => e.Ascid)
					.HasName("ascid")
					.IsUnique();

				entity.HasIndex(e => e.Name)
					.HasName("carmake");

				entity.HasIndex(e => e.Letter)
					.HasName("litera");

				entity.HasIndex(e => e.Status)
					.HasName("status");

				entity.Property(e => e.Id)
					.HasColumnName("carmakeid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Ascid)
					.IsRequired()
					.HasColumnName("ascid")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasColumnName("carmake")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Letter)
					.IsRequired()
					.HasColumnName("litera")
					.HasColumnType("char(1)");

				entity.Property(e => e.NationalityKey)
					.IsRequired()
					.HasColumnName("nat")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Status)
					.HasColumnName("status")
					.HasDefaultValueSql("'0'");

				entity.HasOne(e => e.Nationality)
					.WithMany()
					.HasPrincipalKey(n => n.Key)
					.HasForeignKey(e => e.NationalityKey);
			});

			modelBuilder.Entity<F1cars>(entity =>
			{
				entity.HasKey(e => e.Carid);

				entity.ToTable("f1cars");

				entity.HasIndex(e => e.Car)
					.HasName("car");

				entity.HasIndex(e => e.Carmakeid)
					.HasName("carmakeid");

				entity.HasIndex(e => e.Litera)
					.HasName("litera");

				entity.Property(e => e.Carid)
					.HasColumnName("carid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Albumid)
					.HasColumnName("albumid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Car)
					.IsRequired()
					.HasColumnName("car")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Carmakeid)
					.HasColumnName("carmakeid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Launch1newsid)
					.HasColumnName("launch1newsid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Launch2newsid)
					.HasColumnName("launch2newsid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Litera)
					.IsRequired()
					.HasColumnName("litera")
					.HasColumnType("char(1)");
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

			modelBuilder.Entity<F1ConfigText>(entity =>
			{
				entity.ToTable("f1_config_text");

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

				entity.Property(e => e.Value)
					.HasColumnName("value")
					.HasColumnType("text");
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

			modelBuilder.Entity<ConstructorStandingsPosition>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.ToTable("f1constrcs");

				entity.HasIndex(e => e.ConstructorId)
					.HasName("carmakeid");

				entity.HasIndex(e => e.EngineMakeId)
					.HasName("enginemakeid");

				entity.HasIndex(e => e.SeasonId)
					.HasName("seasonid");

				entity.Property(e => e.Id)
					.HasColumnName("constrcsid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.ConstructorId)
					.HasColumnName("carmakeid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Position)
					.HasColumnName("cspos")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.EngineMakeId)
					.HasColumnName("enginemakeid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.SeasonId)
					.HasColumnName("seasonid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Points)
					.HasColumnName("points")
					.HasColumnType("double")
					.HasDefaultValueSql("'0'");

				entity.HasOne(e => e.Constructor)
					.WithMany(e => e.Positions);
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

			modelBuilder.Entity<DriverStandingsPosition>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.ToTable("f1drivercs");

				entity.HasIndex(e => e.DriverId)
					.HasName("driverid");

				entity.HasIndex(e => e.SeasonId)
					.HasName("seasonid");

				entity.Property(e => e.Id)
					.HasColumnName("drivercsid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Position)
					.HasColumnName("cspos")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.DriverId)
					.HasColumnName("driverid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.SeasonId)
					.HasColumnName("seasonid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Points)
					.HasColumnName("points")
					.HasColumnType("double")
					.HasDefaultValueSql("'0'");

				entity.HasOne(e => e.Driver)
					.WithMany(e => e.Positions);
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

			modelBuilder.Entity<Driver>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.ToTable("f1drivers");

				entity.HasIndex(e => e.Ascid)
					.HasName("ascid")
					.IsUnique();

				entity.HasIndex(e => e.Birthmd)
					.HasName("birthmd");

				entity.HasIndex(e => e.Deathmd)
					.HasName("deathmd");

				entity.HasIndex(e => e.Litera)
					.HasName("litera");

				entity.HasIndex(e => e.Surname)
					.HasName("surname");

				entity.HasIndex(e => e.Teamascid)
					.HasName("teamascid");

				entity.HasIndex(e => new { e.Group, e.Surname })
					.HasName("group");

				entity.Property(e => e.Id)
					.HasColumnName("driverid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Artid)
					.HasColumnName("artid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Ascid)
					.IsRequired()
					.HasColumnName("ascid")
					.HasMaxLength(4)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Birthmd)
					.HasColumnName("birthmd")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Birthplc)
					.IsRequired()
					.HasColumnName("birthplc")
					.HasMaxLength(64)
					.HasDefaultValueSql("'-'");

				entity.Property(e => e.Career)
					.IsRequired()
					.HasColumnName("career")
					.HasColumnType("text");

				entity.Property(e => e.Deathmd)
					.HasColumnName("deathmd")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Deathplc)
					.IsRequired()
					.HasColumnName("deathplc")
					.HasMaxLength(64)
					.HasDefaultValueSql("'-'");

				entity.Property(e => e.Debiut)
					.HasColumnName("debiut")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.FirstName)
					.IsRequired()
					.HasColumnName("forename")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Group)
					.HasColumnName("group")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Height)
					.IsRequired()
					.HasColumnName("height")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("'-'");

				entity.Property(e => e.Initial)
					.IsRequired()
					.HasColumnName("initial")
					.HasMaxLength(5)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Kids)
					.IsRequired()
					.HasColumnName("kids")
					.HasMaxLength(64)
					.HasDefaultValueSql("'-'");

				entity.Property(e => e.Litera)
					.IsRequired()
					.HasColumnName("litera")
					.HasColumnType("char(1)");

				entity.Property(e => e.NationalityKey)
					.IsRequired()
					.HasColumnName("nat")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Resides)
					.IsRequired()
					.HasColumnName("resides")
					.HasMaxLength(64)
					.HasDefaultValueSql("'-'");

				entity.Property(e => e.Status)
					.IsRequired()
					.HasColumnName("status")
					.HasMaxLength(64)
					.HasDefaultValueSql("'-'");

				entity.Property(e => e.Surname)
					.IsRequired()
					.HasColumnName("surname")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Teamascid)
					.IsRequired()
					.HasColumnName("teamascid")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Testdriver)
					.IsRequired()
					.HasColumnName("testdriver")
					.HasMaxLength(255)
					.HasDefaultValueSql("'-'");

				entity.Property(e => e.Titles)
					.IsRequired()
					.HasColumnName("titles")
					.HasMaxLength(255)
					.HasDefaultValueSql("'-'");

				entity.Property(e => e.Weight)
					.IsRequired()
					.HasColumnName("weight")
					.HasMaxLength(4)
					.HasDefaultValueSql("'-'");

				entity.HasOne(e => e.Nationality)
					.WithMany()
					.HasPrincipalKey(n => n.Key)
					.HasForeignKey(e => e.NationalityKey);
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

			modelBuilder.Entity<F1engines>(entity =>
			{
				entity.HasKey(e => e.Engineid);

				entity.ToTable("f1engines");

				entity.HasIndex(e => e.Engine)
					.HasName("engine");

				entity.HasIndex(e => e.Enginemakeid)
					.HasName("enginemakeid");

				entity.HasIndex(e => e.Litera)
					.HasName("litera");

				entity.Property(e => e.Engineid)
					.HasColumnName("engineid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Engine)
					.IsRequired()
					.HasColumnName("engine")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Enginemakeid)
					.HasColumnName("enginemakeid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Litera)
					.IsRequired()
					.HasColumnName("litera")
					.HasColumnType("char(1)");
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

			modelBuilder.Entity<Entry>(entity =>
			{
				entity.HasKey(e => e.Entryid);

				entity.ToTable("f1entries");

				entity.HasIndex(e => e.Carid)
					.HasName("carid");

				entity.HasIndex(e => e.Carmakeid)
					.HasName("carmakeid");

				entity.HasIndex(e => e.Driverid)
					.HasName("driverid");

				entity.HasIndex(e => e.Engineid)
					.HasName("engineid");

				entity.HasIndex(e => e.Enginemakeid)
					.HasName("enginemakeid");

				entity.HasIndex(e => e.Raceid)
					.HasName("raceid");

				entity.HasIndex(e => e.Teamid)
					.HasName("teamid");

				entity.HasIndex(e => e.Tyresid)
					.HasName("tyresid");

				entity.Property(e => e.Entryid)
					.HasColumnName("entryid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Carid)
					.HasColumnName("carid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Carmakeid)
					.HasColumnName("carmakeid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Driverid)
					.HasColumnName("driverid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Engineid)
					.HasColumnName("engineid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Enginemakeid)
					.HasColumnName("enginemakeid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Number)
					.HasColumnName("number")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Raceid)
					.HasColumnName("raceid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Teamid)
					.HasColumnName("teamid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Teamnameid)
					.HasColumnName("teamnameid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Thirddriver)
					.HasColumnName("thirddriver")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Tyresid)
					.HasColumnName("tyresid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<F1fastestlaps>(entity =>
			{
				entity.HasKey(e => e.Entryid);

				entity.ToTable("f1fastestlaps");

				entity.HasIndex(e => e.Frlpos)
					.HasName("frlpos");

				entity.HasIndex(e => e.Raceid)
					.HasName("raceid");

				entity.Property(e => e.Entryid)
					.HasColumnName("entryid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Frlpos)
					.IsRequired()
					.HasColumnName("frlpos")
					.HasColumnType("char(2)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Lap)
					.HasColumnName("lap")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Ord)
					.HasColumnName("ord")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Raceid)
					.HasColumnName("raceid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
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

			modelBuilder.Entity<Grid>(entity =>
			{
				entity.HasKey(e => e.EntryId);

				entity.ToTable("f1grids");

				entity.HasIndex(e => e.RaceId)
					.HasName("raceid");

				entity.HasIndex(e => e.StartingPosition)
					.HasName("startpos");

				entity.Property(e => e.EntryId)
					.HasColumnName("entryid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Ord)
					.HasColumnName("ord")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.RaceId)
					.HasColumnName("raceid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.StartingPosition)
					.IsRequired()
					.HasColumnName("startpos")
					.HasColumnType("char(2)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Time)
					.IsRequired()
					.HasColumnName("time")
					.HasColumnType("double")
					.HasDefaultValueSql("'0'")
					.HasConversion(
						v => v.TotalSeconds,
						v => TimeSpan.FromMilliseconds(v * 1000)
					);
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

			modelBuilder.Entity<Country>(entity =>
			{
				entity.HasKey(e => e.Key);

				entity.ToTable("f1nations");

				entity.HasIndex(e => e.Name)
					.HasName("nacja");

				entity.Property(e => e.Key)
					.HasColumnName("ascid")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Jezyk)
					.HasColumnName("jezyk")
					.HasMaxLength(20);

				entity.Property(e => e.Name)
					.IsRequired()
					.HasColumnName("nacja")
					.HasMaxLength(40)
					.HasDefaultValueSql("''");

				entity.Property(e => e.GenitiveName)
					.IsRequired()
					.HasColumnName("nacji")
					.HasMaxLength(40)
					.HasDefaultValueSql("''");
			});

			modelBuilder.Entity<News>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.ToTable("f1_news");

				entity.HasIndex(e => e.Date)
					.HasName("news_date");

				entity.HasIndex(e => e.NewsDateym)
					.HasName("news_dateym");

				entity.HasIndex(e => e.PosterName)
					.HasName("poster_name");

				entity.HasIndex(e => new { e.NewsHidden, e.Date })
					.HasName("hidden_date");

				entity.HasIndex(e => new { e.Title, e.Subtitle })
					.HasName("titles");

				entity.HasIndex(e => new { e.Type, e.Date })
					.HasName("news_type");

				entity.HasIndex(e => new { e.Type, e.NewsHidden, e.Date })
					.HasName("type_hidden_date");

				entity.Property(e => e.Id)
					.HasColumnName("news_id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.CommBlock)
					.HasColumnName("comm_block")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.CommentCount)
					.HasColumnName("comm_count")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Date)
					.HasColumnName("news_date")
					.HasColumnType("datetime")
					.HasDefaultValueSql("'0000-00-00 00:00:00'");

				entity.Property(e => e.NewsDateym)
					.HasColumnName("news_dateym")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.NewsHidden)
					.HasColumnName("news_hidden")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.NewsHighlight)
					.HasColumnName("news_highlight")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.NewsModified)
					.HasColumnName("news_modified")
					.HasColumnType("int(11)");

				entity.Property(e => e.Redirect)
					.HasColumnName("news_redirect")
					.HasMaxLength(50);

				entity.Property(e => e.Subtitle)
					.IsRequired()
					.HasColumnName("news_subtitle")
					.HasMaxLength(128);

				entity.Property(e => e.Text)
					.IsRequired()
					.HasColumnName("news_text")
					.HasColumnType("text");

				entity.Property(e => e.Title)
					.IsRequired()
					.HasColumnName("news_title")
					.HasMaxLength(80);

				entity.Property(e => e.Type)
					.HasColumnName("news_type")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Views)
					.HasColumnName("news_views")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.PosterId)
					.HasColumnName("poster_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.PosterName)
					.HasColumnName("poster_name")
					.HasMaxLength(30);

				entity.Property(e => e.TopicId)
					.HasColumnName("topic_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<F1NewsCats>(entity =>
			{
				entity.HasKey(e => e.CatId);

				entity.ToTable("f1_news_cats");

				entity.Property(e => e.CatId)
					.HasColumnName("cat_id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.CatTitle)
					.IsRequired()
					.HasColumnName("cat_title")
					.HasMaxLength(20)
					.HasDefaultValueSql("''");
			});

			modelBuilder.Entity<NewsComment>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.HasOne(e => e.Text)
					.WithOne(e => e.Comment)
					.HasForeignKey(typeof(NewsCommentText));

				entity.ToTable("f1_news_coms");

				entity.HasIndex(e => e.UnixTime)
					.HasName("comm_time");

				entity.HasIndex(e => e.NewsId)
					.HasName("news_id");

				entity.HasIndex(e => e.PosterId)
					.HasName("poster_id");

				entity.Property(e => e.Id)
					.HasColumnName("comm_id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Status)
					.HasColumnName("comm_status")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.UnixTime)
					.HasColumnName("comm_time")
					.HasColumnType("int(11)")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.NewsId)
					.HasColumnName("news_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.PosterId)
					.HasColumnName("poster_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.PosterIp)
					.IsRequired()
					.HasColumnName("poster_ip")
					.HasMaxLength(15)
					.HasDefaultValueSql("''");

				entity.Property(e => e.PosterName)
					.HasColumnName("poster_name")
					.HasMaxLength(25);
			});

			modelBuilder.Entity<NewsCommentText>(entity =>
			{
				entity.HasKey(e => e.CommId);

				entity.ToTable("f1_news_comstext");

				entity.Property(e => e.CommId)
					.HasColumnName("comm_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.CommText)
					.HasColumnName("comm_text")
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

			modelBuilder.Entity<F1newsgp>(entity =>
			{
				entity.HasKey(e => e.Raceid);

				entity.ToTable("f1newsgp");

				entity.HasIndex(e => e.Nr)
					.HasName("nr");

				entity.HasIndex(e => e.Rok)
					.HasName("rok");

				entity.Property(e => e.Raceid)
					.HasColumnName("raceid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Fl)
					.HasColumnName("fl")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Gal)
					.HasColumnName("gal")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Gp)
					.HasColumnName("gp")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.K1)
					.HasColumnName("k1")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.K1p)
					.HasColumnName("k1p")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.K2)
					.HasColumnName("k2")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Kk)
					.HasColumnName("kk")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Kpw)
					.HasColumnName("kpw")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Kw)
					.HasColumnName("kw")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Mw)
					.HasColumnName("mw")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Nr)
					.HasColumnName("nr")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Op)
					.HasColumnName("op")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Ow)
					.HasColumnName("ow")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Pk)
					.HasColumnName("pk")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Ps)
					.HasColumnName("ps")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Pt)
					.HasColumnName("pt")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Pw)
					.HasColumnName("pw")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Rok)
					.HasColumnName("rok")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.T1)
					.HasColumnName("t1")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.T12)
					.HasColumnName("t12")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.T2)
					.HasColumnName("t2")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.T3)
					.HasColumnName("t3")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.T34)
					.HasColumnName("t34")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.T4)
					.HasColumnName("t4")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Wbk)
					.HasColumnName("wbk")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Wk)
					.HasColumnName("wk")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Wt)
					.HasColumnName("wt")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Wu)
					.HasColumnName("wu")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Ww)
					.HasColumnName("ww")
					.HasColumnType("mediumint unsigned");
			});

			modelBuilder.Entity<F1NewsTopicmatch>(entity =>
			{
				entity.HasKey(e => e.MatchId);

				entity.ToTable("f1_news_topicmatch");

				entity.HasIndex(e => e.NewsId)
					.HasName("news_id");

				entity.HasIndex(e => new { e.TopicId, e.NewsDate })
					.HasName("topic_id");

				entity.Property(e => e.MatchId)
					.HasColumnName("match_id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.NewsDate)
					.HasColumnName("news_date")
					.HasColumnType("datetime");

				entity.Property(e => e.NewsId)
					.HasColumnName("news_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.TopicId)
					.HasColumnName("topic_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<NewsTopic>(entity =>
			{
				entity.HasKey(e => e.TopicId);

				entity.ToTable("f1_news_topics");

				entity.HasIndex(e => e.CatId)
					.HasName("cat_id");

				entity.HasIndex(e => e.Searches)
					.HasName("searches");

				entity.HasIndex(e => e.TopicTitle)
					.HasName("topic_title");

				entity.HasIndex(e => new { e.CatId, e.TopicTitle })
					.HasName("cat+title");

				entity.Property(e => e.TopicId)
					.HasColumnName("topic_id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.CatId)
					.HasColumnName("cat_id")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Searches)
					.HasColumnName("searches")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.TopicIcon)
					.HasColumnName("topic_icon")
					.HasMaxLength(20);

				entity.Property(e => e.TopicTitle)
					.IsRequired()
					.HasColumnName("topic_title")
					.HasMaxLength(25);
			});

			modelBuilder.Entity<F1NewsTypes>(entity =>
			{
				entity.HasKey(e => e.TypeId);

				entity.ToTable("f1_news_types");

				entity.Property(e => e.TypeId).HasColumnName("type_id");

				entity.Property(e => e.TypeTitle)
					.IsRequired()
					.HasColumnName("type_title")
					.HasMaxLength(45);

				entity.Property(e => e.TypeTitle2)
					.IsRequired()
					.HasColumnName("type_title2")
					.HasMaxLength(14);
			});

			modelBuilder.Entity<F1othersessions>(entity =>
			{
				entity.ToTable("f1othersessions");

				entity.HasIndex(e => e.Entryid)
					.HasName("entryid");

				entity.HasIndex(e => e.Raceid)
					.HasName("raceid");

				entity.HasIndex(e => e.Sespos)
					.HasName("sespos");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Entryid)
					.HasColumnName("entryid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Laps)
					.HasColumnName("laps")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Raceid)
					.HasColumnName("raceid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Sespos)
					.HasColumnName("sespos")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Session)
					.IsRequired()
					.HasColumnName("session")
					.HasColumnType("char(4)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Time)
					.HasColumnName("time")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<F1quals>(entity =>
			{
				entity.HasKey(e => e.Entryid);

				entity.ToTable("f1quals");

				entity.HasIndex(e => e.Raceid)
					.HasName("raceid");

				entity.Property(e => e.Entryid)
					.HasColumnName("entryid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Info)
					.IsRequired()
					.HasColumnName("info")
					.HasMaxLength(128)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Ord)
					.HasColumnName("ord")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Q1laps)
					.HasColumnName("q1laps")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Q1pos)
					.HasColumnName("q1pos")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Q2laps)
					.HasColumnName("q2laps")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Q2pos)
					.HasColumnName("q2pos")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Q3laps)
					.HasColumnName("q3laps")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Q3pos)
					.HasColumnName("q3pos")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Qualpos)
					.IsRequired()
					.HasColumnName("qualpos")
					.HasColumnType("char(2)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Raceid)
					.HasColumnName("raceid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
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

			modelBuilder.Entity<Race>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.ToTable("f1races");

				entity.HasIndex(e => e.Seasonid)
					.HasName("seasonid");

				entity.HasIndex(e => e.TrackId)
					.HasName("trackid");

				entity.HasIndex(e => e.Yearmonth)
					.HasName("yearmonth");

				entity.Property(e => e.Id)
					.HasColumnName("raceid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.CountryKey)
					.IsRequired()
					.HasColumnName("country")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Gridtype)
					.HasColumnName("gridtype")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Laps)
					.HasColumnName("laps")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasColumnName("name")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Numinseason)
					.HasColumnName("numinseason")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Offset)
					.HasColumnName("offset")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Qualtype)
					.HasColumnName("qualtype")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Seasonid)
					.HasColumnName("seasonid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.TrackId)
					.HasColumnName("trackid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Trackver)
					.HasColumnName("trackver")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Weather)
					.HasColumnName("weather")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Yearmonth)
					.IsRequired()
					.HasColumnName("yearmonth")
					.HasColumnType("char(6)");

				entity.Property(e => e.Date)
					.HasColumnName("date")
					.HasColumnType("date");
				
				entity.HasOne(e => e.Track)
					.WithMany()
					.HasPrincipalKey(t => t.Id)
					.HasForeignKey(e => e.TrackId);

				entity.HasOne(e => e.Country)
					.WithMany()
					.HasPrincipalKey(c => c.Key)
					.HasForeignKey(e => e.CountryKey);
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

			modelBuilder.Entity<Result>(entity =>
			{
				entity.HasKey(e => e.EntryId);

				entity.ToTable("f1results");

				entity.HasIndex(e => e.Endpos)
					.HasName("endpos");

				entity.HasIndex(e => e.Raceid)
					.HasName("raceid");

				entity.Property(e => e.EntryId)
					.HasColumnName("entryid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Endpos)
					.IsRequired()
					.HasColumnName("endpos")
					.HasColumnType("char(2)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Info)
					.IsRequired()
					.HasColumnName("info")
					.HasMaxLength(128)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Laps)
					.HasColumnName("laps")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Ord)
					.HasColumnName("ord")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Pits).HasColumnName("pits");

				entity.Property(e => e.Raceid)
					.HasColumnName("raceid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");
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

			modelBuilder.Entity<Season>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.ToTable("f1seasons");

				entity.HasIndex(e => e.Lastrace)
					.HasName("lastrace");

				entity.HasIndex(e => e.Races)
					.HasName("races");

				entity.HasIndex(e => e.Id)
					.HasName("seasonid")
					.IsUnique();

				entity.HasIndex(e => e.Year)
					.HasName("year");

				entity.Property(e => e.Id)
					.HasColumnName("seasonid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Carweight)
					.IsRequired()
					.HasColumnName("carweight")
					.HasMaxLength(255);

				entity.Property(e => e.Enginerules)
					.IsRequired()
					.HasColumnName("enginerules")
					.HasMaxLength(255);

				entity.Property(e => e.Lastrace)
					.HasColumnName("lastrace")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Newstyres)
					.HasColumnName("newstyres")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Pointssystem)
					.IsRequired()
					.HasColumnName("pointssystem")
					.HasMaxLength(255);

				entity.Property(e => e.Qualrules)
					.IsRequired()
					.HasColumnName("qualrules")
					.HasColumnType("text");

				entity.Property(e => e.Races)
					.HasColumnName("races")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Reviewarts)
					.IsRequired()
					.HasColumnName("reviewarts")
					.HasMaxLength(255);

				entity.Property(e => e.Reviewnews)
					.IsRequired()
					.HasColumnName("reviewnews")
					.HasMaxLength(255);

				entity.Property(e => e.Year)
					.HasColumnName("year")
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

			modelBuilder.Entity<F1teams>(entity =>
			{
				entity.HasKey(e => e.Teamid);

				entity.ToTable("f1teams");

				entity.HasIndex(e => e.Ascid)
					.HasName("ascid")
					.IsUnique();

				entity.HasIndex(e => e.Litera)
					.HasName("litera");

				entity.HasIndex(e => e.Status)
					.HasName("status");

				entity.HasIndex(e => e.Team)
					.HasName("team");

				entity.Property(e => e.Teamid)
					.HasColumnName("teamid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Artid)
					.HasColumnName("artid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Ascid)
					.IsRequired()
					.HasColumnName("ascid")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Base)
					.IsRequired()
					.HasColumnName("base")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Basedonteam)
					.IsRequired()
					.HasColumnName("basedonteam")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Carmakeid)
					.HasColumnName("carmakeid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Curboss)
					.IsRequired()
					.HasColumnName("curboss")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Curbosspic)
					.IsRequired()
					.HasColumnName("curbosspic")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Curengboss)
					.IsRequired()
					.HasColumnName("curengboss")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Curengbosspic)
					.IsRequired()
					.HasColumnName("curengbosspic")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Curtechdir)
					.IsRequired()
					.HasColumnName("curtechdir")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Curtechdirpic)
					.IsRequired()
					.HasColumnName("curtechdirpic")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Firstboss)
					.IsRequired()
					.HasColumnName("firstboss")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Firstbosspic)
					.IsRequired()
					.HasColumnName("firstbosspic")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Founder)
					.IsRequired()
					.HasColumnName("founder")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Founderpic)
					.IsRequired()
					.HasColumnName("founderpic")
					.HasMaxLength(45)
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

				entity.Property(e => e.Newstopicid)
					.HasColumnName("newstopicid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Otherboss)
					.IsRequired()
					.HasColumnName("otherboss")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Otherbossocc)
					.IsRequired()
					.HasColumnName("otherbossocc")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Otherbosspic)
					.IsRequired()
					.HasColumnName("otherbosspic")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Secondfactory)
					.IsRequired()
					.HasColumnName("secondfactory")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Status)
					.HasColumnName("status")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Team)
					.IsRequired()
					.HasColumnName("team")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Teamshort)
					.IsRequired()
					.HasColumnName("teamshort")
					.HasMaxLength(10);
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

			modelBuilder.Entity<Track>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.ToTable("f1tracks");

				entity.HasIndex(e => e.Ascid)
					.HasName("ascid")
					.IsUnique();

				entity.HasIndex(e => e.Status)
					.HasName("status");

				entity.HasIndex(e => e.ShortName)
					.HasName("track");

				entity.Property(e => e.Id)
					.HasColumnName("trackid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Artid)
					.HasColumnName("artid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Ascid)
					.IsRequired()
					.HasColumnName("ascid")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");

				entity.Property(e => e.City)
					.IsRequired()
					.HasColumnName("city")
					.HasMaxLength(45)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Country)
					.IsRequired()
					.HasColumnName("country")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Fiatrackmap)
					.HasColumnName("fiatrackmap")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasColumnName("fulltrackname")
					.HasMaxLength(50)
					.HasDefaultValueSql("''");

				entity.Property(e => e.LapDescr)
					.IsRequired()
					.HasColumnName("lap_descr")
					.HasColumnType("text");

				entity.Property(e => e.LapDriver)
					.IsRequired()
					.HasColumnName("lap_driver")
					.HasMaxLength(64);

				entity.Property(e => e.Length).HasColumnName("length");

				entity.Property(e => e.Longeststraight).HasColumnName("longeststraight");

				entity.Property(e => e.Newstopicid)
					.HasColumnName("newstopicid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Orgaddress)
					.IsRequired()
					.HasColumnName("orgaddress")
					.HasMaxLength(128)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Orgfax)
					.IsRequired()
					.HasColumnName("orgfax")
					.HasMaxLength(24)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Orgtel)
					.IsRequired()
					.HasColumnName("orgtel")
					.HasMaxLength(24)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Pitwindows1)
					.IsRequired()
					.HasColumnName("pitwindows1")
					.HasMaxLength(5)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Pitwindows2)
					.IsRequired()
					.HasColumnName("pitwindows2")
					.HasMaxLength(12)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Pitwindows3)
					.IsRequired()
					.HasColumnName("pitwindows3")
					.HasMaxLength(20)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Satmapcoords)
					.IsRequired()
					.HasColumnName("satmapcoords")
					.HasMaxLength(25)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Satmapzoom).HasColumnName("satmapzoom");

				entity.Property(e => e.Startlocal)
					.IsRequired()
					.HasColumnName("startlocal")
					.HasMaxLength(5)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Startpoland)
					.IsRequired()
					.HasColumnName("startpoland")
					.HasMaxLength(5)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Status)
					.HasColumnName("status")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.ShortName)
					.IsRequired()
					.HasColumnName("track")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Weatherurl)
					.IsRequired()
					.HasColumnName("weatherurl")
					.HasMaxLength(255);

				entity.Property(e => e.Width)
					.IsRequired()
					.HasColumnName("width")
					.HasMaxLength(10)
					.HasDefaultValueSql("''");

				entity.Property(e => e.Zipcode)
					.IsRequired()
					.HasColumnName("zipcode")
					.HasMaxLength(8);
			});

			modelBuilder.Entity<F1tyres>(entity =>
			{
				entity.HasKey(e => e.Tyresid);

				entity.ToTable("f1tyres");

				entity.HasIndex(e => e.Ascid)
					.HasName("ascid")
					.IsUnique();

				entity.HasIndex(e => e.Tyres)
					.HasName("tyres");

				entity.Property(e => e.Tyresid)
					.HasColumnName("tyresid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Ascid)
					.IsRequired()
					.HasColumnName("ascid")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Nat)
					.IsRequired()
					.HasColumnName("nat")
					.HasColumnType("char(3)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Status)
					.HasColumnName("status")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Tyres)
					.IsRequired()
					.HasColumnName("tyres")
					.HasMaxLength(64)
					.HasDefaultValueSql("''");
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

			modelBuilder.Entity<InneDodpktza>(entity =>
			{
				entity.ToTable("inne_dodpktza");

				entity.HasIndex(e => e.Opis)
					.HasName("opis");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Opis)
					.IsRequired()
					.HasColumnName("opis")
					.HasMaxLength(64);

				entity.Property(e => e.Ukryte)
					.HasColumnName("ukryte")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<InneImprezy>(entity =>
			{
				entity.ToTable("inne_imprezy");

				entity.HasIndex(e => e.Rokmies)
					.HasName("rokmies");

				entity.HasIndex(e => e.Seriaid)
					.HasName("seriaid");

				entity.HasIndex(e => e.Startgrupy)
					.HasName("startgrupy");

				entity.HasIndex(e => new { e.Sezon, e.Seriaid })
					.HasName("sezon");

				entity.HasIndex(e => new { e.Seriaid, e.Typ, e.Okrazenia })
					.HasName("seria+typ+okr");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Bezstats)
					.HasColumnName("bezstats")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Dlugtoru)
					.HasColumnName("dlugtoru")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Dzien)
					.IsRequired()
					.HasColumnName("dzien")
					.HasMaxLength(3);

				entity.Property(e => e.Galeriaurl)
					.IsRequired()
					.HasColumnName("galeriaurl")
					.HasMaxLength(150);

				entity.Property(e => e.Godzina)
					.IsRequired()
					.HasColumnName("godzina")
					.HasMaxLength(5);

				entity.Property(e => e.Kraj)
					.IsRequired()
					.HasColumnName("kraj")
					.HasMaxLength(3);

				entity.Property(e => e.Nazwa)
					.IsRequired()
					.HasColumnName("nazwa")
					.HasMaxLength(64);

				entity.Property(e => e.Newsid)
					.HasColumnName("newsid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Nrwsez).HasColumnName("nrwsez");

				entity.Property(e => e.Okrazenia)
					.HasColumnName("okrazenia")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Rokmies)
					.IsRequired()
					.HasColumnName("rokmies")
					.HasColumnType("char(6)");

				entity.Property(e => e.Seriaid)
					.HasColumnName("seriaid")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Sezon)
					.IsRequired()
					.HasColumnName("sezon")
					.HasMaxLength(9);

				entity.Property(e => e.Startgrupy)
					.HasColumnName("startgrupy")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Tor)
					.IsRequired()
					.HasColumnName("tor")
					.HasMaxLength(64);

				entity.Property(e => e.Typ)
					.HasColumnName("typ")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Typtoru)
					.HasColumnName("typtoru")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<InneKierowcy>(entity =>
			{
				entity.ToTable("inne_kierowcy");

				entity.HasIndex(e => e.F1ascid)
					.HasName("f1ascid");

				entity.HasIndex(e => e.Litera)
					.HasName("litera");

				entity.HasIndex(e => e.Nazwisko)
					.HasName("nazwisko");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.F1ascid)
					.IsRequired()
					.HasColumnName("f1ascid")
					.HasMaxLength(4);

				entity.Property(e => e.Imie)
					.IsRequired()
					.HasColumnName("imie")
					.HasMaxLength(64);

				entity.Property(e => e.Inicjal)
					.IsRequired()
					.HasColumnName("inicjal")
					.HasMaxLength(5);

				entity.Property(e => e.Kraj)
					.IsRequired()
					.HasColumnName("kraj")
					.HasMaxLength(3);

				entity.Property(e => e.Litera)
					.IsRequired()
					.HasColumnName("litera")
					.HasColumnType("char(1)");

				entity.Property(e => e.Nazwisko)
					.IsRequired()
					.HasColumnName("nazwisko")
					.HasMaxLength(64);

				entity.Property(e => e.Plec)
					.HasColumnName("plec")
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

			modelBuilder.Entity<InneListystart>(entity =>
			{
				entity.ToTable("inne_listystart");

				entity.HasIndex(e => e.Kierowcaid)
					.HasName("kierowcaid");

				entity.HasIndex(e => e.Nr)
					.HasName("nr");

				entity.HasIndex(e => e.Seriaid)
					.HasName("seriaid");

				entity.HasIndex(e => e.Sezon)
					.HasName("sezon");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Debiutant)
					.HasColumnName("debiutant")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Gosc)
					.HasColumnName("gosc")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Kierowcaid)
					.HasColumnName("kierowcaid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Klasa)
					.IsRequired()
					.HasColumnName("klasa")
					.HasColumnType("char(10)");

				entity.Property(e => e.Nieaktywny)
					.HasColumnName("nieaktywny")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Niezalezny)
					.HasColumnName("niezalezny")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Nr)
					.IsRequired()
					.HasColumnName("nr")
					.HasMaxLength(3)
					.HasDefaultValueSql("'-'");

				entity.Property(e => e.Opony)
					.IsRequired()
					.HasColumnName("opony")
					.HasMaxLength(3);

				entity.Property(e => e.Samochod)
					.IsRequired()
					.HasColumnName("samochod")
					.HasMaxLength(45);

				entity.Property(e => e.Seriaid)
					.HasColumnName("seriaid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Sezon)
					.IsRequired()
					.HasColumnName("sezon")
					.HasMaxLength(7);

				entity.Property(e => e.Zespol)
					.IsRequired()
					.HasColumnName("zespol")
					.HasMaxLength(45);

				entity.Property(e => e.Zespolwwyniku)
					.IsRequired()
					.HasColumnName("zespolwwyniku")
					.HasMaxLength(45);
			});

			modelBuilder.Entity<InneRezultaty>(entity =>
			{
				entity.ToTable("inne_rezultaty");

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

			modelBuilder.Entity<InneSerie>(entity =>
			{
				entity.ToTable("inne_serie");

				entity.HasIndex(e => e.Nazwa)
					.HasName("nazwa");

				entity.HasIndex(e => new { e.Status, e.Nazwa })
					.HasName("status");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.HasColumnType("mediumint unsigned");

				entity.Property(e => e.Domyslnysezon)
					.IsRequired()
					.HasColumnName("domyslnysezon")
					.HasMaxLength(9);

				entity.Property(e => e.Dzielonejazdy)
					.HasColumnName("dzielonejazdy")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Innepktdlazesp)
					.HasColumnName("innepktdlazesp")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Klaskieroficjalna)
					.HasColumnName("klaskieroficjalna")
					.HasDefaultValueSql("'1'");

				entity.Property(e => e.Klasy)
					.HasColumnName("klasy")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Klaszespoficjalna)
					.HasColumnName("klaszespoficjalna")
					.HasDefaultValueSql("'1'");

				entity.Property(e => e.Listastartwgnr)
					.HasColumnName("listastartwgnr")
					.HasDefaultValueSql("'1'");

				entity.Property(e => e.Nazwa)
					.IsRequired()
					.HasColumnName("nazwa")
					.HasMaxLength(45);

				entity.Property(e => e.Newscatid)
					.HasColumnName("newscatid")
					.HasColumnType("mediumint unsigned")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Punkty)
					.IsRequired()
					.HasColumnName("punkty")
					.HasMaxLength(128);

				entity.Property(e => e.Punkty2)
					.IsRequired()
					.HasColumnName("punkty2")
					.HasMaxLength(128);

				entity.Property(e => e.Skrotnazwy)
					.IsRequired()
					.HasColumnName("skrotnazwy")
					.HasMaxLength(20);

				entity.Property(e => e.Status)
					.HasColumnName("status")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Tylkonewsy)
					.HasColumnName("tylkonewsy")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Www)
					.IsRequired()
					.HasColumnName("www")
					.HasMaxLength(128);
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
