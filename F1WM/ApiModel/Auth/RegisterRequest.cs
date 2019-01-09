using System.ComponentModel.DataAnnotations;

namespace F1WM.ApiModel
{
	public class RegisterRequest
	{
		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}
}