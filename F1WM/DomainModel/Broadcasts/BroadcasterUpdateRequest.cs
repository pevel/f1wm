using F1WM.ApiModel;
using Microsoft.AspNetCore.JsonPatch;

namespace F1WM.DomainModel
{
	public class BroadcasterUpdateRequest
	{
		public int Id { get; set; }
		public JsonPatchDocument<Broadcaster> PatchDocument { get; set; }
	}
}
