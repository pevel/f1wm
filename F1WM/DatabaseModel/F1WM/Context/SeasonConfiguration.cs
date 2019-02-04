using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class SeasonConfiguration : IEntityTypeConfiguration<Season>
	{
		public void Configure(EntityTypeBuilder<Season> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1seasons");

			builder.HasIndex(e => e.Lastrace)
				.HasName("lastrace");

			builder.HasIndex(e => e.RaceCount)
				.HasName("races");

			builder.HasIndex(e => e.Id)
				.HasName("seasonid")
				.IsUnique();

			builder.HasIndex(e => e.Year)
				.HasName("year");

			builder.Property(e => e.Id)
				.HasColumnName("seasonid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.CarWeight)
				.IsRequired()
				.HasColumnName("carweight")
				.HasMaxLength(255);

			builder.Property(e => e.EngineRules)
				.IsRequired()
				.HasColumnName("enginerules")
				.HasMaxLength(255);

			builder.Property(e => e.Lastrace)
				.HasColumnName("lastrace")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Newstyres)
				.HasColumnName("newstyres")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.PointsSystem)
				.IsRequired()
				.HasColumnName("pointssystem")
				.HasMaxLength(255);

			builder.Property(e => e.QualifyingRules)
				.IsRequired()
				.HasColumnName("qualrules")
				.HasColumnType("text");

			builder.Property(e => e.RaceCount)
				.HasColumnName("races")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Reviewarts)
				.IsRequired()
				.HasColumnName("reviewarts")
				.HasMaxLength(255);

			builder.Property(e => e.Reviewnews)
				.IsRequired()
				.HasColumnName("reviewnews")
				.HasMaxLength(255);

			builder.Property(e => e.Year)
				.HasColumnName("year")
				.HasDefaultValueSql("'0'");
		}
	}
}
