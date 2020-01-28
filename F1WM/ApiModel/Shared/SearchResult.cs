namespace F1WM.ApiModel
{
	public class SearchResult<T> : PagedResult<T>
	{
		public string Error { get; set; }
	}
}
