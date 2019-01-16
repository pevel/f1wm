using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class QualifyingConfiguration : IEntityTypeConfiguration<Qualifying>
	{
		public void Configure(EntityTypeBuilder<Qualifying> builder)
		{
			builder.HasKey(e => e.EntryId);

			builder.ToTable("f1quals");

			builder.Ignore(e => e.FinishPosition);

			builder.Ignore(e => e.Status);

			builder.HasIndex(e => e.RaceId)
				.HasName("raceid");

			builder.Property(e => e.EntryId)
				.HasColumnName("entryid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Information)
				.IsRequired()
				.HasColumnName("info")
				.HasMaxLength(128)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Ord)
				.HasColumnName("ord")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Session1Laps)
				.HasColumnName("q1laps")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Session1Position)
				.HasColumnName("q1pos")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Session1Time)
				.HasColumnName("q1time")
				.HasTimeConversions();

			builder.Property(e => e.Session2Laps)
				.HasColumnName("q2laps")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Session2Position)
				.HasColumnName("q2pos")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Session2Time)
				.HasColumnName("q2time")
				.HasTimeConversions();

			builder.Property(e => e.Session3Laps)
				.HasColumnName("q3laps")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Session3Position)
				.HasColumnName("q3pos")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Session3Time)
				.HasColumnName("q3time")
				.HasTimeConversions();

			builder.Property(e => e.PositionOrStatus)
				.IsRequired()
				.HasColumnName("qualpos")
				.HasColumnType("char(2)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.RaceId)
				.HasColumnName("raceid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.HasOne(e => e.Race)
				.WithMany(r => r.Qualifying)
				.HasForeignKey(e => e.RaceId)
				.HasPrincipalKey(r => r.Id);
			
			builder.HasOne(e => e.Entry)
				.WithOne(e => e.Qualifying)
				.HasForeignKey<Qualifying>(e => e.EntryId)
				.HasPrincipalKey<Entry>(e => e.Id);
		}
	}
}
