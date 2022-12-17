using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class OtherAdditionalPointsReasonConfiguration : IEntityTypeConfiguration<OtherAdditionalPointsReason>
	{
		public void Configure(EntityTypeBuilder<OtherAdditionalPointsReason> builder)
		{
			builder.ToTable("inne_dodpktza");

			builder.HasIndex(e => e.Description)
				.HasDatabaseName("opis");

			builder.Property(e => e.Id).HasColumnName("id");

			builder.Property(e => e.Description)
				.IsRequired()
				.HasColumnName("opis")
				.HasMaxLength(64);

			builder.Property(e => e.IsHidden)
				.HasColumnName("ukryte");
		}
	}
}
