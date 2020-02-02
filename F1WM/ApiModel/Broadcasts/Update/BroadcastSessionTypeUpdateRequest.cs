using Microsoft.AspNetCore.JsonPatch;

namespace F1WM.ApiModel
{
	public class BroadcastSessionTypeUpdateRequest
	{
		public int Id { get; set; }
		public JsonPatchDocument<BroadcastSessionType> PatchDocument { get; set; }
	}
}
