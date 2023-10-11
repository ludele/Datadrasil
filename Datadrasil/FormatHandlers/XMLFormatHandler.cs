using Datadrasil.FormatHandlers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Datadrasil
{
    public class XMLFormatHandler : IFormatHandler
	{
		public List<object> ReadData(string filePath)
		{
			if (!File.Exists(filePath))
			{
				return new List<object>();
			}
			try
			{
				using (var stream = new FileStream(filePath, FileMode.Open))
				{
					var document = XDocument.Load(stream);
					return new List<object> { document };
				}
			}
			catch (Exception ex)
			{
				throw new ("Error occurred during XML deserialization.", ex);
			}

		}

		public void WriteData(string filePath, List<object> data)
		{
			if (data == null || data.Count == 0)
			{
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
