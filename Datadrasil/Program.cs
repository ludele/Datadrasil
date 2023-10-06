using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	internal static class Program
	{
		public static void Main(string[] args)
		{
			// Sample data to serialize
			List<object> dataToSerialize = new List<object>
			{
				new { Name = "John", Age = 30 },
				new { Name = "Alice", Age = 25 }
			};

			// File path
			string jsonFilePath = "data.json";

			// Create JSON format handler
			IFormatHandler jsonFormatHandler = new JSONFormatHandler();

			// Serialize to JSON
			jsonFormatHandler.WriteData(jsonFilePath, dataToSerialize);

			// Deserialize from JSON
			List<object> jsonDeserializedData = jsonFormatHandler.ReadData(jsonFilePath);

			// Display the result
			Console.WriteLine("JSON Deserialized Data:");
			foreach (var item in jsonDeserializedData)
			{
				Console.WriteLine(item);
			}
		}
	}
}