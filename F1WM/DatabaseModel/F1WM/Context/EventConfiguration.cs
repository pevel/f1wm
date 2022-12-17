//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class EventConfiguration : IEntityTypeConfiguration<Event>
	{
		public void Configure(EntityTypeBuilder<Event> builder)
		{
			builder.ToTable("inne_imprezy");

			builder.HasIndex(e => e.Rokmies)
				.HasDatabaseName("rokmies");

			builder.HasIndex(e => e.OtherSeriesId)
				.HasDatabaseName("seriaid");

			builder.HasIndex(e => e.Startgrupy)
				.HasDatabaseName("startgrupy");

			builder.HasIndex(e => new { e.Season, e.OtherSeriesId })
				.HasDatabaseName("sezon");

			builder.HasIndex(e => new { e.OtherSeriesId, e.Type, e.Laps })
				.HasDatabaseName("seria+typ+okr");

			builder.Property(e => e.Id)
				.HasColumnName("id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Bezstats)
				.HasColumnName("bezstats")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.TrackLength)
				.HasColumnName("dlugtoru")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Dzien)
				.IsRequired()
				.HasColumnName("dzien")
				.HasMaxLength(3);

			builder.Property(e => e.Galeriaurl)
				.IsRequired()
				.HasColumnName("galeriaurl")
				.HasMaxLength(150);

			builder.Property(e => e.Godzina)
				.IsRequired()
				.HasColumnName("godzina")
				.HasMaxLength(5);

			builder.Property(e => e.NationalityKey)
				.IsRequired()
				.HasColumnName("kraj")
				.HasMaxLength(3);

			builder.Property(e => e.Name)
				.IsRequired()
				.HasColumnName("nazwa")
				.HasMaxLength(64);

			builder.Property(e => e.NewsId)
				.HasColumnName("newsid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Nrwsez).HasColumnName("nrwsez");

			builder.Property(e => e.Laps)
				.HasColumnName("okrazenia")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Rokmies)
				.IsRequired()
				.HasColumnName("rokmies")
				.HasColumnType("char(6)");

			builder.Property(e => e.OtherSeriesId)
				.HasColumnName("seriaid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Season)
				.IsRequired()
				.HasColumnName("sezon")
				.HasMaxLength(9);

			builder.Property(e => e.Startgrupy)
				.HasColumnName("startgrupy")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.TrackName)
				.IsRequired()
				.HasColumnName("tor")
				.HasMaxLength(64);

			builder.Property(e => e.Type)
				.HasColumnName("typ")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Typtoru)
				.HasColumnName("typtoru")
				.HasDefaultValueSql("'0'");

			builder.HasOne(e => e.Series)
				.WithMany(s => s.Events)
				.HasPrincipalKey(s => s.Id)
				.HasForeignKey(e => e.OtherSeriesId);

			builder.HasOne(e => e.Nationality)
				.WithMany()
				.HasForeignKey(e => e.NationalityKey)
				.HasPrincipalKey(n => n.Key);
		}
	}
}
