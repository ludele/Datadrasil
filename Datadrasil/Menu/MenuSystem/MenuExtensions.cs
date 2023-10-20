using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	public class MenuExtensions
	{
		public static MenuComponent CreateMenuComponent(string displayText, Action action)
		{
			return new MenuItem(displayText, action);
		}
	}
}
