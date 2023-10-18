using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Datadrasil
{
	internal class Program
	{
		public static void Main()
		{
			CommandLineUI commandLineUI = new CommandLineUI("Some Display Text", () => Console.WriteLine("Action executed"));

			commandLineUI.Execute();
		}
	}
}
