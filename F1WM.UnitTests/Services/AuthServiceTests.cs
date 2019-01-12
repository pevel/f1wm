using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using F1WM.DatabaseModel;
using F1WM.Repositories;
using F1WM.Services;
using F1WM.UnitTests.Mocks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class AuthServiceTests
	{
		private AuthService service;
		private Fixture fixture;
		private JwtSecurityTokenHandler jwtHandler;
		private Mock<IAuthRepository> repositoryMock;
		private Mock<SignInManagerFake<F1WMUser>> signInManagerMock;
		private Mock<UserManagerFake<F1WMUser>> userManagerMock;
		private Mock<IConfiguration> configurationMock;
		private Mock<IGuidService> guidServiceMock;
		private Mock<ITimeService> timeServiceMock;

		public AuthServiceTests()
		{
			fixture = new Fixture();
			jwtHandler = new JwtSecurityTokenHandler();
			repositoryMock = new Mock<IAuthRepository>();
			signInManagerMock = new Mock<SignInManagerFake<F1WMUser>>();
			userManagerMock = new Mock<UserManagerFake<F1WMUser>>();
			configurationMock = new Mock<IConfiguration>();
			guidServiceMock = new Mock<IGuidService>();
			timeServiceMock = new Mock<ITimeService>();
			service = new AuthService(
				repositoryMock.Object,
				configurationMock.Object,
				guidServiceMock.Object,
				timeServiceMock.Object,
				signInManagerMock.Object,
				userManagerMock.Object);
		}

		[Fact]
		public async Task ShouldSignIn()
		{
			string email = "email@email.com";
			string password = "password";
			var signInResult = SignInResult.Success;
			signInManagerMock.Setup(m => m.PasswordSignInAsync(email, password, false, false))
				.ReturnsAsync(signInResult);

			var result = await service.SignIn(email, password);

			signInManagerMock.Verify(m => m.PasswordSignInAsync(email, password, false, false), Times.Once);
			Assert.Equal(signInResult, result);
		}

		[Fact]
		public async Task ShouldSignUp()
		{
			var user = fixture.Create<F1WMUser>();
			string password = "password";
			var signUpResult = IdentityResult.Success;
			userManagerMock.Setup(m => m.CreateAsync(user, password)).ReturnsAsync(signUpResult);

			var result = await service.SignUp(user, password);

			userManagerMock.Verify(m => m.CreateAsync(user, password), Times.Once);
			Assert.Equal(signUpResult, result);
		}

		[Fact]
		public async Task ShouldGenerateTokens()
		{
			string email = "email@email.com";
			var user = fixture.Create<F1WMUser>();
			user.Email = email;
			var now = new DateTime(1992, 10, 14, 5, 5, 3, DateTimeKind.Utc);
			Func<RefreshToken, bool> assertToken = t => t.IssuedAt == now && t.UserId == user.Id && t.ExpiresAt == now.AddDays(14);
			timeServiceMock.SetupGet(t => t.Now).Returns(now);
			configurationMock.SetupGet(c => c["JwtExpireSeconds"]).Returns("2");
			configurationMock.SetupGet(c => c["JwtKey"]).Returns("key1234567890123456789012345678901234567890");
			configurationMock.SetupGet(c => c["JwtIssuer"]).Returns("issuer");
			configurationMock.SetupGet(c => c["JwtAudience"]).Returns("audience");
			repositoryMock.Setup(r => r.GetUserByEmail(email)).ReturnsAsync(user);

			var result = await service.GenerateTokens(email);

			repositoryMock.Verify(r => r.AddRefreshToken(It.Is<RefreshToken>(t => assertToken(t))));
			repositoryMock.Verify(r => r.GetUserByEmail(email), Times.Once);
			var accessToken = jwtHandler.ReadToken(result.AccessToken) as JwtSecurityToken;
			Assert.Equal(now.AddSeconds(2), accessToken.ValidTo);
			Assert.Equal(email, accessToken.Subject);
			Assert.Equal("issuer", accessToken.Issuer);
			Assert.Equal("audience", accessToken.Audiences.First());
		}

		[Fact]
		public async Task ShouldNotGenerateTokensIfUserNotFound()
		{
			string email = "email@email.com";
			repositoryMock.Setup(r => r.GetUserByEmail(email)).ReturnsAsync((F1WMUser)null);

			try
			{
				await service.GenerateTokens(email);
			}
			catch (Exception ex)
			{
				Assert.IsType<ArgumentException>(ex);
			}
		}
	}
}
