using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace Datadrasil.FormatHandlers
{
    public class JSONFormatHandler : IFormatHandler
    {
        /// <summary>
        ///	json data reading logic that returns a list of objects.
        /// </summary>
        /// <param name="filepath">File to be serialized</param>
        /// <returns>list of objects parsed from the json data<returns>
        public List<DataRepresentation> ReadData(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);

            List<DataRepresentation>? parsedData = JsonConvert.DeserializeObject<List<DataRepresentation>>(jsonContent);

			return parsedData ?? new List<DataRepresentation>();
        }

        /// <summary>
        /// Writes JSON data to a new file. 
        /// To be used for the final sorted output,
        /// where the "data" is the sorted list
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="data"></param>
        public void WriteData(string filePath, List<DataRepresentation> data)
        {
            string jsonData = JsonConvert.SerializeObject(data);

            File.WriteAllText(filePath, jsonData);
        }
    }
}
