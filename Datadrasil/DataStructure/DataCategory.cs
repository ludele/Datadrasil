using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
    public class DataCategory
    {
        /// <summary>
        /// The name of the category
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// The list of items within the category
        /// </summary>
        private List<DataItem> items = new List<DataItem>();

        /// <summary>
        /// Gets/sets the list of the items in the category
        /// </summary>
		public List<DataItem> Items 
		{
			get { return items; }
			set { items = value; }
		}

		/// <summary>
		/// Initalizes a new instance of the <see cref="DataCategory"/> class.
		/// </summary>
		public DataCategory()
        {
            items = new List<DataItem>();
        }
    }
}
