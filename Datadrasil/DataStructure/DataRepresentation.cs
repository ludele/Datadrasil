using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	public class DataRepresentation
	{
		/// <summary>
		/// List of Datacategories, which also includes a list of data items.
		/// </summary>
		private List<DataCategory> categories = new List<DataCategory>();

		/// <summary>
		/// Constructor gets/sets the category
		/// </summary>
		public List<DataCategory> Categories
		{
			get { return categories; }
			set { categories = value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataCategory"/> class
		/// </summary>
		public DataRepresentation()
		{
			categories = new List<DataCategory>();
		}
	}
}
