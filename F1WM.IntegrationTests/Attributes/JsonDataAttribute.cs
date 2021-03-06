using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using F1WM.IntegrationTests.Utilities;
using Newtonsoft.Json;
using Xunit.Sdk;

namespace F1WM.IntegrationTests.Attributes
{
	public class JsonDataAttribute : DataAttribute
	{
		private readonly string filePath;

		public override IEnumerable<object[]> GetData(MethodInfo testMethod)
		{
			CheckMethod(testMethod);
			CheckFile();
			var type = GetTestDataType(testMethod);
			var data = new List<object[]>();
			using (StreamReader file = File.OpenText(filePath))
			{
				JsonSerializer serializer = new JsonSerializer();
				dynamic deserialized = serializer.Deserialize(file, type);
				foreach (var o in deserialized)
				{
					data.Add(new object[] { o });
				}
				return data;
			}
		}

		public JsonDataAttribute(params string[] pathParts)
		{
			filePath = SharedTestUtilities.GetTestDataFilePath(pathParts);
		}

		private void CheckFile()
		{
			if (!File.Exists(filePath))
			{
				throw new ArgumentException($"Could not find test data file: {filePath}");
			}
		}

		private void CheckMethod(MethodInfo testMethod)
		{
			if (testMethod == null)
			{
				throw new ArgumentNullException(nameof(testMethod));
			}
		}

		private Type GetTestDataType(MethodInfo testMethod)
		{
			var testDataTypes = testMethod.GetParameters()
				.Select(p => p.ParameterType)
				.ToArray();
			return typeof(List<>).MakeGenericType(testDataTypes);
		}
	}
}
