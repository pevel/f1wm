using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class NewsTagConfiguration : IEntityTypeConfiguration<NewsTag>
	{
		public void Configure(EntityTypeBuilder<NewsTag> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1_news_topics");

			builder.HasIndex(e => e.CategoryId)
				.HasName("cat_id");

			builder.HasIndex(e => e.Searches)
				.HasName("searches");

			builder.HasIndex(e => e.Title)
				.HasName("topic_title");

			builder.HasIndex(e => new { e.CategoryId, e.Title })
				.HasName("cat+title");

			builder.Property(e => e.Id)
				.HasColumnName("topic_id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.CategoryId)
				.HasColumnName("cat_id")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Searches)
				.HasColumnName("searches")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Title)
				.IsRequired()
				.HasColumnName("topic_title")
				.HasMaxLength(25);
			
			builder.Property(e => e.Icon)
				.HasColumnName("topic_icon")
				.HasMaxLength(20);
		}
	}
}
