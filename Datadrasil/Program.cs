using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using Datadrasil.FormatHandlers;

namespace Datadrasil
{

	public class Program
	{
		public static FormatHandlerManager fh = new FormatHandlerManager();
		public static void Main(string[] args)
		{
			List<DataRepresentation> dataToSerialize = GetUserData();

			string jsonFilePath = "data.json";
			string yamlFilePath = "data.yaml";
			string xmlFilePath = "data.xml";

			fh.WriteData(jsonFilePath, dataToSerialize);
			fh.WriteData(yamlFilePath, dataToSerialize);

			DisplayDeserializedData("JSON", jsonFilePath);
			DisplayDeserializedData("YAML", yamlFilePath);
			DisplayDeserializedData("XML", xmlFilePath);

			Console.ReadLine();
		}
		private static List<DataRepresentation> GetUserData()
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

					DataItem item = new DataItem();

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

						item.Properties.Add(propertyName, propertyValue);
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

			foreach (var dataRepresentation in deserializedData)
			{
				foreach (var category in dataRepresentation.Categories)
				{
					Console.WriteLine($"Category: {category.CategoryName}");

					foreach (var item in category.Items)
					{
						foreach (var property in item.Properties)
						{
							Console.WriteLine($"{property.Key}: {property.Value}");
						}
					}
				}
			}

			Console.WriteLine();
		}
	}

}