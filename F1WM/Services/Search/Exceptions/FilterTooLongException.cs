using System;
using System.Runtime.Serialization;

namespace F1WM.Services.Search
{
	[Serializable]
	internal class FilterTooLongException : Exception
	{
		public FilterTooLongException()
		{
		}

		public FilterTooLongException(string message) : base(message)
		{
		}

		public FilterTooLongException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected FilterTooLongException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
