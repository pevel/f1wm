using System.ComponentModel.DataAnnotations;

namespace F1WM.ApiModel
{
	public class Tokens
	{
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
	}
}