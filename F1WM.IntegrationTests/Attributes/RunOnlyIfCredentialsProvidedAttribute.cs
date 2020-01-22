using Xunit;

namespace F1WM.IntegrationTests
{
	public class RunOnlyIfCredentialsProvidedAttribute : FactAttribute
	{
		public RunOnlyIfCredentialsProvidedAttribute()
		{
			if (!TestUtilities.CredentialsFileExists())
			{
				Skip = "Credentials not found. Ignoring test requiring credentials";
			}
		}
	}
}
