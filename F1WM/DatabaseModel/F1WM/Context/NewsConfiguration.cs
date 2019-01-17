using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class NewsConfiguration : IEntityTypeConfiguration<News>
	{
		public void Configure(EntityTypeBuilder<News> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1_news");

			builder.HasIndex(e => e.Date)
				.HasName("news_date");

			builder.HasIndex(e => e.NewsDateym)
				.HasName("news_dateym");

			builder.HasIndex(e => e.PosterName)
				.HasName("poster_name");

			builder.HasIndex(e => new { e.NewsHidden, e.Date })
				.HasName("hidden_date");

			builder.HasIndex(e => new { e.Title, e.Subtitle })
				.HasName("titles");

			builder.HasIndex(e => new { e.TypeId, e.Date })
				.HasName("news_type");

			builder.HasIndex(e => new { e.TypeId, e.NewsHidden, e.Date })
				.HasName("type_hidden_date");

			builder.Property(e => e.Id)
				.HasColumnName("news_id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.CommBlock)
				.HasColumnName("comm_block");

			builder.Property(e => e.CommentCount)
				.HasColumnName("comm_count")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Date)
				.HasColumnName("news_date")
				.HasColumnType("datetime")
				.HasDefaultValueSql("'0000-00-00 00:00:00'");

			builder.Property(e => e.NewsDateym)
				.HasColumnName("news_dateym")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.NewsHidden)
				.HasColumnName("news_hidden");

			builder.Property(e => e.IsHighlighted)
				.HasColumnName("news_highlight");

			builder.Property(e => e.NewsModified)
				.HasColumnName("news_modified")
				.HasColumnType("int(11)");

			builder.Property(e => e.Redirect)
				.HasColumnName("news_redirect")
				.HasMaxLength(50);

			builder.Property(e => e.Subtitle)
				.IsRequired()
				.HasColumnName("news_subtitle")
				.HasMaxLength(128);

			builder.Property(e => e.Text)
				.IsRequired()
				.HasColumnName("news_text")
				.HasColumnType("text");

			builder.Property(e => e.Title)
				.IsRequired()
				.HasColumnName("news_title")
				.HasMaxLength(80);

			builder.Property(e => e.TypeId)
				.HasColumnName("news_type");

			builder.Property(e => e.Views)
				.HasColumnName("news_views")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.PosterId)
				.HasColumnName("poster_id")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.PosterName)
				.HasColumnName("poster_name")
				.HasMaxLength(30);

			builder.Property(e => e.TagId)
				.HasColumnName("topic_id")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");
		}
	}
}
