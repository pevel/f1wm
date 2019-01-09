using System.Threading.Tasks;
using F1WM.DatabaseModel;
using Microsoft.AspNetCore.Identity;

namespace F1WM.Services
{
	public interface IAuthService
	{
		Task<IdentityResult> CreateUser(F1WMUser user, string password);
		Task<SignInResult> SignIn(string email, string password);
		Task<string> GenerateJwtToken(string email);
	}
}