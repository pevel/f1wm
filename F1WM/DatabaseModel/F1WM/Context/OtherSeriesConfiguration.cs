using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class OtherSeriesConfiguration : IEntityTypeConfiguration<OtherSeries>
	{
		public void Configure(EntityTypeBuilder<OtherSeries> builder)
		{
			builder.ToTable("inne_serie");

			builder.HasIndex(e => e.Name)
				.HasName("nazwa");

			builder.HasIndex(e => new { e.Status, e.Name })
				.HasName("status");

			builder.Property(e => e.Id)
				.HasColumnName("id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Domyslnysezon)
				.IsRequired()
				.HasColumnName("domyslnysezon")
				.HasMaxLength(9);

			builder.Property(e => e.Dzielonejazdy)
				.HasColumnName("dzielonejazdy")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Innepktdlazesp)
				.HasColumnName("innepktdlazesp")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Klaskieroficjalna)
				.HasColumnName("klaskieroficjalna")
				.HasDefaultValueSql("'1'");

			builder.Property(e => e.Klasy)
				.HasColumnName("klasy")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Klaszespoficjalna)
				.HasColumnName("klaszespoficjalna")
				.HasDefaultValueSql("'1'");

			builder.Property(e => e.Listastartwgnr)
				.HasColumnName("listastartwgnr")
				.HasDefaultValueSql("'1'");

			builder.Property(e => e.Name)
				.IsRequired()
				.HasColumnName("nazwa")
				.HasMaxLength(45);

			builder.Property(e => e.NewsCategoryId)
				.HasColumnName("newscatid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Punkty)
				.IsRequired()
				.HasColumnName("punkty")
				.HasMaxLength(128);

			builder.Property(e => e.Punkty2)
				.IsRequired()
				.HasColumnName("punkty2")
				.HasMaxLength(128);

			builder.Property(e => e.Skrotnazwy)
				.IsRequired()
				.HasColumnName("skrotnazwy")
				.HasMaxLength(20);

			builder.Property(e => e.Status)
				.HasColumnName("status")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Tylkonewsy)
				.HasColumnName("tylkonewsy")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Www)
				.IsRequired()
				.HasColumnName("www")
				.HasMaxLength(128);
		}
	}
}
