using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	public class MenuItem
	{
		public virtual string DisplayText { get; }
		private Action Action { get; }

		public MenuItem(string initDisplayText, Action initAction)
		{
			DisplayText = initDisplayText;
			Action = initAction;
		}

		public virtual void Execute()
		{
			Action?.Invoke();
		}
	}
}
