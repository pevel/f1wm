using F1WM.ApiModel;
using Microsoft.AspNetCore.JsonPatch;

namespace F1WM.DomainModel
{
	public class BroadcastsUpdateRequest 
	{
		public int RaceId { get; set; }
		public JsonPatchDocument<BroadcastedRaceUpdate> PatchDocument { get; set; }
	}
}
