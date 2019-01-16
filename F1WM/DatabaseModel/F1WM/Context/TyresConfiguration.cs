using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class TyresConfiguration : IEntityTypeConfiguration<Tyres>
	{
		public void Configure(EntityTypeBuilder<Tyres> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1tyres");

			builder.HasIndex(e => e.Ascid)
				.HasName("ascid")
				.IsUnique();

			builder.HasIndex(e => e.Name)
				.HasName("tyres");

			builder.Property(e => e.Id)
				.HasColumnName("tyresid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Ascid)
				.IsRequired()
				.HasColumnName("ascid")
				.HasColumnType("char(3)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Nat)
				.IsRequired()
				.HasColumnName("nat")
				.HasColumnType("char(3)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Status)
				.HasColumnName("status")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Name)
				.IsRequired()
				.HasColumnName("tyres")
				.HasMaxLength(64)
				.HasDefaultValueSql("''");
		}
	}
}
