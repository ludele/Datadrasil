﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace Datadrasil
{
	public class JSONFormatHandler : IFormatHandler
	{
		/// <summary>
		///	json data reading logic that returns a list of objects.
		/// </summary>
		/// <param name="filepath"></param>
		/// <returns>list of objects parsed from the json data<returns>
		public List<object> ReadData(string filePath)
		{
			string jsonContent = File.ReadAllText(filePath);

			var parsedData = JsonConvert.DeserializeObject<List<object>>(jsonContent);

			return parsedData ?? new List<object>();

		}
		/// <summary>
		/// Writes JSON data to a new file. 
		/// To be used for the final sorted output,
		/// where the "data" is the sorted list
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="data"></param>
		public void WriteData(string filePath, List<object> data)
		{
			string jsonData = JsonConvert.SerializeObject(data);

			File.WriteAllText(filePath, jsonData);
		}
	}
}
