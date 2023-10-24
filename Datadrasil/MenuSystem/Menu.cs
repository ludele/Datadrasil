using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	public class Menu
	{
		/// <summary>
		/// A list that just returns the man
		/// </summary>
		/// <returns>Returns the main menu list, of the MenuComponent data type</returns>
		public static List<MenuComponent> Main()
		{
			MenuComponent ConfigurationMenu = new MenuBuilder()
				.SetDisplayText("Configuration Menu")
				.AddSubMenu(new MenuItem("Test", () => Console.WriteLine("Hello, World!")))
				.AddSubMenu(new MenuItem("Ascending", () => { Configuration.ConfigureOptions(true); }))
				.AddSubMenu(new MenuItem("Descending", () => { Configuration.ConfigureOptions(false); }))
				.Build();

			return new List<MenuComponent>
			{
				new MenuItem("Quit", () => Environment.Exit(0)),
				new MenuItem("Create files", () => Testing.Run()),
				new MenuItem("Clear screen", () => Console.Clear()),
				ConfigurationMenu,  // Using the built submenu here
			};
		}
	}
}
