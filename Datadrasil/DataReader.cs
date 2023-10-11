using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	public class DataReader
	{
		private readonly FormatHandlerManager fh;

		public DataReader(FormatHandlerManager initFormatHandler)
		{
			fh = initFormatHandler;
		}

		public List<object> ReadDataFromFile(string filePath)
		{
			return new List<object>();
		}

		public DataRepresentation RepresentData(List<object> data)
		{
			return new DataRepresentation();
		}
	}
}
