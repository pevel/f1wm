using System.Linq;
using System.Threading.Tasks;
using F1WM.DatabaseModel;
using F1WM.Services;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class AuthRepository : IAuthRepository
	{
		private readonly F1WMIdentityContext context;
		private readonly ITimeService time;

		public AuthRepository(F1WMIdentityContext context, ITimeService time)
		{
			this.context = context;
			this.time = time;
		}

		public Task AddRefreshToken(RefreshToken token)
		{
			context.RefreshTokens.Add(token);
			return context.SaveChangesAsync();
		}

		public Task RevokeRefreshTokensFor(F1WMUser user)
		{
			var dbTokens = context.RefreshTokens.Where(t => t.UserId == user.Id);
			context.RefreshTokens.RemoveRange(dbTokens);
			return context.SaveChangesAsync();
		}

		public Task RevokeRefreshToken(string token)
		{
			var dbToken = context.RefreshTokens.Single(t => t.Token == token);
			context.RefreshTokens.Remove(dbToken);
			return context.SaveChangesAsync();
		}

		public Task<F1WMUser> GetUserByEmail(string email)
		{
			return context.F1WMUsers.SingleOrDefaultAsync(u => u.Email == email);
		}

		public Task<bool> IsRefreshTokenValid(string refreshToken)
		{
			var now = time.Now.ToUniversalTime();
			return context.RefreshTokens.AnyAsync(t => t.Token == refreshToken && t.IssuedAt < now && t.ExpiresAt > now);
		}
	}
}
