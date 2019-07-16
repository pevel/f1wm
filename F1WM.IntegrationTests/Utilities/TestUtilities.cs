using System.IO;
using System.Linq;

public static class TestUtilities
{
	public const string TestDataRoot = "test-data";

	public static string GetTestDataFilePath(params string[] pathParts)
	{
		var combined = Path.Combine(pathParts.Prepend(TestDataRoot).ToArray());
		return Path.GetRelativePath(Directory.GetCurrentDirectory(), combined);
	}
}
