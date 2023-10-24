using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
    public class MenuBuilder
    {
        private string displayText;
        private Action action;
        private List<MenuComponent> subMenu;

        public MenuBuilder SetDisplayText(string text)
        {
            displayText = text;
            return this;
        }

        public MenuBuilder SetAction(Action menuAction)
        {
            action = menuAction;
            return this;
        }

        public MenuBuilder AddSubMenu(MenuComponent submenu)
        {
            subMenu ??= new List<MenuComponent>();
            subMenu.Add(submenu);
            return this;
        }

        public MenuComponent Build()
        {
            return new MenuItem(displayText, action, subMenu);
        }
    }
}
