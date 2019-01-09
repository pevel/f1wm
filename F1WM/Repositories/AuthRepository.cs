using System.Threading.Tasks;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class AuthRepository : IAuthRepository
	{
		private readonly F1WMIdentityContext context;

		public AuthRepository(F1WMIdentityContext context)
		{
			this.context = context;
		}

		public Task<F1WMUser> GetUserByEmail(string email)
		{
			return context.F1WMUsers.SingleOrDefaultAsync(u => u.Email == email);
		}
	}
}