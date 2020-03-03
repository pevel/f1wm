using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class CommentsTests : IntegrationTestBase
	{
		[Fact]
		public async Task ShouldGetSingleComment()
		{
			var id = 42;

			var comment = await Get<Comment>($"comments/{id}");

			Assert.NotNull(comment);
			Assert.NotNull(comment.PosterName);
			Assert.NotNull(comment.Text);
			Assert.Equal(id, comment.Id);
		}

		[Fact]
		public async Task ShouldGetManyComments()
		{
			var newsId = 43;

			var comments = await Get<IEnumerable<Comment>>($"comments?newsId={newsId}");

			Assert.NotNull(comments);
			Assert.All(comments, comment =>
			{
				Assert.NotNull(comment.PosterName);
				Assert.NotNull(comment.Text);
				Assert.Equal(newsId, comment.NewsId);
			});
		}
	}
}
