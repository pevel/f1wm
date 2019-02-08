using System.IO;

namespace F1WM.Utilities.Model
{
	public class NewsParserContext
	{
		public string CurrentLine { get; set; }
		public StringReader Reader { get; set; }
		public StringWriter Writer { get; set; }
	}
}
