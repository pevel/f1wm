using Microsoft.AspNetCore.JsonPatch;

namespace F1WM.ApiModel
{
	public class BroadcasterUpdateRequest
	{
		public int Id { get; set; }
		public JsonPatchDocument<Broadcaster> PatchDocument { get; set; }
	}
}
