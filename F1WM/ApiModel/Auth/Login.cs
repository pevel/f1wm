using System.ComponentModel.DataAnnotations;

namespace F1WM.ApiModel
{
	public class Login
	{
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}