using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	public class CommandLineUI : MenuItem
    {
        public const string tab = "     ";
        public FormatHandlerManager fh = new FormatHandlerManager();

		private readonly List<MenuItem> menuItems = new List<MenuItem>
		{
			new MenuItem("1. Quit", () => Environment.Exit(0)),
		};

		public override string DisplayText => "Main Menu";

		public override void Execute()
		{
			while (true)
			{
				ShowMenu();
				string userInput = Console.ReadLine();

				if (int.TryParse(userInput, out int index) && index >= 1 && index <= menuItems.Count)
				{
					menuItems[index - 1].Execute();
				}
				else
				{
					Console.WriteLine("Invalid option. Please try again.");
				}
			}
		}

		private void ShowMenu()
		{
			Console.WriteLine(DisplayText);

			for (int i = 0; i < menuItems.Count; i++)
			{
				Console.WriteLine($"{menuItems[i].DisplayText}");
			}

			Console.Write("Select an option: ");
		}

		public CommandLineUI(string initDisplayText, Action initAction) : base(initDisplayText, initAction)
		{
		}
	}
}
