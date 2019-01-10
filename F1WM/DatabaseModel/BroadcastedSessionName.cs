using System.ComponentModel.DataAnnotations;

namespace F1WM.DatabaseModel
{
	public class BroadcastedSessionName
	{
		public int Id { get; set; }
		[MaxLength(255)]
		public string Name { get; set; }
	}
}
