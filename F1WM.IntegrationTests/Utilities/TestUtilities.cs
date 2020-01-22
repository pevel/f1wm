using System.IO;
using System.Linq;
using F1WM.ApiModel;
using Newtonsoft.Json;

public static class TestUtilities
{
	public const string TestDataRoot = "test-data";

	public static string GetTestDataFilePath(params string[] pathParts)
	{
		var combined = Path.Combine(pathParts.Prepend(TestDataRoot).ToArray());
		return Path.GetRelativePath(Directory.GetCurrentDirectory(), combined);
	}

	public static string GetCredentialsFilePath()
	{
		return TestUtilities.GetTestDataFilePath("auth", "test-credentials.json");
	}

	public static bool CredentialsFileExists()
	{
		return File.Exists(GetCredentialsFilePath());
	}

	public static Login GetLoginRequestBody()
	{
		var filePath = TestUtilities.GetCredentialsFilePath();
		using (StreamReader file = File.OpenText(filePath))
		{
			JsonSerializer serializer = new JsonSerializer();
			return serializer.Deserialize(file, typeof(Login)) as Login;
		}
	}
}
