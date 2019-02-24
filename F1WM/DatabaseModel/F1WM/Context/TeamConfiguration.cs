using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class TeamConfiguration : IEntityTypeConfiguration<Team>
	{
		public void Configure(EntityTypeBuilder<Team> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1teams");

			builder.HasIndex(e => e.Key)
				.HasName("ascid")
				.IsUnique();

			builder.HasIndex(e => e.Letter)
				.HasName("litera");

			builder.HasIndex(e => e.Status)
				.HasName("status");

			builder.HasIndex(e => e.Name)
				.HasName("team");

			builder.Property(e => e.Id)
				.HasColumnName("teamid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Artid)
				.HasColumnName("artid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Key)
				.IsRequired()
				.HasColumnName("ascid")
				.HasColumnType("char(3)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Headquarters)
				.IsRequired()
				.HasColumnName("base")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Basedonteam)
				.IsRequired()
				.HasColumnName("basedonteam")
				.HasColumnType("char(3)")
				.HasDefaultValueSql("''");

			builder.Property(e => e.Carmakeid)
				.HasColumnName("carmakeid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.TeamPrincipal)
				.IsRequired()
				.HasColumnName("curboss")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.TeamPrincipalPicture)
				.IsRequired()
				.HasColumnName("curbosspic")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.EngineeringDirector)
				.IsRequired()
				.HasColumnName("curengboss")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.EngineeringDirectorPicture)
				.IsRequired()
				.HasColumnName("curengbosspic")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.TechnicalDirector)
				.IsRequired()
				.HasColumnName("curtechdir")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.TechnicalDirectorPicture)
				.IsRequired()
				.HasColumnName("curtechdirpic")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.FirstTeamPrincipal)
				.IsRequired()
				.HasColumnName("firstboss")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.FirstTeamPrincipalPicture)
				.IsRequired()
				.HasColumnName("firstbosspic")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Founder)
				.IsRequired()
				.HasColumnName("founder")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.FounderPicture)
				.IsRequired()
				.HasColumnName("founderpic")
				.HasMaxLength(45)
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

			builder.Property(e => e.NewsTopicId)
				.HasColumnName("newstopicid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.OtherDirector)
				.IsRequired()
				.HasColumnName("otherboss")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.OtherDirectorOccupation)
				.IsRequired()
				.HasColumnName("otherbossocc")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.OtherDirectorPicture)
				.IsRequired()
				.HasColumnName("otherbosspic")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Secondfactory)
				.IsRequired()
				.HasColumnName("secondfactory")
				.HasMaxLength(45)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Status)
				.HasColumnName("status")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Name)
				.IsRequired()
				.HasColumnName("team")
				.HasMaxLength(64)
				.HasDefaultValueSql("''");

			builder.Property(e => e.Teamshort)
				.IsRequired()
				.HasColumnName("teamshort")
				.HasMaxLength(10);

			builder.HasOne(e => e.Country)
				.WithMany()
				.HasForeignKey(e => e.NationalityKey)
				.HasPrincipalKey(n => n.Key);
		}
	}
}
