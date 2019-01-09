using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace F1WM.Services
{
	public interface IAuthService
	{
		Task<SignInResult> PasswordSignInAsync(string email, string password);
		Task<string> GenerateJwtToken(string email);
	}
}