using F1WM.ApiModel;
using Microsoft.AspNetCore.JsonPatch;

namespace F1WM.DomainModel
{
	public class BroadcastSessionTypeUpdateRequest
	{
		public int Id { get; set; }
		public JsonPatchDocument<BroadcastSessionType> PatchDocument { get; set; }
	}
}
