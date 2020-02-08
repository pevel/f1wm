using F1WM.IntegrationTests.Utilities;
using Xunit;

namespace F1WM.IntegrationTests.Attributes
{
	public class RunOnlyIfCredentialsProvidedAttribute : FactAttribute
	{
		public RunOnlyIfCredentialsProvidedAttribute()
		{
			if (!SharedTestUtilities.CredentialsFileExists())
			{
				Skip = "Credentials not found. Ignoring test requiring credentials";
			}
		}
	}
}
