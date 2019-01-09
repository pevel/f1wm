using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.AspNetCore.Identity;

namespace F1WM.Services
{
	public interface IAuthService
	{
		Task<IdentityResult> SignUp(F1WMUser user, string password);
		Task<SignInResult> SignIn(string email, string password);
		bool TryGetEmailFromTokens(Tokens tokens, out string email);
		Task<string> GenerateAccessToken(string email);
		Task<Tokens> GenerateTokens(string email);
	}
}