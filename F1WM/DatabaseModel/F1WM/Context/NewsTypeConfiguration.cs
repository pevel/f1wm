using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class NewsTypeConfiguration : IEntityTypeConfiguration<NewsType>
	{
		public void Configure(EntityTypeBuilder<NewsType> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1_news_types");

			builder.Property(e => e.Id).HasColumnName("type_id");

			builder.Property(e => e.Title)
				.IsRequired()
				.HasColumnName("type_title")
				.HasMaxLength(45);

			builder.Property(e => e.AlternativeTitle)
				.IsRequired()
				.HasColumnName("type_title2")
				.HasMaxLength(14);
		}
	}
}
