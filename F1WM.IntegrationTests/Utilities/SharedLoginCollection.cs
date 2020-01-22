using System;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class SharedLogin
	{
		public const string CollectionName = "SharedLogin";

		[CollectionDefinition(SharedLogin.CollectionName)]
		public class CollectionDefinition : ICollectionFixture<SharedLogin.Fixture>
		{ }

		public class Fixture : IDisposable
		{
			public string AccessToken { get; set; }

			public void Dispose()
			{ }
		}
	}
}

