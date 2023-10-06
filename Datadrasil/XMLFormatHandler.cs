using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Datadrasil
{
	public class XMLFormatHandler : IFormatHandler
	{
		public List<object> ReadData(string filePath)
		{
			if (!File.Exists(filePath))
			{
				// Handle the case where the file doesn't exist
				return new List<object>();
			}

			using (var reader = new StreamReader(filePath))
			{
				var serializer = new XmlSerializer(typeof(List<object>));

				try
				{
					var parsedData = (List<object>)serializer.Deserialize(reader);
					return parsedData ?? new List<object>();
				}
				catch (InvalidOperationException)
				{
					// Handle the case where deserialization fails
					return new List<object>();
				}
			}
		}

		public void WriteData(string filePath, List<object> data)
		{
			if (data == null || data.Count == 0)
			{
				// Handle empty data or avoid unnecessary serialization
				return;
			}

			using (var writer = new StreamWriter(filePath))
			{
				var types = data.Select(item => item.GetType()).Distinct().ToArray();
				var serializer = new XmlSerializer(typeof(List<object>), types);
				serializer.Serialize(writer, data);
			}
		}
	}
}
