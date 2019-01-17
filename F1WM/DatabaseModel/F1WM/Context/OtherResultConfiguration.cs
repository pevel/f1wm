using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class OtherResultConfiguration : IEntityTypeConfiguration<OtherResult>
	{
		public void Configure(EntityTypeBuilder<OtherResult> builder)
		{
			builder.ToTable("inne_rezultaty");

			builder.HasIndex(e => e.EventId)
				.HasName("imprezaid");

			builder.HasIndex(e => e.FinishPosition)
				.HasName("pozycja");

			builder.HasIndex(e => e.OtherEntryId)
				.HasName("zgloszenieid");

			builder.Property(e => e.Id)
				.HasColumnName("id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Time)
				.HasColumnName("czas")
				.HasTimeConversions();

			builder.Property(e => e.OtherAdditionalPointsReasonId)
				.HasColumnName("dodpktza")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.EventId)
				.HasColumnName("imprezaid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.FinishedLaps).HasColumnName("okrazenia");

			builder.Property(e => e.Pozklasa)
				.HasColumnName("pozklasa")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.FinishPosition).HasColumnName("pozycja");

			builder.Property(e => e.Points)
				.HasColumnName("punkty")
				.HasColumnType("float")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Status)
				.IsRequired()
				.HasColumnName("status")
				.HasColumnType("char(2)");

			builder.Property(e => e.OtherEntryId)
				.HasColumnName("zgloszenieid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.HasOne(e => e.AdditionalPointsReason)
				.WithMany()
				.HasPrincipalKey(a => a.Id)
				.HasForeignKey(e => e.OtherAdditionalPointsReasonId);

			builder.HasOne(e => e.Event)
				.WithMany(e => e.Results)
				.HasForeignKey(r => r.EventId)
				.HasPrincipalKey(e => e.Id);
		}
	}
}
