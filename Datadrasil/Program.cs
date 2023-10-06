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

	internal static class Program
	{
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

			IFormatHandler json = new JSONFormatHandler();
			IFormatHandler xml = new XMLFormatHandler();
			IFormatHandler yaml = new YAMLFormatHandler();

			// Serialize to JSON
			json.WriteData(jsonFilePath, dataToSerialize);

			// Serialize to XML
			xml.WriteData(xmlFilePath, dataToSerialize);

			// Serialize to YAML
			yaml.WriteData(yamlFilePath, dataToSerialize);

			// Read and Display Deserialized Data
			DisplayDeserializedData("JSON", json, jsonFilePath);
			DisplayDeserializedData("XML", xml, xmlFilePath);
			DisplayDeserializedData("YAML", yaml, yamlFilePath);
		}

		private static void DisplayDeserializedData(string format, IFormatHandler formatHandler, string filePath)
		{
			List<object> deserializedData = formatHandler.ReadData(filePath);

			Console.WriteLine($"Deserialized {format} Data:");
			foreach (var item in deserializedData)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine(); // Add a line break for clarity
		}
	}
}
