using System;
using System.Runtime.Serialization;

namespace F1WM.Services.Search
{
	[Serializable]
	internal class ExpressionTreeBuilderException : Exception
	{
		public ExpressionTreeBuilderException()
		{
		}

		public ExpressionTreeBuilderException(string message) : base(message)
		{
		}

		public ExpressionTreeBuilderException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ExpressionTreeBuilderException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
