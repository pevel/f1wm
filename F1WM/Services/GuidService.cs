using System;

namespace F1WM.Services
{
	public class GuidService : IGuidService
	{
		public Guid NewGuid()
		{
			return Guid.NewGuid();
		}
	}
}