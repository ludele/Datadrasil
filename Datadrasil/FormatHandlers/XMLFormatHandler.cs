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
		/// <summary>
		///	XML data reading logic that returns a list of objects.
		/// </summary>
		/// <param name="filePath">File to be serialized</param>
		/// <returns>list of objects parsed from the XML data</returns>
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
		/// <summary>
		/// Writes XML data to a new file. 
		/// To be used for the final sorted output,
		/// where the "data" is the sorted list
		/// </summary>
		/// <param name="filePath">File to be created to written to</param>
		/// <param name="data">The seralized data</param>
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
