using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Datadrasil.FormatHandlers;
using YamlDotNet.Serialization;

namespace Datadrasil
{
    internal class YAMLFormatHandler : IFormatHandler
	{
		/// <summary>
		///	YAML data reading logic that returns a list of objects.
		/// </summary>
		/// <param name="filepath">File to be serialized</param>
		/// <returns>List of objects parsed from the YAML data<returns>
		public List<DataRepresentation> ReadData(string filePath)
		{
			try
			{
				using (var stream = new FileStream(filePath, FileMode.Open))
				{
					var deserializer = new Deserializer();
					var yamlObject = deserializer.Deserialize<List<DataRepresentation>>(new StreamReader(stream));
					return yamlObject ?? new List<DataRepresentation>();
				}
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException("Error occurred during YAML deserialization.", ex);
			}
		}
		/// <summary>
		/// Writes YAML data to a new file. 
		/// To be used for the final sorted output,
		/// where the "data" is the sorted list
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="data"></param>
		public void WriteData(string filePath, List<DataRepresentation> data)
		{
			var serializer = new SerializerBuilder().Build();
			string yamlData = serializer.Serialize(data);

			File.WriteAllText(filePath, yamlData);
		}
	}
}
