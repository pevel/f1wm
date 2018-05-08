using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Services;
using Moq;
using Narochno.BBCode;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class CommentsServiceTests
	{
		private CommentsService service;
		private Mock<ICommentsRepository> repositoryMock;
		private Mock<IBBCodeParser> parserMock;

		public CommentsServiceTests()
		{
			repositoryMock = new Mock<ICommentsRepository>();
			parserMock = new Mock<IBBCodeParser>();
			service = new CommentsService(repositoryMock.Object, parserMock.Object);
		}

		[Fact]
		public async Task ShouldGetSingleCommentWithParsedText()
		{
			var id = 42;
			var text = "Test text";
			repositoryMock.Setup(r => r.GetComment(id)).ReturnsAsync(new Comment() { Text = text });

			await service.GetComment(id);

			repositoryMock.Verify(r => r.GetComment(id), Times.Once);
			parserMock.Verify(p => p.ToHtml(text), Times.Once);
		}

		[Fact]
		public async Task ShouldGetCommentsListWithParsedText()
		{
			var newsId = 43;
			var commentsCount = 5;
			var text = "Test text many times";
			var comments = new List<Comment>();
			for (int i = 0; i < commentsCount; i++)
			{
				comments.Add(new Comment() { Text = text });
			}
			repositoryMock.Setup(r => r.GetCommentsByNewsId(newsId)).ReturnsAsync(comments);

			await service.GetCommentsByNewsId(newsId);

			repositoryMock.Verify(r => r.GetCommentsByNewsId(newsId), Times.Once);
			parserMock.Verify(p => p.ToHtml(text), Times.Exactly(commentsCount));
		}
	}
}