using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class GridConfiguration : IEntityTypeConfiguration<Grid>
	{
		public void Configure(EntityTypeBuilder<Grid> builder)
		{
			builder.HasKey(e => e.EntryId);

			builder.ToTable("f1grids");

			builder.Ignore(e => e.StartPosition);

			builder.Ignore(e => e.StartStatus);

			builder.HasIndex(e => e.RaceId)
				.HasName("raceid");

			builder.HasIndex(e => e.StartPositionOrStatus)
				.HasName("startpos");

			builder.HasIndex(e => e.Time);

			builder.Property(e => e.EntryId)
				.HasColumnName("entryid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Ord)
				.HasColumnName("ord")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.RaceId)
				.HasColumnName("raceid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.StartPositionOrStatus)
				.IsRequired()
				.HasColumnName("startpos")
				.HasColumnType("char(2)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Time)
				.IsRequired()
				.HasColumnName("time")
				.HasColumnType("double")
				.HasDefaultValueSql("'0'")
				.HasTimeConversions();

			builder.HasOne(e => e.Race)
				.WithMany(r => r.Grids)
				.HasPrincipalKey(r => r.Id)
				.HasForeignKey(e => e.RaceId);

			builder.HasOne(e => e.Entry)
				.WithOne(e => e.Grid)
				.HasPrincipalKey<Entry>(e => e.Id)
				.HasForeignKey<Grid>(e => e.EntryId);
		}
	}
}
