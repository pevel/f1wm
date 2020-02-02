using Microsoft.AspNetCore.JsonPatch;
using System.ComponentModel.DataAnnotations;

namespace F1WM.ApiModel
{
	public class BroadcastsUpdateRequest 
	{
		public int RaceId { get; set; }
		public JsonPatchDocument<BroadcastedRaceUpdate> PatchDocument { get; set; }
	}
}
