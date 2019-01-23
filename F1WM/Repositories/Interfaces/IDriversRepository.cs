using F1WM.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1WM.Repositories
{
	public interface IDriversRepository
	{
		Task<Drivers> GetDrivers(string letter);
	}
}
