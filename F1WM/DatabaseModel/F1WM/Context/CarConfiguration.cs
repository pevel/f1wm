using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class CarConfiguration : IEntityTypeConfiguration<Car>
	{
		public void Configure(EntityTypeBuilder<Car> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1cars");

			builder.HasIndex(e => e.Name)
				.HasDatabaseName("car");

			builder.HasIndex(e => e.ContstructorId)
				.HasDatabaseName("carmakeid");

			builder.HasIndex(e => e.Litera)
				.HasDatabaseName("litera");

			builder.Property(e => e.Id)
				.HasColumnName("carid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Albumid)
				.HasColumnName("albumid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Name)
				.IsRequired()
				.HasColumnName("car")
				.HasMaxLength(64)
				.HasDefaultValueSql("''");

			builder.Property(e => e.ContstructorId)
				.HasColumnName("carmakeid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Launch1newsid)
				.HasColumnName("launch1newsid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Launch2newsid)
				.HasColumnName("launch2newsid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Litera)
				.IsRequired()
				.HasColumnName("litera")
				.HasColumnType("char(1)");

			builder.HasOne(e => e.Constructor)
				.WithMany(c => c.Cars)
				.HasForeignKey(e => e.ContstructorId)
				.HasPrincipalKey(c => c.Id);
		}
	}
}
