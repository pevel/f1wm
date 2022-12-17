using F1WM.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class FastestLapConfiguration : IEntityTypeConfiguration<FastestLap>
	{
		public void Configure(EntityTypeBuilder<FastestLap> builder)
		{
			builder.HasKey(e => e.EntryId);

			builder.ToTable("f1fastestlaps");

			builder.HasIndex(e => e.PositionOrStatus)
				.HasDatabaseName("frlpos");

			builder.HasIndex(e => e.RaceId)
				.HasDatabaseName("raceid");

			builder.HasIndex(e => e.Time);

			builder.Property(e => e.EntryId)
				.HasColumnName("entryid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.PositionOrStatus)
				.IsRequired()
				.HasColumnName("frlpos")
				.HasColumnType("char(2)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.LapNumber)
				.HasColumnName("lap")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Order)
				.HasColumnName("ord")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.RaceId)
				.HasColumnName("raceid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Time)
				.HasColumnName("time")
				.HasColumnType("double")
				.HasDefaultValueSql("'0'")
				.HasTimeConversions();

			builder.HasOne(e => e.Race)
				.WithMany(r => r.FastestLaps)
				.HasPrincipalKey(e => e.Id)
				.HasForeignKey(f => f.RaceId);

			builder.HasOne(e => e.Entry)
				.WithOne(e => e.FastestLap)
				.HasForeignKey<FastestLap>(e => e.EntryId)
				.HasPrincipalKey<Entry>(e => e.Id);
		}
	}
}
