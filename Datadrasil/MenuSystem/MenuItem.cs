using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
    public class MenuItem : MenuComponent
    {
        private readonly Action action;
        private readonly List<MenuComponent> subMenu;

        public bool HasSubMenu => subMenu.Count > 0;

        public MenuItem(string initDisplayText, Action? initAction = null, List<MenuComponent>? subMenu = null)
        {
            DisplayText = initDisplayText;
            action = initAction ?? (() => Console.Clear());
            this.subMenu = subMenu ?? new List<MenuComponent>();
        }

        public override void Execute()
        {
            Console.Clear();
            action();
            Console.WriteLine("");
            if (HasSubMenu)
            {
                Menu subMenuUI = new Menu(subMenu);
                subMenuUI.Execute();
            }
        }
    }
}
