using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	/// <summary>
	/// Interface to set a reference for the format handlers,
	/// each format handler has a read, and write function
	/// that is definied here.
	/// </summary>
	public interface IFormatHandler
	{
		/// <summary>
		/// Placeholder method to seralize data
		/// </summary>
		/// <param name="filePath">File to be seralized</param>
		/// <returns></returns>
		List<object> ReadData(string filePath);
		
		/// <summary>
		/// Placeholder method to deseralize data
		/// </summary>
		/// <param name="filePath">File that deseralized data can be written to</param>
		/// <param name="data">The data to be deseralized</param>
		void WriteData(string filePath, List<object> data);
	}
}
