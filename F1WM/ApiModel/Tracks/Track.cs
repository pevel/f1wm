namespace F1WM.ApiModel
{
	public class Track : TrackSummary
	{
		public string City { get; set; }
		public string ShortName { get; set; }
		public Country Country { get; set; }
		public byte StatusId { get; set; }
	}
}
