using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class ConstructorStandingsPositionConfiguration : IEntityTypeConfiguration<ConstructorStandingsPosition>
	{
		public void Configure(EntityTypeBuilder<ConstructorStandingsPosition> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1constrcs");

			builder.HasIndex(e => e.ConstructorId)
				.HasDatabaseName("carmakeid");

			builder.HasIndex(e => e.EngineMakeId)
				.HasDatabaseName("enginemakeid");

			builder.HasIndex(e => e.SeasonId)
				.HasDatabaseName("seasonid");

			builder.HasIndex(e => e.Position);

			builder.Property(e => e.Id)
				.HasColumnName("constrcsid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.ConstructorId)
				.HasColumnName("carmakeid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Position)
				.HasColumnName("cspos")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.EngineMakeId)
				.HasColumnName("enginemakeid")
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

			builder.HasOne(e => e.Constructor)
				.WithMany(c => c.Positions)
				.HasForeignKey(e => e.ConstructorId)
				.HasPrincipalKey(c => c.Id);

			builder.HasOne(e => e.Season)
				.WithMany(s => s.ConstructorStandings)
				.HasForeignKey(e => e.SeasonId)
				.HasPrincipalKey(s => s.Id);
		}
	}
}
