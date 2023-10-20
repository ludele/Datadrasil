using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using Datadrasil.FormatHandlers;

namespace Datadrasil
{
	public class Testing
	{
		public const string tab = "     ";
		public static FormatHandlerManager fh = new FormatHandlerManager();
		public static void Run()
		{
			List<DataRepresentation> dataToSerialize = CreateSeralizedData();

			string jsonFilePath = "data.json";
			string yamlFilePath = "data.yaml";
			string xmlFilePath = "data.xml";

			fh.WriteData(jsonFilePath, dataToSerialize);
			fh.WriteData(yamlFilePath, dataToSerialize);
			fh.WriteData(xmlFilePath, dataToSerialize);

			DisplayDeserializedData("JSON", jsonFilePath);
			DisplayDeserializedData("YAML", yamlFilePath);
			DisplayDeserializedData("XML", xmlFilePath);

			Console.ReadLine();
		}
		private static List<DataRepresentation> CreateSeralizedData()
		{
			List<DataRepresentation> dataToSerialize = new List<DataRepresentation>();

			while (true)
			{
				Console.Write("Category Name to serialize (enter 'q' to quit): ");
				string categoryName = Console.ReadLine();

				if (categoryName == "q")
				{
					break;
				}

				DataRepresentation dataRepresentation = new DataRepresentation();

				DataCategory category = new DataCategory { CategoryName = categoryName };

				while (true)
				{
					Console.Write("Item Name to serialize (enter 'q' to go back to categories): ");
					string itemName = Console.ReadLine();

					if (itemName == "q")
					{
						break;
					}

					DataItem Dataitem = new DataItem();
					DataItem item = new DataItem { PropertySetName = itemName };

					while (true)
					{
						Console.Write("Property Name to serialize (enter 'q' to go back to items): ");
						string propertyName = Console.ReadLine();

						if (propertyName == "q")
						{
							break;
						}

						Console.Write($"Property Value for {propertyName}: ");
						string propertyValue = Console.ReadLine();

						item.Properties.Add(new KeyValue { Name = propertyName, Value = propertyValue });
					}

					category.Items.Add(item);
				}

				dataRepresentation.Categories.Add(category);
				dataToSerialize.Add(dataRepresentation);
			}

			return dataToSerialize;
		}
		private static void DisplayDeserializedData(string format, string filePath)
		{
			List<DataRepresentation> deserializedData = fh.ReadData(filePath);

			Console.WriteLine($"Deserialized {format} Data:");

			string output = "";

			foreach (DataRepresentation dataRepresentation in deserializedData)
			{
				foreach (DataCategory category in dataRepresentation.Categories)
				{
					output += $"\n{category.CategoryName}: \n";

					foreach (DataItem item in category.Items)
					{
						output += $"{tab}{item.PropertySetName}: \n";

						foreach (KeyValue property in item.Properties)
						{
							output += $"{tab}{tab}{property.Name}: {property.Value}\n";
						}
					}
				}
			}
			Console.WriteLine(output);
		}
	}
}