using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace F1WM.Utilities
{
	public static class Auth
	{
		public static SymmetricSecurityKey GetJwtKey(IConfiguration configuration)
		{
			return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[Configuration.JwtKeyKey]));
		}
	}
}