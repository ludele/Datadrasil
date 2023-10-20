using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	public abstract class MenuComponent
	{
		public string DisplayText { get; protected set; }
		public virtual List<MenuComponent> GetSubMenu() => new List<MenuComponent>();

		public abstract void Execute();
	}
}
