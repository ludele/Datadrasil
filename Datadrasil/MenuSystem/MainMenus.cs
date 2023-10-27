using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	public class MainMenus
	{
		/// <summary>
		/// A list that just returns the man
		/// </summary>
		/// <returns>Returns the main menu list, of the MenuComponent data type</returns>
		public static List<MenuComponent> Main()
		{

			MenuBuilder CreateFileMenu = new MenuBuilder().SetDisplayText("Choose Serializer and Filename");

			string[] formats = { "JSON", "XML", "YAML" };

			foreach (string format in formats)
			{
				CreateFileMenu.AddSubMenu(
					new MenuBuilder()
						.SetDisplayText(format)
						.SetAction(() => DataCreator.Run(format))
						.Build()
				);
			}
			MenuComponent FileMenu = CreateFileMenu.Build();

			MenuComponent SortingMenu = new MenuBuilder()
				.SetDisplayText("Sorting options")
				// .AddSubMenu(new MenuItem("Sort Data", SortData))
				.Build();

			MenuComponent ConfigurationMenu = new MenuBuilder()
				.SetDisplayText("Configuration options")
				.AddSubMenu(new MenuItem("Test", () => Console.WriteLine("Hello, World!")))
				.AddSubMenu(new MenuItem("Ascending", () => { Configuration.ConfigureOptions(true); }))
				.AddSubMenu(new MenuItem("Descending", () => { Configuration.ConfigureOptions(false); }))
				.Build();

			return new List<MenuComponent>
			{
				new MenuItem("Quit", () => Environment.Exit(0)),
				FileMenu,
				//new MenuItem("Show current list", () => DataCreator.DisplayData()),
				new MenuItem("Clear screen", () => Console.Clear()),
				new MenuItem("Read serialized data", () => Console.Clear()),
				ConfigurationMenu,
			};
		}
	}
}
