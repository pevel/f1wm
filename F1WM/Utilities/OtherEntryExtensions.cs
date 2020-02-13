using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Utilities
{
	public static class OtherEntryExtensions
	{
		public static CarSummary GetCarInfo(this OtherEntry entry)
		{
			return new CarSummary() { Name = entry.CarName };
		}
	}
}
