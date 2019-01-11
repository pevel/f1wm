using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace F1WM.UnitTests.Mocks
{
	public class SignInManagerFake<T> : SignInManager<T> where T : class
	{
		public SignInManagerFake() : base(new Mock<UserManagerFake<T>>().Object,
			new HttpContextAccessor(),
			new Mock<IUserClaimsPrincipalFactory<T>>().Object,
			new Mock<IOptions<IdentityOptions>>().Object,
			new Mock<ILogger<SignInManager<T>>>().Object,
			new Mock<IAuthenticationSchemeProvider>().Object)
		{ }
	}
}
