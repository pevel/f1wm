using System;
using System.Runtime.Serialization;

namespace F1WM.Services.Search
{
	[Serializable]
	internal class TokenAnalyzerException : Exception
	{
		public TokenAnalyzerException()
		{
		}

		public TokenAnalyzerException(string message) : base(message)
		{
		}

		public TokenAnalyzerException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected TokenAnalyzerException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
