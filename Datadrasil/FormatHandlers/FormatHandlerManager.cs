using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datadrasil.FormatHandlers;

namespace Datadrasil
{
    public class FormatHandlerManager
	{
		/// <summary>
		/// Dictionary of file path and format handlers.
		/// </summary>
		private readonly Dictionary<string, IFormatHandler> formatHandlers;

		/// <summary>
		/// Initializes a new instance of the FormatHandlerManager class,
		/// handling the redirection by creating links between format names and format handlers,
		/// ensuring automatic selection based on the file's format.
		/// </summary>
		public FormatHandlerManager()
		{
			formatHandlers = new Dictionary<string, IFormatHandler> 
			{
				{ ".json", new JSONFormatHandler() },
				{ ".xml", new XMLFormatHandler() },
				{ ".yaml", new YAMLFormatHandler() },
			};
		}

		/// <summary>
		/// Reads data from a file based on its extension by constructing
		/// the corresponding format handler for data reading.
		/// </summary>
		/// <param name="filePath">The path of the file to read.</param>
		/// <returns>A list of objects representing the data read by the format handler.</returns>
		/// <exception cref="NotSupportedException">Thrown if the file format is not supported.</exception>
		public List<DataRepresentation> ReadData(string filePath)
		{
			string fileExtension = Path.GetExtension(filePath);

			if (formatHandlers.TryGetValue(fileExtension, out var handler))
			{
				return handler.ReadData(filePath); 
			}
			else
			{
				throw new NotSupportedException($"File format {fileExtension} is not supported.");
			}
		}
		/// <summary>
		/// Writes data to a file based on its extension by constructing
		/// the corresponding format handler for data writing.
		/// </summary>
		/// <param name="filePath">The path of the file to write the data to.</param>
		/// <param name="data">The list of objects representing the data to be written.</param>
		/// <exception cref="NotSupportedException">Thrown if the file format is not supported.</exception>
		public void WriteData(string filePath, List<DataRepresentation> data)
		{
			string fileExtension = Path.GetExtension(filePath);

			if (formatHandlers.TryGetValue(fileExtension, out var handler))
			{
				handler.WriteData(filePath, data);
			}
			else
			{
				throw new NotSupportedException($"File format {fileExtension} is not supported.");
			}
		}
	}
}
