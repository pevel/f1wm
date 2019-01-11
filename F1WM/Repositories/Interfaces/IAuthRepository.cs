using System.Threading.Tasks;
using F1WM.DatabaseModel;

namespace F1WM.Repositories
{
	public interface IAuthRepository
	{
		Task<F1WMUser> GetUserByEmail(string email);
		Task<bool> IsRefreshTokenValid(string refreshToken);
		Task AddRefreshToken(RefreshToken token);
	}
}
