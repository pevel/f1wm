using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class DriverConfiguration : IEntityTypeConfiguration<Driver>
	{
		public void Configure(EntityTypeBuilder<Driver> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1drivers");

			builder.HasIndex(e => e.Key)
				.HasName("ascid")
				.IsUnique();

			builder.HasIndex(e => e.Birthmd)
				.HasName("birthmd");

			builder.HasIndex(e => e.Deathmd)
				.HasName("deathmd");

			builder.HasIndex(e => e.Litera)
				.HasName("litera");

			builder.HasIndex(e => e.Surname)
				.HasName("surname");

			builder.HasIndex(e => e.TeamKey)
				.HasName("teamascid");

			builder.HasIndex(e => new { e.Group, e.Surname })
				.HasName("group");

			builder.Property(e => e.Id)
				.HasColumnName("driverid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Artid)
				.HasColumnName("artid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Key)
				.IsRequired()
				.HasColumnName("ascid")
				.HasMaxLength(4)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Birthmd)
				.HasColumnName("birthmd")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.BirthPlace)
				.IsRequired()
				.HasColumnName("birthplc")
				.HasMaxLength(64)
				.HasDefaultValueSql("'-'");

			builder.Property(e => e.CareerText)
				.IsRequired()
				.HasColumnName("career")
				.HasColumnType("text");

			builder.Property(e => e.Deathmd)
				.HasColumnName("deathmd")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.DeathPlace)
				.IsRequired()
				.HasColumnName("deathplc")
				.HasMaxLength(64)
				.HasDefaultValueSql("'-'");

			builder.Property(e => e.DebutYear)
				.HasColumnName("debiut")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.FirstName)
				.IsRequired()
				.HasColumnName("forename")
				.HasMaxLength(64)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Group)
				.HasColumnName("group")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Height)
				.IsRequired()
				.HasColumnName("height")
				.HasColumnType("char(3)")
				.HasDefaultValueSql("'-'");

			builder.Property(e => e.Initial)
				.IsRequired()
				.HasColumnName("initial")
				.HasMaxLength(5)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Kids)
				.IsRequired()
				.HasColumnName("kids")
				.HasMaxLength(64)
				.HasDefaultValueSql("'-'");

			builder.Property(e => e.Litera)
				.IsRequired()
				.HasColumnName("litera")
				.HasColumnType("char(1)");

			builder.Property(e => e.NationalityKey)
				.IsRequired()
				.HasColumnName("nat")
				.HasColumnType("char(3)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Residence)
				.IsRequired()
				.HasColumnName("resides")
				.HasMaxLength(64)
				.HasDefaultValueSql("'-'");

			builder.Property(e => e.MaritalStatus)
				.IsRequired()
				.HasColumnName("status")
				.HasMaxLength(64)
				.HasDefaultValueSql("'-'");

			builder.Property(e => e.Surname)
				.IsRequired()
				.HasColumnName("surname")
				.HasMaxLength(64)
				.HasDefaultValueSql("''");

			builder.Property(e => e.TeamKey)
				.HasColumnName("teamascid")
				.HasColumnType("char(3)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Testdriver)
				.IsRequired()
				.HasColumnName("testdriver")
				.HasMaxLength(255)
				.HasDefaultValueSql("'-'");

			builder.Property(e => e.ChampionAtSeries)
				.IsRequired()
				.HasColumnName("titles")
				.HasMaxLength(255)
				.HasDefaultValueSql("'-'");

			builder.Property(e => e.Weight)
				.IsRequired()
				.HasColumnName("weight")
				.HasMaxLength(4)
				.HasDefaultValueSql("'-'");

			builder.Property(e => e.Birthday)
				.HasColumnName("birth");

			builder.Property(e => e.Death)
				.HasColumnName("death");

			builder.HasOne(e => e.Nationality)
				.WithMany()
				.HasPrincipalKey(n => n.Key)
				.HasForeignKey(e => e.NationalityKey);

			builder.HasOne(e => e.Link)
				.WithMany()
				.IsRequired(false)
				.HasForeignKey(e => e.Key)
				.HasPrincipalKey(l => l.CategoryKey);

			builder.HasOne(e => e.Team)
				.WithMany()
				.HasForeignKey(e => e.TeamKey)
				.HasPrincipalKey(t => t.Key)
				.IsRequired(false);
		}
	}
}
