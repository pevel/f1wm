using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class ArticleConfiguration : IEntityTypeConfiguration<Article>
	{
		public void Configure(EntityTypeBuilder<Article> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1_arts");

			builder.HasIndex(e => e.Title)
				.HasName("arttitle");

			builder.HasIndex(e => e.ArticleCategoryId)
				.HasName("catid");

			builder.Property(e => e.Id)
				.HasColumnName("artid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.IsHidden)
				.HasColumnName("arthidden")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Poster)
				.IsRequired()
				.HasColumnName("artposter")
				.HasMaxLength(64);

			builder.Property(e => e.Preview)
				.HasColumnName("artpreview")
				.HasMaxLength(255);

			builder.Property(e => e.Text)
				.HasColumnName("arttext")
				.HasColumnType("text");

			builder.Property(e => e.Title)
				.IsRequired()
				.HasColumnName("arttitle")
				.HasMaxLength(80);

			builder.Property(e => e.Views)
				.HasColumnName("artviews")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.ArticleCategoryId)
				.HasColumnName("catid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.NewsId)
				.HasColumnName("newsid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");
		}
	}
}
