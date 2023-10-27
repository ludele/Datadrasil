using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	public class DataSorter
	{
		private DataRepresentation dataRepresentation;

		public DataSorter(DataRepresentation data)
		{
			dataRepresentation = data;
		}

		public DataRepresentation SortData(string sortingKey, bool isNumericKey, bool isAscending)
		{
			DataRepresentation sortedDataRepresentation = new DataRepresentation();

			foreach (DataCategory category in dataRepresentation.Categories)
			{
				List<DataItem> sortedItems;

				if (isNumericKey)
				{
					sortedItems = isAscending
						? category.Items.OrderBy(item => Convert.ToDouble(item.Properties.FirstOrDefault(kvp => kvp.Name == sortingKey)?.Value)).ToList()
						: category.Items.OrderByDescending(item => Convert.ToDouble(item.Properties.FirstOrDefault(kvp => kvp.Name == sortingKey)?.Value)).ToList();
				}
				else
				{
					sortedItems = isAscending
						? category.Items.OrderBy(item => item.Properties.FirstOrDefault(kvp => kvp.Name == sortingKey)?.Value?.ToString()).ToList()
						: category.Items.OrderByDescending(item => item.Properties.FirstOrDefault(kvp => kvp.Name == sortingKey)?.Value?.ToString()).ToList();
				}

				// Add the sorted items to the new DataRepresentation instance
				sortedDataRepresentation.Categories.Add(new DataCategory { CategoryName = category.CategoryName, Items = sortedItems });
			}

			return sortedDataRepresentation;
		}
	}
}
