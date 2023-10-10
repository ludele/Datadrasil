using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Datadrasil
{
	// Testing class
	[XmlInclude(typeof(Person))]
	public class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }
	}

	public class Program
	{
		public static FormatHandlerManager fh = new FormatHandlerManager();
		public static void Main(string[] args)
		{

			var dataToSerialize = new List<object>
			{
				new Person { Name = "John", Age = 30 },
				new Person { Name = "Alice", Age = 25 }
			};

			string jsonFilePath = "data.json";
			string xmlFilePath = "data.xml";
			string yamlFilePath = "data.yaml";

			// Serialize to JSON
			fh.WriteData(jsonFilePath, dataToSerialize);

			// Serialize to XML
			fh.WriteData(xmlFilePath, dataToSerialize);

			// Serialize to YAML
			fh.WriteData(yamlFilePath, dataToSerialize);

			// Read and Display Deserialized Data
			DisplayDeserializedData("JSON", jsonFilePath);
			DisplayDeserializedData("XML", xmlFilePath);
			DisplayDeserializedData("YAML", yamlFilePath);
		}

		private static void DisplayDeserializedData(string format, string filePath)
		{
			List<object> deserializedData = fh.ReadData(filePath);

			Console.WriteLine($"Deserialized {format} Data:");
			foreach (var item in deserializedData)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine(); // Add a line break for clarity
		}
	}
}
