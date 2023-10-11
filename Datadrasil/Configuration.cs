using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization.ObjectGraphTraversalStrategies;

namespace Datadrasil
{
	public class Configuration
	{
		private readonly FormatHandlerManager fh;

		public Configuration()
		{
		}

		public Configuration(FormatHandlerManager initFormatHandler)
		{
			fh = initFormatHandler;
		}

		public IEnumerable<object> ParseConfiguration(string filePath)
		{
			return new List<object>();
		}

		public void SaveConfiguration(string filePath, IEnumerable<object> config)
		{
			
		}
	}
}
