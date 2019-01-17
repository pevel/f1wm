using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class CountryConfiguration : IEntityTypeConfiguration<Country>
	{
		public void Configure(EntityTypeBuilder<Country> builder)
		{
			builder.HasKey(e => e.Key);

			builder.ToTable("f1nations");

			builder.HasIndex(e => e.Name)
				.HasName("nacja");

			builder.Property(e => e.Key)
				.HasColumnName("ascid")
				.HasColumnType("char(3)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Jezyk)
				.HasColumnName("jezyk")
				.HasMaxLength(20);

			builder.Property(e => e.Name)
				.IsRequired()
				.HasColumnName("nacja")
				.HasMaxLength(40)
				.HasDefaultValueSql("''");

			builder.Property(e => e.GenitiveName)
				.IsRequired()
				.HasColumnName("nacji")
				.HasMaxLength(40)
				.HasDefaultValueSql("''");
		}
	}
}
