using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class NewsCommentTextConfiguration : IEntityTypeConfiguration<NewsCommentText>
	{
		public void Configure(EntityTypeBuilder<NewsCommentText> builder)
		{
			builder.HasKey(e => e.CommentId);

			builder.ToTable("f1_news_comstext");

			builder.Property(e => e.CommentId)
				.HasColumnName("comm_id")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Text)
				.HasColumnName("comm_text")
				.HasColumnType("text");
		}
	}
}
