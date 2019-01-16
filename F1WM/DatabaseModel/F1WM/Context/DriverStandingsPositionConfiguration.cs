using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class DriverStandingsPositionConfiguration : IEntityTypeConfiguration<DriverStandingsPosition>
	{
		public void Configure(EntityTypeBuilder<DriverStandingsPosition> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1drivercs");

			builder.HasIndex(e => e.DriverId)
				.HasName("driverid");

			builder.HasIndex(e => e.SeasonId)
				.HasName("seasonid");

			builder.Property(e => e.Id)
				.HasColumnName("drivercsid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Position)
				.HasColumnName("cspos")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.DriverId)
				.HasColumnName("driverid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.SeasonId)
				.HasColumnName("seasonid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Points)
				.HasColumnName("points")
				.HasColumnType("double")
				.HasDefaultValueSql("'0'");

			builder.HasOne(e => e.Driver)
				.WithMany(e => e.Positions);
		}
	}
}
