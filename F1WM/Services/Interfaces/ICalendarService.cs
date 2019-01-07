using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface ICalendarService
	{
		Task<Calendar> GetCalendar(int? year);
	}
}