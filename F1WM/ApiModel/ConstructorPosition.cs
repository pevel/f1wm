namespace F1WM.ApiModel
{
	public class ConstructorPosition
	{
		public int Id { get; set; }
		public int Position { get; set; }
		public int Points { get; set; }
		public string ConstructorName { get; set; }
		public Nationality Nationality { get; set; }
	}
}