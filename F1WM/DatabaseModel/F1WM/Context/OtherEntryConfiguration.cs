using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class OtherEntryConfiguration : IEntityTypeConfiguration<OtherEntry>
	{
		public void Configure(EntityTypeBuilder<OtherEntry> builder)
		{
			builder.ToTable("inne_listystart");

			builder.HasIndex(e => e.OtherDriverId)
				.HasName("kierowcaid");

			builder.HasIndex(e => e.Number)
				.HasName("nr");

			builder.HasIndex(e => e.OtherSeriesId)
				.HasName("seriaid");

			builder.HasIndex(e => e.Season)
				.HasName("sezon");

			builder.Property(e => e.Id)
				.HasColumnName("id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Debut)
				.HasColumnName("debiutant")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Guest)
				.HasColumnName("gosc")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.OtherDriverId)
				.HasColumnName("kierowcaid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Class)
				.IsRequired()
				.HasColumnName("klasa")
				.HasColumnType("char(10)");

			builder.Property(e => e.Inactive)
				.HasColumnName("nieaktywny")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Independent)
				.HasColumnName("niezalezny")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Number)
				.IsRequired()
				.HasColumnName("nr")
				.HasMaxLength(3)
				.HasDefaultValueSql("'-'");

			builder.Property(e => e.Tyres)
				.IsRequired()
				.HasColumnName("opony")
				.HasMaxLength(3);

			builder.Property(e => e.CarName)
				.IsRequired()
				.HasColumnName("samochod")
				.HasMaxLength(45);

			builder.Property(e => e.OtherSeriesId)
				.HasColumnName("seriaid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Season)
				.IsRequired()
				.HasColumnName("sezon")
				.HasMaxLength(7);

			builder.Property(e => e.TeamName)
				.IsRequired()
				.HasColumnName("zespol")
				.HasMaxLength(45);
		}
	}
}
