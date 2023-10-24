using System;
using System.Collections.Generic;
using System.Linq;

namespace Datadrasil
{
    /// <summary>
    /// Represents the configuration interpreter for sorting data.
    /// </summary>
    public class Configuration
	{
		private readonly FormatHandlerManager formatHandlerManager;
		public DataRepresentation dataRepresentation; 

		/// <summary>
		/// Initializes a new instance of the Configuration class.
		/// </summary>
		/// <param name="formatHandlerManager">The format handler manager.</param>
		public Configuration(FormatHandlerManager initFormatHandlerManager)
		{
			this.formatHandlerManager = initFormatHandlerManager;
		}

		/// <summary>
		/// Interprets the configuration file for sorting data.
		/// </summary>
		/// <param name="configurationFilePath">The path to the configuration file.</param>
		public void ParseConfiguration(string configurationFilePath)
		{
			try
			{
				string sortingKey = GetSortingKey();
				bool isNumericKey = IsNumericKey(sortingKey);
				bool ascendingOrder = GetSortOrder();

				SortData(sortingKey, isNumericKey, ascendingOrder);

				Console.WriteLine("Sorting process completed successfully!");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error during configuration interpretation: {ex.Message}");
			}
		}

		public static void ConfigureOptions(bool isAscending)
		{
			if (isAscending)
			{
                Console.WriteLine("Ascending");
            }
        }

		private string GetSortingKey()
		{
			Console.WriteLine("Enter the key for sorting:");
			return Console.ReadLine();
		}

		private bool IsNumericKey(string key)
		{
			return double.TryParse(key, out _);
		}

		private bool GetSortOrder()
		{
			Console.WriteLine("Enter 'asc' for ascending order or 'desc' for descending order:");
			string order = Console.ReadLine().ToLower();
			return order == "asc";
		}

		public void SortData(string sortingKey, bool isNumericKey, bool ascendingOrder)
		{
			foreach (DataCategory category in dataRepresentation.Categories)
			{
				List<DataItem> sortedItems;

				if (isNumericKey)
				{
					sortedItems = ascendingOrder
						? category.Items.OrderBy(item => Convert.ToDouble(item.Properties.FirstOrDefault(kvp => kvp.Name == sortingKey)?.Value)).ToList()
						: category.Items.OrderByDescending(item => Convert.ToDouble(item.Properties.FirstOrDefault(kvp => kvp.Name == sortingKey)?.Value)).ToList();
				}
				else
				{
					sortedItems = ascendingOrder
						? category.Items.OrderBy(item => item.Properties.FirstOrDefault(kvp => kvp.Name == sortingKey)?.Value?.ToString()).ToList()
						: category.Items.OrderByDescending(item => item.Properties.FirstOrDefault(kvp => kvp.Name == sortingKey)?.Value?.ToString()).ToList();
				}

				category.Items = sortedItems;
			}
		}
	}
}
