using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class RaceConfiguration : IEntityTypeConfiguration<Race>
	{
		public void Configure(EntityTypeBuilder<Race> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1races");

			builder.HasIndex(e => e.SeasonId)
				.HasName("seasonid");

			builder.HasIndex(e => e.TrackId)
				.HasName("trackid");

			builder.HasIndex(e => e.Yearmonth)
				.HasName("yearmonth");

			builder.HasIndex(e => e.Date);

			builder.Property(e => e.Id)
				.HasColumnName("raceid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.CountryKey)
				.IsRequired()
				.HasColumnName("country")
				.HasColumnType("char(3)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Gridtype)
				.HasColumnName("gridtype")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Laps)
				.HasColumnName("laps")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Name)
				.IsRequired()
				.HasColumnName("name")
				.HasMaxLength(64)
				.HasDefaultValueSql("''");

			builder.Property(e => e.OrderInSeason)
				.HasColumnName("numinseason")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Distance)
				.HasColumnName("distance")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Offset)
				.HasColumnName("offset")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Qualtype)
				.HasColumnName("qualtype")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.SeasonId)
				.HasColumnName("seasonid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.TrackId)
				.HasColumnName("trackid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.TrackVersion)
				.HasColumnName("trackver");

			builder.Property(e => e.Weather)
				.HasColumnName("weather");

			builder.Property(e => e.Yearmonth)
				.IsRequired()
				.HasColumnName("yearmonth")
				.HasColumnType("char(6)");

			builder.Property(e => e.Date)
				.HasColumnName("date")
				.HasColumnType("date");

			builder.HasOne(e => e.Track)
				.WithMany(t => t.Races)
				.HasPrincipalKey(t => t.Id)
				.HasForeignKey(e => e.TrackId);

			builder.HasOne(e => e.Country)
				.WithMany()
				.HasPrincipalKey(c => c.Key)
				.HasForeignKey(e => e.CountryKey);

			builder.HasOne(e => e.RaceNews)
				.WithOne(n => n.Race)
				.HasForeignKey<RaceNews>(n => n.RaceId)
				.HasPrincipalKey<Race>(e => e.Id);
		}
	}
}
