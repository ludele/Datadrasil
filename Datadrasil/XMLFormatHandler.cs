using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Datadrasil.CustomExceptions;

namespace Datadrasil
{
	public class XMLFormatHandler : IFormatHandler
	{
		/// <summary>
		///	XML data reading logic that returns a list of objects.
		/// </summary>
		/// <param name="filepath"></param>
		/// <returns>list of objects parsed from the json data<returns>
		public List<object> ReadData(string filePath)
		{
			try
			{
				using (var fileStream = new FileStream(filePath, FileMode.Open))
				{
					var serializer = new XmlSerializer(typeof(List<object>));
					object? deserializedObject = serializer.Deserialize(fileStream);
					return deserializedObject as List<object> ?? new List<object>();
				}
			}
			catch (XmlDeserializationException e)
			{
                Console.WriteLine($"Error reading data:	{e.Message}");
				return new List<object>();
            }
		}
		/// <summary>
		/// Writes XML data to a new file. 
		/// To be used for the final sorted output,
		/// where the "data" is the sorted list
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="data"></param>
		public void WriteData(string filePath, List<object> data)
		{
		}
	}
}
