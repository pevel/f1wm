using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class EngineSpecificationConfiguration : IEntityTypeConfiguration<EngineSpecification>
	{
		public void Configure(EntityTypeBuilder<EngineSpecification> builder)
		{
			builder.HasKey(e => e.EngineId);

			builder.ToTable("f1enginesspecs");

			builder.Property(e => e.EngineId)
				.HasColumnName("engineid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Text)
				.HasColumnName("enginespecs")
				.HasColumnType("text");
		}
	}
}
