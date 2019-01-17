using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class NewsTopicConfiguration : IEntityTypeConfiguration<NewsTopic>
	{
		public void Configure(EntityTypeBuilder<NewsTopic> builder)
		{
			builder.HasKey(e => e.TopicId);

			builder.ToTable("f1_news_topics");

			builder.HasIndex(e => e.CatId)
				.HasName("cat_id");

			builder.HasIndex(e => e.Searches)
				.HasName("searches");

			builder.HasIndex(e => e.TopicTitle)
				.HasName("topic_title");

			builder.HasIndex(e => new { e.CatId, e.TopicTitle })
				.HasName("cat+title");

			builder.Property(e => e.TopicId)
				.HasColumnName("topic_id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.CatId)
				.HasColumnName("cat_id")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Searches)
				.HasColumnName("searches")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.TopicIcon)
				.HasColumnName("topic_icon")
				.HasMaxLength(20);

			builder.Property(e => e.TopicTitle)
				.IsRequired()
				.HasColumnName("topic_title")
				.HasMaxLength(25);
		}
	}
}
