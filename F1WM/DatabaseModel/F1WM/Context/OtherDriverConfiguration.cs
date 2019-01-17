using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class OtherDriverConfiguration : IEntityTypeConfiguration<OtherDriver>
	{
		public void Configure(EntityTypeBuilder<OtherDriver> builder)
		{
			builder.ToTable("inne_kierowcy");

			builder.HasIndex(e => e.F1ascid)
				.HasName("f1ascid");

			builder.HasIndex(e => e.Litera)
				.HasName("litera");

			builder.HasIndex(e => e.Surname)
				.HasName("nazwisko");

			builder.Property(e => e.Id)
				.HasColumnName("id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.F1ascid)
				.IsRequired()
				.HasColumnName("f1ascid")
				.HasMaxLength(4);

			builder.Property(e => e.FirstName)
				.IsRequired()
				.HasColumnName("imie")
				.HasMaxLength(64);

			builder.Property(e => e.Initial)
				.IsRequired()
				.HasColumnName("inicjal")
				.HasMaxLength(5);

			builder.Property(e => e.NationalityKey)
				.IsRequired()
				.HasColumnName("kraj")
				.HasMaxLength(3);

			builder.Property(e => e.Litera)
				.IsRequired()
				.HasColumnName("litera")
				.HasColumnType("char(1)");

			builder.Property(e => e.Surname)
				.IsRequired()
				.HasColumnName("nazwisko")
				.HasMaxLength(64);

			builder.Property(e => e.Gender)
				.HasColumnName("plec")
				.HasDefaultValueSql("'0'");

			builder.HasOne(e => e.Nationality)
				.WithMany()
				.HasForeignKey(e => e.NationalityKey)
				.HasPrincipalKey(n => n.Key);
		}
	}
}
