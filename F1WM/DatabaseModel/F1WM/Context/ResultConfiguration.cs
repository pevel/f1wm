using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class ResultConfiguration : IEntityTypeConfiguration<Result>
	{
		public void Configure(EntityTypeBuilder<Result> builder)
		{
			builder.HasKey(e => e.EntryId);

			builder.ToTable("f1results");

			builder.Ignore(e => e.FinishPosition);

			builder.Ignore(e => e.Status);

			builder.HasIndex(e => e.PositionOrStatus)
				.HasName("endpos");

			builder.HasIndex(e => e.RaceId)
				.HasName("raceid");

			builder.HasIndex(e => e.Time);

			builder.Property(e => e.EntryId)
				.HasColumnName("entryid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.PositionOrStatus)
				.IsRequired()
				.HasColumnName("endpos")
				.HasColumnType("char(2)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Information)
				.IsRequired()
				.HasColumnName("info")
				.HasMaxLength(128)
				.HasDefaultValueSql("''");

			builder.Property(e => e.FinishedLaps)
				.HasColumnName("laps")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Ord)
				.HasColumnName("ord")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.PitStopVisits).HasColumnName("pits");

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
				.WithMany(r => r.Results)
				.HasPrincipalKey(r => r.Id)
				.HasForeignKey(e => e.RaceId);

			builder.HasOne(e => e.Entry)
				.WithOne(e => e.Result)
				.HasPrincipalKey<Entry>(e => e.Id)
				.HasForeignKey<Result>(e => e.EntryId);
		}
	}
}
