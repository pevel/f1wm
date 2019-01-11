using System;
using System.ComponentModel.DataAnnotations;

namespace F1WM.DatabaseModel
{
	public class RefreshToken
	{
		public long Id { get; set; }
		public DateTime IssuedAt { get; set; }
		public DateTime ExpiresAt { get; set; }
		[Required]
		[StringLength(255)]
		public string Token { get; set; }
		[Required]
		public string UserId { get; set; }
		public virtual F1WMUser User { get; set; }
	}
}
