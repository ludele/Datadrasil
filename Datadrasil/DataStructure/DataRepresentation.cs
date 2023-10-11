using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	public class DataRepresentation
	{
		private List<DataCategory> categories = new List<DataCategory>();

		public List<DataCategory> Categories
		{
			get { return categories; }
			set { categories = value; }
		}

		public DataRepresentation() 
		{
			categories = new List<DataCategory>();	
		}
	}
}
