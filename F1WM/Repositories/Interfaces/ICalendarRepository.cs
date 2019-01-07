using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface ICalendarRepository
	{
		Task<Calendar> GetCalendar(int year);
	}
}