using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace F1WM.UnitTests.Mocks
{
	public class UserManagerFake<T> : UserManager<T> where T : class
	{
		public UserManagerFake() : base(new Mock<IUserStore<T>>().Object,
			new Mock<IOptions<IdentityOptions>>().Object,
			new Mock<IPasswordHasher<T>>().Object,
			new IUserValidator<T>[0],
			new IPasswordValidator<T>[0],
			new Mock<ILookupNormalizer>().Object,
			new Mock<IdentityErrorDescriber>().Object,
			new Mock<IServiceProvider>().Object,
			new Mock<ILogger<UserManager<T>>>().Object)
		{ }
	}
}
