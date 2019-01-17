using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class ConfigTextConfiguration : IEntityTypeConfiguration<ConfigText>
	{
		public void Configure(EntityTypeBuilder<ConfigText> builder)
		{
			builder.ToTable("f1_config_text");

			builder.HasIndex(e => e.Name)
				.HasName("name");

			builder.HasIndex(e => e.Section)
				.HasName("section");

			builder.Property(e => e.Id)
				.HasColumnName("id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Description)
				.IsRequired()
				.HasColumnName("description")
				.HasColumnType("text");

			builder.Property(e => e.Name)
				.IsRequired()
				.HasColumnName("name")
				.HasMaxLength(45);

			builder.Property(e => e.Section)
				.HasColumnName("section")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Value)
				.HasColumnName("value")
				.HasColumnType("text");
		}
	}
}
