using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class NewsTagMatchConfiguration : IEntityTypeConfiguration<NewsTagMatch>
	{
		public void Configure(EntityTypeBuilder<NewsTagMatch> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1_news_topicmatch");

			builder.HasIndex(e => e.NewsId)
				.HasName("news_id");

			builder.HasIndex(e => new { e.TagId, e.NewsDate })
				.HasName("topic_id");

			builder.Property(e => e.Id)
				.HasColumnName("match_id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.NewsDate)
				.HasColumnName("news_date")
				.HasColumnType("datetime");

			builder.Property(e => e.NewsId)
				.HasColumnName("news_id")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.TagId)
				.HasColumnName("topic_id")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");
		}
	}
}
