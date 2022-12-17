using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class TeamNameConfiguration : IEntityTypeConfiguration<TeamName>
	{
		public void Configure(EntityTypeBuilder<TeamName> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1teamnames");

			builder.HasIndex(e => e.TeamId)
				.HasDatabaseName("teamid");

			builder.HasIndex(e => e.FullName)
				.HasDatabaseName("teamname");

			builder.Property(e => e.Id)
				.HasColumnName("teamnameid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.TeamId)
				.HasColumnName("teamid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.FullName)
				.IsRequired()
				.HasColumnName("teamname")
				.HasMaxLength(64)
				.HasDefaultValueSql("''");
		}
	}
}
