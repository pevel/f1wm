using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class TrackConfiguration : IEntityTypeConfiguration<Track>
	{
		public void Configure(EntityTypeBuilder<Track> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1tracks");

			builder.HasIndex(e => e.Ascid)
				.HasName("ascid")
				.IsUnique();

			builder.HasIndex(e => e.Status)
				.HasName("status");

			builder.HasIndex(e => e.ShortName)
				.HasName("track");

			builder.Property(e => e.Id)
				.HasColumnName("trackid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Artid)
				.HasColumnName("artid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Ascid)
				.IsRequired()
				.HasColumnName("ascid")
				.HasMaxLength(64)
				.HasDefaultValueSql("''");

			builder.Property(e => e.City)
				.IsRequired()
				.HasColumnName("city")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.NationalityKey)
				.IsRequired()
				.HasColumnName("country")
				.HasColumnType("char(3)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Fiatrackmap)
				.HasColumnName("fiatrackmap");

			builder.Property(e => e.Name)
				.IsRequired()
				.HasColumnName("fulltrackname")
				.HasMaxLength(50)
				.HasDefaultValueSql("''");

			builder.Property(e => e.LapDescr)
				.IsRequired()
				.HasColumnName("lap_descr")
				.HasColumnType("text");

			builder.Property(e => e.LapDriver)
				.IsRequired()
				.HasColumnName("lap_driver")
				.HasMaxLength(64);

			builder.Property(e => e.Length).HasColumnName("length");

			builder.Property(e => e.Longeststraight).HasColumnName("longeststraight");

			builder.Property(e => e.Newstopicid)
				.HasColumnName("newstopicid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Orgaddress)
				.IsRequired()
				.HasColumnName("orgaddress")
				.HasMaxLength(128)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Orgfax)
				.IsRequired()
				.HasColumnName("orgfax")
				.HasMaxLength(24)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Orgtel)
				.IsRequired()
				.HasColumnName("orgtel")
				.HasMaxLength(24)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Pitwindows1)
				.IsRequired()
				.HasColumnName("pitwindows1")
				.HasMaxLength(5)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Pitwindows2)
				.IsRequired()
				.HasColumnName("pitwindows2")
				.HasMaxLength(12)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Pitwindows3)
				.IsRequired()
				.HasColumnName("pitwindows3")
				.HasMaxLength(20)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Satmapcoords)
				.IsRequired()
				.HasColumnName("satmapcoords")
				.HasMaxLength(25)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Satmapzoom).HasColumnName("satmapzoom");

			builder.Property(e => e.Startlocal)
				.IsRequired()
				.HasColumnName("startlocal")
				.HasMaxLength(5)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Startpoland)
				.IsRequired()
				.HasColumnName("startpoland")
				.HasMaxLength(5)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Status)
				.HasColumnName("status");

			builder.Property(e => e.ShortName)
				.IsRequired()
				.HasColumnName("track")
				.HasMaxLength(64)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Weatherurl)
				.IsRequired()
				.HasColumnName("weatherurl")
				.HasMaxLength(255);

			builder.Property(e => e.Width)
				.IsRequired()
				.HasColumnName("width")
				.HasMaxLength(10)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Zipcode)
				.IsRequired()
				.HasColumnName("zipcode")
				.HasMaxLength(8);

			builder.HasOne(e => e.Nationality)
				.WithMany()
				.HasForeignKey(e => e.NationalityKey)
				.HasPrincipalKey(n => n.Key);
		}
	}
}
