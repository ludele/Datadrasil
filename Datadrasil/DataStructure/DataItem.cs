using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	public class DataItem
	{
		private Dictionary<string, object> properties = new Dictionary<string, object>();

		public Dictionary<string, object> Properties
		{
			get { return properties; }
			set { properties = value; }
		}

		public DataItem()
		{
			properties = new Dictionary<string, object>();
		}
	}
}
