using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class NewsCommentConfiguration : IEntityTypeConfiguration<NewsComment>
	{
		public void Configure(EntityTypeBuilder<NewsComment> builder)
		{
			builder.HasKey(e => e.Id);

			builder.HasOne(e => e.Text)
				.WithOne(e => e.Comment)
				.HasForeignKey(typeof(NewsCommentText));

			builder.ToTable("f1_news_coms");

			builder.HasIndex(e => e.UnixTime)
				.HasName("comm_time");

			builder.HasIndex(e => e.NewsId)
				.HasName("news_id");

			builder.HasIndex(e => e.PosterId)
				.HasName("poster_id");

			builder.Property(e => e.Id)
				.HasColumnName("comm_id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Status)
				.HasColumnName("comm_status")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.UnixTime)
				.HasColumnName("comm_time")
				.HasColumnType("int(11)")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.NewsId)
				.HasColumnName("news_id")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.PosterId)
				.HasColumnName("poster_id")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.PosterIp)
				.IsRequired()
				.HasColumnName("poster_ip")
				.HasMaxLength(15)
				.HasDefaultValueSql("''");

			builder.Property(e => e.PosterName)
				.HasColumnName("poster_name")
				.HasMaxLength(25);
		}
	}
}
