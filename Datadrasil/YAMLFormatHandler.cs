using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using YamlDotNet.Serialization;

namespace Datadrasil
{
	internal class YAMLFormatHandler : IFormatHandler
	{
		/// <summary>
		///	YAML data reading logic that returns a list of objects.
		/// </summary>
		/// <param name="filepath"></param>
		/// <returns>List of objects parsed from the YAML data<returns>
		public List<object> ReadData(string filePath)
		{
			string yamlContent = File.ReadAllText(filePath);

			var deserializer = new DeserializerBuilder().Build();
			object parsedData = deserializer.Deserialize(new StringReader(yamlContent));

			if (parsedData is IEnumerable<object> enumerableData)
			{
				return enumerableData.ToList();
			}

			return new List<object> { parsedData };
		}
		/// <summary>
		/// Writes YAML data to a new file. 
		/// To be used for the final sorted output,
		/// where the "data" is the sorted list
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="data"></param>
		public void WriteData(string filePath, List<object> data)
		{
			var serializer = new SerializerBuilder().Build();
			string yamlData = serializer.Serialize(data);

			File.WriteAllText(filePath, yamlData);
		}
	}
}
