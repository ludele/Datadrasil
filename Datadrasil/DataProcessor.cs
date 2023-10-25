using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	public class DataProcessor
	{
		private readonly FormatHandlerManager<DataRepresentation> formatHandler;
		private readonly Dictionary<string, DataRepresentation> savedLists;
		private readonly Configuration configuration;

		public DataProcessor(FormatHandlerManager<DataRepresentation> initFormatHandler)
		{
			this.formatHandler = initFormatHandler;
			this.savedLists = new Dictionary<string, DataRepresentation>();
			this.configuration = new Configuration(formatHandler);
		}

		public void SaveData(string identifier, DataRepresentation data)
		{
			savedLists[identifier] = data;
		}

		public DataRepresentation LoadDataRepresentation(string identifier)
		{
			if (savedLists.TryGetValue(identifier, out DataRepresentation data))
			{
				return data;
			}

			throw new ArgumentException($"List with identifier '{identifier}' not found.");
		}

		public void SortAndSerializeData(string configurationFilePath, string outputFilePath, string listIdentifier)
		{
			if (savedLists.TryGetValue(listIdentifier, out DataRepresentation data))
			{
				try
				{
					configuration.dataRepresentation = data;
					configuration.ParseConfiguration(configurationFilePath);
					formatHandler.WriteData(outputFilePath, new List<DataRepresentation> { data });
				}
				catch (Exception ex)
				{
					// Handle any exceptions during sorting and serialization
					Console.WriteLine($"Error: {ex.Message}");
				}
			}
			else
			{
				// Handle the case where the identifier is not found
				Console.WriteLine($"List with identifier '{listIdentifier}' not found.");
			}
		}
	}
}
