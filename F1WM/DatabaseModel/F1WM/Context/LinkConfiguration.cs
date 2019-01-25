using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class LinkConfiguration : IEntityTypeConfiguration<Link>
	{
		public void Configure(EntityTypeBuilder<Link> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1_linki");

			builder.HasIndex(e => e.LCatgrp)
				.HasName("l_catgrp");

			builder.HasIndex(e => e.CategoryKey)
				.HasName("l_catstr");

			builder.HasIndex(e => e.LData)
				.HasName("l_data");

			builder.HasIndex(e => e.LNazwa)
				.HasName("l_nazwa");

			builder.HasIndex(e => e.LOcena)
				.HasName("l_ocena");

			builder.HasIndex(e => e.LOdslony)
				.HasName("l_odslony");

			builder.Property(e => e.Id)
				.HasColumnName("l_id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.LBanurl)
				.HasColumnName("l_banurl")
				.HasMaxLength(128);

			builder.Property(e => e.LCatgrp)
				.HasColumnName("l_catgrp")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.CategoryKey)
				.HasColumnName("l_catstr")
				.HasMaxLength(64);

			builder.Property(e => e.LData)
				.HasColumnName("l_data")
				.HasColumnType("datetime")
				.HasDefaultValueSql("'0000-00-00 00:00:00'");

			builder.Property(e => e.LJezyki)
				.HasColumnName("l_jezyki")
				.HasMaxLength(64);

			builder.Property(e => e.LNazwa)
				.IsRequired()
				.HasColumnName("l_nazwa")
				.HasMaxLength(255)
				.HasDefaultValueSql("''");

			builder.Property(e => e.LOcena)
				.HasColumnName("l_ocena")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.LOdslony)
				.HasColumnName("l_odslony")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.LOpis)
				.HasColumnName("l_opis")
				.HasMaxLength(255);

			builder.Property(e => e.LRotator)
				.HasColumnName("l_rotator")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Status)
				.HasColumnName("l_status")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Url)
				.IsRequired()
				.HasColumnName("l_url")
				.HasMaxLength(128)
				.HasDefaultValueSql("''");
		}
	}
}
