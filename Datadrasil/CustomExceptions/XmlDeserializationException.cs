using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil.CustomExceptions
{
	public class XmlDeserializationException : Exception
	{
		public XmlDeserializationException() { }
		public XmlDeserializationException(string message) 
			: base(message) { }
		public XmlDeserializationException(string message, Exception innerException)
			: base(message, innerException) { }
	}
}
