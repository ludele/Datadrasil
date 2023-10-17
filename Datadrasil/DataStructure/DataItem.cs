using System;
using System.Collections.Generic;
using System.Data;
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
		private List<KeyValue> properties = new List<KeyValue>();
		/// <summary>
		/// Constructor gets/set the dictionary
		/// </summary>
		public List<KeyValue> Properties
		{
			get { return properties; }
			set { properties = value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataItem"/> class
		/// </summary>
		public DataItem()
		{
			properties = new List<KeyValue>();
		}
	}
}
