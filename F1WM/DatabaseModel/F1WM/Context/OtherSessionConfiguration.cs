using F1WM.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class OtherSessionConfiguration : IEntityTypeConfiguration<OtherSession>
	{
		public void Configure(EntityTypeBuilder<OtherSession> builder)
		{
			builder.ToTable("f1othersessions");

			builder.HasIndex(e => e.EntryId)
				.HasDatabaseName("entryid");

			builder.HasIndex(e => e.RaceId)
				.HasDatabaseName("raceid");

			builder.HasIndex(e => e.FinishPosition)
				.HasDatabaseName("sespos");

			builder.Property(e => e.Id)
				.HasColumnName("id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.EntryId)
				.HasColumnName("entryid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.FinishedLaps)
				.HasColumnName("laps")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.RaceId)
				.HasColumnName("raceid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.FinishPosition)
				.HasColumnName("sespos")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Session)
				.IsRequired()
				.HasColumnName("session")
				.HasColumnType("char(4)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Time)
				.HasColumnName("time")
				.HasColumnType("double")
				.HasTimeConversions();

			builder.HasOne(e => e.Race)
				.WithMany()
				.HasForeignKey(e => e.RaceId)
				.HasPrincipalKey(r => r.Id);
		}
	}
}
