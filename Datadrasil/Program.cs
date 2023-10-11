using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using Datadrasil.FormatHandlers;

namespace Datadrasil
{
    // Testing class
	public class Person
	{
		public string? Name { get; set; }
		public int Age { get; set; }
		public string? Personality { get; set; }
	}

	public class Test 
	{
		public string Name { get; set; }
		public int Value { get; set; }
	}

	public class Program
	{
		public static FormatHandlerManager fh = new FormatHandlerManager();
		public static void Main(string[] args) 
		{
			List<object> dataToSerialize = new List<object> 
			{
				new Person { Name = null, Age = 30 },
				new Person { Name = "Alice", Age = 25 },
				new Person { Name = "Sigge", Age = 432, Personality = "Snarky" },
				new Person { Name = "Alice", Age = 25 },
				new Person { Name = "Alice", Age = 25 },
				new Person { Name = "Alice", Age = 25 },
				new Person { Name = "Alice", Age = 25 },
				new Person { Name = "Rolf", Age = 413 },
				new Test {Name = "Banana", Value = 200 },
				new Test {Name = "Rat", Value = 1337 },
				new Test {Name = "Banana", Value = 200 }
			};

			string jsonFilePath = "data.json";
			string xmlFilePath = "data.xml";
			string yamlFilePath = "data.yaml";

			fh.WriteData(jsonFilePath, dataToSerialize);
			fh.WriteData(xmlFilePath, dataToSerialize);
			fh.WriteData(yamlFilePath, dataToSerialize);

			DisplayDeserializedData("JSON", jsonFilePath);
			DisplayDeserializedData("XML", xmlFilePath);
			DisplayDeserializedData("YAML", yamlFilePath);

			Console.ReadLine();
		}

		private static void DisplayDeserializedData(string format, string filePath)
		{
			List<object> deserializedData = fh.ReadData(filePath);

			Console.WriteLine($"Deserialized {format} Data:");
			foreach (var item in deserializedData)
			{
				if (item is List<object> list)
				{
					foreach (var listItem in list)
					{
						if (listItem is Dictionary<object, object> dictionary)
						{
							foreach (var entry in dictionary)
							{
								Console.WriteLine($"{entry.Key}: {entry.Value}");
							}
						}
						else
						{
							Console.WriteLine(listItem);
						}
					}
				}
				else
				{
					Console.WriteLine(item);
				}
			}
			Console.WriteLine(); 
		}
	}
}