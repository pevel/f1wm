using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.Controllers;
using F1WM.ApiModel;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class CommentsTests : IntegrationTestBase
	{
		[Fact]
		public async Task GetSingleCommentTest()
		{
			var id = 42;

			var response = await client.GetAsync($"{baseAddress}/comments/{id}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var comment = JsonConvert.DeserializeObject<Comment>(responseContent);
			Assert.NotNull(comment);
			Assert.NotNull(comment.PosterName);
			Assert.NotNull(comment.Text);
			Assert.Equal(id, comment.Id);
		}

		[Fact]
		public async Task GetManyCommentsTest()
		{
			var newsId = 43;

			var response = await client.GetAsync($"{baseAddress}/comments?newsId={newsId}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var comments = JsonConvert.DeserializeObject<IEnumerable<Comment>>(responseContent);
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