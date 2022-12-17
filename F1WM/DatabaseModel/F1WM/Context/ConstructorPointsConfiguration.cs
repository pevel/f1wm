using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class ConstructorPointsConfiguration : IEntityTypeConfiguration<ConstructorPoints>
	{
		public void Configure(EntityTypeBuilder<ConstructorPoints> builder)
		{
			builder.ToTable("f1constrpoints");

			builder.HasIndex(e => e.ConstructorId)
				.HasDatabaseName("carmakeid");

			builder.HasIndex(e => e.EngineMakeId)
				.HasDatabaseName("enginemakeid");

			builder.HasIndex(e => e.RaceId)
				.HasDatabaseName("raceid");

			builder.HasIndex(e => e.SeasonId)
				.HasDatabaseName("seasonid");

			builder.Property(e => e.Id)
				.HasColumnName("id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.ConstructorId)
				.HasColumnName("carmakeid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.EngineMakeId)
				.HasColumnName("enginemakeid")
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
				.HasColumnType("double");

			builder.Property(e => e.NotCountedTowardsChampionshipPoints)
				.HasColumnName("ncpoints")
				.HasColumnType("double");
		}
	}
}
