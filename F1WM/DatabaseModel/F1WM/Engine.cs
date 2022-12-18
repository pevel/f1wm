namespace F1WM.DatabaseModel
{
	public class Engine
	{
		public int Id { get; set; }
		public int EngineMakeId { get; set; }
		public string Name { get; set; }
		public string Letter { get; set; }
		public virtual EngineMake EngineMake { get; set; }
		public virtual EngineSpecification EngineSpecification { get; set; }
	}
}
