using System;
using System.Collections.Generic;
using System.Data;
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
			while (true)
			{
				try
				{
					new MenuManager().Execute();
				}
				catch (Exception ex)
				{
					ErrorLogger.LogError(ex);
					Console.WriteLine("Some error accorred, the program will exit the menu");
					System.Threading.Thread.Sleep(1000);
					Console.Clear();
					continue;
				}
			}
		}
	}
}
