using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class ConfigSectionConfiguration : IEntityTypeConfiguration<ConfigSection>
	{
		public void Configure(EntityTypeBuilder<ConfigSection> builder)
		{
			builder.ToTable("f1_config_sections");

			builder.Property(e => e.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder.Property(e => e.Name)
				.IsRequired()
				.HasColumnName("name")
				.HasMaxLength(45);
		}
	}
}
