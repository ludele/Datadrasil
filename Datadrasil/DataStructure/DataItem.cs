using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	public class DataItem
	{
		public string PropertySetName { get; set; }
		/// <summary>
		/// A dictionary containing each key name and item value
		/// </summary>
		private Dictionary<string, object> properties = new Dictionary<string, object>();

		/// <summary>
		/// Constructor gets/set the dictionary
		/// </summary>
		public Dictionary<string, object> Properties
		{
			get { return properties; }
			set { properties = value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataItem"/> class
		/// </summary>
		public DataItem()
		{
			properties = new Dictionary<string, object>();
		}
	}
}
