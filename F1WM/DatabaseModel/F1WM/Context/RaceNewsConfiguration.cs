using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class RaceNewsConfiguration : IEntityTypeConfiguration<RaceNews>
	{
		public void Configure(EntityTypeBuilder<RaceNews> builder)
		{
			builder.HasKey(e => e.RaceId);

			builder.ToTable("f1newsgp");

			builder.HasIndex(e => e.Number)
				.HasDatabaseName("nr");

			builder.HasIndex(e => e.Year)
				.HasDatabaseName("rok");

			builder.Property(e => e.RaceId)
				.HasColumnName("raceid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.FastestLapsNewsId)
				.HasColumnName("fl")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.GalleryNewsId)
				.HasColumnName("gal")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Gp)
				.HasColumnName("gp")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.K1)
				.HasColumnName("k1")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.K1p)
				.HasColumnName("k1p")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.K2)
				.HasColumnName("k2")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.CommentsAfterQualifyingResultsNewsId)
				.HasColumnName("kk")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.PressConferenceNewsId)
				.HasColumnName("kpw")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.CommentsAfterRaceResultsNewsId)
				.HasColumnName("kw")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.ManeuversNewsId)
				.HasColumnName("mw")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Number)
				.HasColumnName("nr")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.TyresNewsId)
				.HasColumnName("op")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Id)
				.HasColumnName("ow")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.QualifyingNewsId)
				.HasColumnName("pk")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.PitStopsNewsId)
				.HasColumnName("ps")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Pt)
				.HasColumnName("pt")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Pw)
				.HasColumnName("pw")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Year)
				.HasColumnName("rok")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Training1NewsId)
				.HasColumnName("t1")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.T12)
				.HasColumnName("t12")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Training2NewsId)
				.HasColumnName("t2")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Training3NewsId)
				.HasColumnName("t3")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.T34)
				.HasColumnName("t34")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.T4)
				.HasColumnName("t4")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Wbk)
				.HasColumnName("wbk")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.CommentsAfterQualifyingNewsId)
				.HasColumnName("wk")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.CommentsAfterTrainingNewsId)
				.HasColumnName("wt")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Wu)
				.HasColumnName("wu")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.CommentsAfterRaceNewsId)
				.HasColumnName("ww")
				.HasColumnType("mediumint unsigned");
		}
	}
}
