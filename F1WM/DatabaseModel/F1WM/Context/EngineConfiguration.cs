using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class EngineConfiguration : IEntityTypeConfiguration<Engine>
	{
		public void Configure(EntityTypeBuilder<Engine> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1engines");

			builder.HasIndex(e => e.Name)
				.HasDatabaseName("engine");

			builder.HasIndex(e => e.EngineMakeId)
				.HasDatabaseName("enginemakeid");

			builder.HasIndex(e => e.Letter)
				.HasDatabaseName("litera");

			builder.Property(e => e.Id)
				.HasColumnName("engineid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Name)
				.IsRequired()
				.HasColumnName("engine")
				.HasMaxLength(64)
				.HasDefaultValueSql("''");

			builder.Property(e => e.EngineMakeId)
				.HasColumnName("enginemakeid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Letter)
				.IsRequired()
				.HasColumnName("litera")
				.HasColumnType("char(1)");
		}
	}
}
