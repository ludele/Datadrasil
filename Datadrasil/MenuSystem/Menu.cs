﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
    public class Menu : MenuComponent
    {
        private readonly Stack<List<MenuComponent>> menuStack;
        private List<MenuComponent> currentMenu;

        List<MenuComponent> MainMenu = MainMenus.Main();

        public Menu(IEnumerable<MenuComponent> customMenu = null)
        {
            currentMenu = customMenu?.ToList() ?? MainMenu;
            menuStack = new Stack<List<MenuComponent>>();
        }

        public override void Execute()
        {
            Console.WriteLine(); // To create some space, options starts to appear from the second row.
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
						DisplayText = menuItem.GetSubMenu().FirstOrDefault()?.DisplayText ?? "Main MainMenus";
					}
                    else
                    {
                        if (menuStack.Count > 0)
                        {
                            currentMenu = menuStack.Pop();
							DisplayText = currentMenu.LastOrDefault()?.DisplayText ?? "Main MainMenus";
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