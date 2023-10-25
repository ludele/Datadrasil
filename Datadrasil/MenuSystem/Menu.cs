﻿using System;
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

			MenuComponent ChooseSeralizer = new MenuBuilder()
				.SetDisplayText("ChooseSeralizer")
				.AddSubMenu(new MenuItem("JSON", () => {  }))
				.AddSubMenu(new MenuItem("XML", () => {  }))
				.AddSubMenu(new MenuItem("YAML", () => {  }))
				.Build();

			MenuComponent CrashTest = new MenuBuilder()
				.SetDisplayText("Test Menu")
				.AddSubMenu(new MenuItem("Test", () => throw new Exception("test")))
				.Build();

			MenuComponent ConfigurationMenu = new MenuBuilder()
				.SetDisplayText("Configuration Menu")
				.AddSubMenu(new MenuItem("Test", () => Console.WriteLine("Hello, World!")))
				.AddSubMenu(new MenuItem("Ascending", () => { Configuration.ConfigureOptions(true); }))
				.AddSubMenu(new MenuItem("Descending", () => { Configuration.ConfigureOptions(false); }))
				.AddSubMenus(CrashTest)
				.Build();

			return new List<MenuComponent>
			{
				new MenuItem("Quit", () => Environment.Exit(0)),
				new MenuItem("Create files", () => Testing.Run()),
				new MenuItem("Clear screen", () => Console.Clear()),
				ConfigurationMenu,
			};
		}
	}
}
