using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace Datadrasil
{
	public class DataCreator
	{
		public const string tab = "     ";
		public static FormatHandlerManager<DataRepresentation> formatHandler = new FormatHandlerManager<DataRepresentation>();
		public static string ChooseFormatAndFileName(string format)
		{
            Console.Write("\nEnter filename (without extension)\n: ");
			string input = Console.ReadLine();

			string fileName = $"{input}.{format.ToLower()}";

			return fileName;
        }
		
		public static void Run(string format)
		{
			string fileName = ChooseFormatAndFileName(format);
			List<DataRepresentation> data = CreateData();

			formatHandler.WriteData(fileName, data);

			DisplayData(data);

			Console.ReadLine();
		}

		static string[] ListFiles()
		{
			string directory = Directory.GetCurrentDirectory();

			string[] files = Directory.GetFiles(directory);

			string[] filteredFiles = files
				.Where(file => file.EndsWith(".xml", StringComparison.OrdinalIgnoreCase) ||
							   file.EndsWith(".yaml", StringComparison.OrdinalIgnoreCase) ||
							   file.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
				.ToArray();

			return filteredFiles;
		}

		private static List<DataRepresentation> CreateData()
		{
			List<DataRepresentation> data = new List<DataRepresentation>();

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
				data.Add(dataRepresentation);
			}

			return data;
		}
		private static void DisplayData(List<DataRepresentation> data)
		{
			string output = "";

			foreach (DataRepresentation dataRepresentation in data)
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