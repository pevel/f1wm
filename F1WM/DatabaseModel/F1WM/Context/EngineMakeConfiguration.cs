using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class EngineMakeConfiguration : IEntityTypeConfiguration<EngineMake>
	{
		public void Configure(EntityTypeBuilder<EngineMake> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1enginemakes");

			builder.HasIndex(e => e.Key)
				.HasName("ascid")
				.IsUnique();

			builder.HasIndex(e => e.Name)
				.HasName("enginemake");

			builder.HasIndex(e => e.Letter)
				.HasName("litera");

			builder.HasIndex(e => e.Status)
				.HasName("status");

			builder.Property(e => e.Id)
				.HasColumnName("enginemakeid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Key)
				.IsRequired()
				.HasColumnName("ascid")
				.HasColumnType("char(3)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Name)
				.IsRequired()
				.HasColumnName("enginemake")
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
				.HasDefaultValueSql("'0'");

			builder.HasOne(e => e.Country)
				.WithMany()
				.HasForeignKey(e => e.NationalityKey)
				.HasPrincipalKey(n => n.Key);
		}
	}
}
