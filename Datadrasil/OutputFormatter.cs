using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using Datadrasil.FormatHandlers;
using Datadrasil.MenuSystem;

namespace Datadrasil
{
	public class OutputFormatter
	{
		public const string tab = "     ";
		private static readonly MenuBuilder menuBuilder = new MenuBuilder();
		public static FormatHandlerManager fh = new FormatHandlerManager();
		public static void Run()
		{
			List<DataRepresentation> dataToSerialize = CreateSerializedData();

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

		public static List<DataRepresentation> CreateSerializedData()
		{
			List<DataRepresentation> dataToSerialize = new List<DataRepresentation>();

			while (true)
			{
				MenuComponent categoryMenu = CreateMenu("Enter Category Name to serialize", categoryName =>
				{
					if (categoryName.ToLower() == "q")
					{
						return;
					}

					DataRepresentation dataRepresentation = new DataRepresentation();
					DataCategory category = new DataCategory { CategoryName = categoryName };

					ProcessItems(category);

					dataRepresentation.Categories.Add(category);
					dataToSerialize.Add(dataRepresentation);
				});

				categoryMenu.Execute();
			}

			return dataToSerialize;
		}

		private static void ProcessItems(DataCategory category)
		{
			while (true)
			{
				MenuComponent itemMenu = CreateMenu("Enter Item Name to serialize", itemName =>
				{
					if (itemName.ToLower() == "q")
					{
						return;
					}

					DataItem item = new DataItem { PropertySetName = itemName };

					ProcessProperties(item);

					category.Items.Add(item);
				});

				itemMenu.Execute();
			}
		}

		private static void ProcessProperties(DataItem item)
		{
			while (true)
			{
				MenuComponent propertyMenu = CreateMenu("Enter Property Name to serialize", propertyName =>
				{
					if (propertyName.ToLower() == "q")
					{
						return;
					}

					Console.Write($"Property Value for {propertyName}: ");
					string propertyValue = Console.ReadLine();

					item.Properties.Add(new KeyValue { Name = propertyName, Value = propertyValue });
				});

				propertyMenu.Execute();
			}
		}

		private static MenuComponent CreateMenu(string displayText, Action<string> action)
		{
			return menuBuilder.SetDisplayText(displayText)
				.SetAction(() => action(Console.ReadLine()))
				.Build();
		}

		public static void DisplayDeserializedData(string format, string filePath)
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