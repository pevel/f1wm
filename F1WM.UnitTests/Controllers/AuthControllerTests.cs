using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Controllers;
using F1WM.DatabaseModel;
using F1WM.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using Identity = Microsoft.AspNetCore.Identity;

namespace F1WM.UnitTests.Controllers
{
	public class AuthControllerTests
	{
		private AuthController controller;
		private Mock<IAuthService> serviceMock;
		private Mock<IConfiguration> configurationMock;
		private Mock<ILoggingService> loggerMock;

		public AuthControllerTests()
		{
			serviceMock = new Mock<IAuthService>();
			configurationMock = new Mock<IConfiguration>();
			loggerMock = new Mock<ILoggingService>();
			controller = new AuthController(serviceMock.Object, configurationMock.Object, loggerMock.Object);
		}

		[Fact]
		public async Task ShouldLogin()
		{
			var login = new Login() { Email = "ShouldLogin()Email", Password = "ShouldLogin()Password" };
			var tokens = new Tokens() { AccessToken = "ShouldLogin()Access", RefreshToken = "ShouldLogin()Refresh" };
			serviceMock.Setup(s => s.SignIn(login.Email, login.Password)).ReturnsAsync(Identity.SignInResult.Success);
			serviceMock.Setup(s => s.GenerateTokens(login.Email)).ReturnsAsync(tokens);

			var result = await controller.Login(login);

			serviceMock.Verify(s => s.SignIn(login.Email, login.Password), Times.Once);
			serviceMock.Verify(s => s.GenerateTokens(login.Email), Times.Once);
			Assert.IsType<OkObjectResult>(result);
			tokens.Should().BeEquivalentTo(((OkObjectResult)result).Value);
		}

		[Fact]
		public async Task ShouldNotLogin()
		{
			var login = new Login() { Email = "ShouldNotLogin()Email", Password = "ShouldNotLogin()Password" };
			serviceMock.Setup(s => s.SignIn(login.Email, login.Password)).ReturnsAsync(Identity.SignInResult.Failed);

			var result = await controller.Login(login);

			serviceMock.Verify(s => s.SignIn(login.Email, login.Password), Times.Once);
			serviceMock.Verify(s => s.GenerateTokens(login.Email), Times.Never);
			Assert.IsType<UnauthorizedResult>(result);
		}

		[Fact]
		public async Task ShouldRegister()
		{
			var key = "ShouldRegister()Key";
			var registerRequest = new RegisterRequest()
			{
				Email = "ShouldRegister()Email",
				Password = "ShouldRegister()Password",
				Key = key
			};
			Func<F1WMUser, bool> isTheSameUser = u => u.Email == registerRequest.Email && u.UserName == registerRequest.Email;
			var tokens = new Tokens() { AccessToken = "ShouldRegister()Access", RefreshToken = "ShouldRegister()Refresh" };
			serviceMock.Setup(s => s.SignUp(It.Is<F1WMUser>(u => isTheSameUser(u)), registerRequest.Password))
				.ReturnsAsync(Identity.IdentityResult.Success);
			serviceMock.Setup(s => s.GenerateTokens(registerRequest.Email)).ReturnsAsync(tokens);
			configurationMock.SetupGet(c => c["RegisterKey"]).Returns(key);

			var result = await controller.Register(registerRequest);

			serviceMock.Verify(s => s.SignUp(It.Is<F1WMUser>(u => isTheSameUser(u)), registerRequest.Password), Times.Once);
			serviceMock.Verify(s => s.GenerateTokens(registerRequest.Email), Times.Once);
			Assert.IsType<OkObjectResult>(result);
			tokens.Should().BeEquivalentTo(((OkObjectResult)result).Value);
		}

		[Fact]
		public async Task ShouldNotRegisterWhenKeyIsInvalid()
		{
			var key = "ShouldNotRegister()Key";
			var registerRequest = new RegisterRequest()
			{
				Email = "ShouldNotRegister()Email",
				Password = "ShouldNotRegister()Password",
				Key = "ShouldNotRegister()WrongKey"
			};
			Func<F1WMUser, bool> isTheSameUser = u => u.Email == registerRequest.Email && u.UserName == registerRequest.Email;
			configurationMock.SetupGet(c => c["RegisterKey"]).Returns(key);

			var result = await controller.Register(registerRequest);

			serviceMock.Verify(s => s.SignUp(It.Is<F1WMUser>(u => isTheSameUser(u)), registerRequest.Password), Times.Never);
			serviceMock.Verify(s => s.GenerateTokens(registerRequest.Email), Times.Never);
			Assert.IsType<UnprocessableEntityResult>(result);
		}

		[Fact]
		public async Task ShouldRefreshAccessToken()
		{
			var refreshToken = "ShouldRefreshAccessToken()Refresh";
			var tokens = new Tokens()
			{
				AccessToken = "ShouldRefreshAccessToken()Access",
				RefreshToken = refreshToken
			};
			var newTokens = new Tokens()
			{
				AccessToken = "ShouldRefreshAccessToken()NewAccess",
				RefreshToken = refreshToken
			};
			serviceMock.Setup(s => s.RefreshAccessToken(tokens)).ReturnsAsync(newTokens);

			var result = await controller.RefreshAccessToken(tokens);

			serviceMock.Verify(s => s.RefreshAccessToken(tokens), Times.Once);
			Assert.IsType<OkObjectResult>(result);
			Assert.NotEqual(tokens.AccessToken, ((Tokens)((OkObjectResult)result).Value).AccessToken);
			Assert.Equal(tokens.RefreshToken, ((Tokens)((OkObjectResult)result).Value).RefreshToken);
		}

		[Fact]
		public async Task ShouldNotRefreshAccessToken()
		{
			var tokens = new Tokens()
			{
				AccessToken = "ShouldRefreshAccessToken()Access",
				RefreshToken = "ShouldRefreshAccessToken()Refresh"
			};
			serviceMock.Setup(s => s.RefreshAccessToken(tokens)).ThrowsAsync(new UnauthorizedAccessException());

			var result = await controller.RefreshAccessToken(tokens);

			serviceMock.Verify(s => s.RefreshAccessToken(tokens), Times.Once);
			Assert.IsType<UnauthorizedResult>(result);
		}
	}
}
