using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
    public class DataCategory
    {
        private string CategoryName { get; set; }
        private List<DataItem> items = new List<DataItem>();

		public List<DataItem> Items 
		{
			get { return items; }
			set { items = value; }
		}

		public DataCategory()
        {
            items = new List<DataItem>();
        }
    }
}
