using F1WM.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1WM.Services
{
	public interface IDriversService
	{
		Task<DriversList> GetDrivers(string letter);
	}
}
