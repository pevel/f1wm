using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class NewsTagCategoryConfiguration : IEntityTypeConfiguration<NewsTagCategory>
	{
		public void Configure(EntityTypeBuilder<NewsTagCategory> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1_news_cats");

			builder.Property(e => e.Id)
				.HasColumnName("cat_id")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.Title)
				.IsRequired()
				.HasColumnName("cat_title")
				.HasMaxLength(20)
				.HasDefaultValueSql("''");
		}
	}
}
