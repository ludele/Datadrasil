using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
    public class MenuManager : MenuComponent
    {
        private readonly Stack<List<MenuComponent>> menuStack;
        private List<MenuComponent> currentMenu;

        List<MenuComponent> MainMenu = Menu.Main();

        public MenuManager(IEnumerable<MenuComponent> customMenu = null)
        {
            currentMenu = customMenu?.ToList() ?? MainMenu;
            menuStack = new Stack<List<MenuComponent>>();
        }

        public override void Execute()
        {
            while (true)
            {
                ShowMenu();
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int index) && index >= 1 && index <= currentMenu.Count)
                {
                    MenuComponent selectedMenuComponent = currentMenu[index - 1];
                    selectedMenuComponent.Execute();

                    if (selectedMenuComponent is MenuItem menuItem && menuItem.HasSubMenu)
                    {
                        menuStack.Push(currentMenu);
						DisplayText = menuItem.GetSubMenu().FirstOrDefault()?.DisplayText ?? "Main Menu";
					}
                    else
                    {
                        if (menuStack.Count > 0)
                        {
                            currentMenu = menuStack.Pop();
							DisplayText = currentMenu.LastOrDefault()?.DisplayText ?? "Main Menu";
						}
                        else
                        {
                            currentMenu = MainMenu;
                            DisplayText = "Main menu";
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        private void ShowMenu()
        {
            for (int i = 0; i < currentMenu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {currentMenu[i].DisplayText}");
            }

            Console.Write("Select an option: ");
        }
    }
}
