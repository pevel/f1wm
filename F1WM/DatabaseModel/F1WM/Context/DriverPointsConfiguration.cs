
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class DriverPointsConfiguration : IEntityTypeConfiguration<DriverPoints>
	{
		public void Configure(EntityTypeBuilder<DriverPoints> builder)
		{
			builder.ToTable("f1driverpoints");

			builder.HasIndex(e => e.DriverId)
				.HasName("driverid");

			builder.HasIndex(e => e.RaceId)
				.HasName("raceid");

			builder.HasIndex(e => e.SeasonId)
				.HasName("seasonid");

			builder.Property(e => e.Id)
				.HasColumnName("id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.DriverId)
				.HasColumnName("driverid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.RaceId)
				.HasColumnName("raceid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.SeasonId)
				.HasColumnName("seasonid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");
			
			builder.Property(e => e.Points)
				.HasColumnName("points")
				.HasColumnType("float");

			builder.Property(e => e.NotCountedTowardsChampionshipPoints)
				.HasColumnName("ncpoints")
				.HasColumnType("float");

			builder.HasOne(e => e.Entry)
				.WithOne()
				.HasForeignKey<DriverPoints>(e => new { e.DriverId, e.RaceId })
				.HasPrincipalKey<Entry>(e => new { e.DriverId, e.RaceId });
		}
	}
}
