using System;
using System.Runtime.Serialization;

namespace F1WM.Services.Search
{
	[Serializable]
	internal class FilterTooShortException : Exception
	{
		public FilterTooShortException()
		{
		}

		public FilterTooShortException(string message) : base(message)
		{
		}

		public FilterTooShortException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected FilterTooShortException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
