using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class ConstructorConfiguration : IEntityTypeConfiguration<Constructor>
	{
		public void Configure(EntityTypeBuilder<Constructor> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1carmakes");

			builder.HasIndex(e => e.Ascid)
				.HasName("ascid")
				.IsUnique();

			builder.HasIndex(e => e.Name)
				.HasName("carmake");

			builder.HasIndex(e => e.Letter)
				.HasName("litera");

			builder.HasIndex(e => e.Status)
				.HasName("status");

			builder.Property(e => e.Id)
				.HasColumnName("carmakeid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Ascid)
				.IsRequired()
				.HasColumnName("ascid")
				.HasColumnType("char(3)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Name)
				.IsRequired()
				.HasColumnName("carmake")
				.HasMaxLength(64)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Letter)
				.IsRequired()
				.HasColumnName("litera")
				.HasColumnType("char(1)");

			builder.Property(e => e.NationalityKey)
				.IsRequired()
				.HasColumnName("nat")
				.HasColumnType("char(3)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Status)
				.HasColumnName("status")
				.IsRequired()
				.HasDefaultValueSql("'0'");

			builder.HasOne(e => e.Nationality)
				.WithMany()
				.HasPrincipalKey(n => n.Key)
				.HasForeignKey(e => e.NationalityKey);
		}
	}
}
