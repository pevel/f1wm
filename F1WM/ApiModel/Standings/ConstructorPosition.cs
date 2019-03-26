namespace F1WM.ApiModel
{
	public class ConstructorPosition
	{
		public uint Id { get; set; }
		public int Position { get; set; }
		public float Points { get; set; }
		public ConstructorSummary Constructor { get; set; }
	}
}
