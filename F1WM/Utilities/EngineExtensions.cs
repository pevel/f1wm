using F1WM.DatabaseModel;

namespace F1WM.Utilities
{
	public static class EngineExtensions
	{
		public static string GetEnginePicturePath(this Engine engine)
		{
			return $"/img/silniki/{engine.Id}.jpg";
		}
	}
}
