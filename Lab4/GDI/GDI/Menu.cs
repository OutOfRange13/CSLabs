using System;
using System.Collections.Generic;
using System.Drawing;

namespace GDI
{
    class Menu
    {
        private int index;
        private List<string> menuItem;
        public Menu()
        {
            index = 0;
            menuItem = new List<string>
            {
                "Rectangle",
                "Ellipse",
                "Trapeze",
                "Line",
                "Exit"
            };

        }
        private string BuildMenu(List<string> menuItem)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < menuItem.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(menuItem[i]);
                Console.ResetColor();
            }
            ConsoleKeyInfo pressKey = Console.ReadKey();
            Console.Clear();
            if (pressKey.Key == ConsoleKey.DownArrow && index != menuItem.Count - 1)
            {
                index++;
            }
            else if (pressKey.Key == ConsoleKey.UpArrow && index != 0)
            {
                index--;
            }
            else if (pressKey.Key == ConsoleKey.Enter)
            {
                return menuItem[index];
            }
            return "";
        }
        private int EnterData()
        {
            int number;
            string data = Console.ReadLine();
            while (int.TryParse(data, out number) == false && number < 0)
            {
                Console.WriteLine("Try again");
                data = Console.ReadLine();
            }
            return number;
        }
        private Color ChooseColor()
        {
            Color color = Color.FromName("Red");
            Console.WriteLine("Enter number of color from 1 to 4");
            Console.WriteLine("1. Red\n2. Green\n3. Yellow\n4. Purple");
            int number;
            string data = Console.ReadLine();
            while (int.TryParse(data, out number) == false && number < 1 && number > 4)
            {
                Console.WriteLine("Try again");
                data = Console.ReadLine();
            }
            switch (number)
            {
                case 1:
                    color = Color.FromName("Red");
                    break;
                case 2:
                    color = Color.FromName("Green");
                    break;
                case 3:
                    color = Color.FromName("Yellow");
                    break;
                case 4:
                    color = Color.FromName("Purple");
                    break;
                default:
                    break;
            }
            return color;
        }
        public void DrawMenu()
        {
            while (true)
            {
                string selectedMenu = BuildMenu(menuItem);
                if (selectedMenu == "Rectangle")
                {
                    Console.Clear();
                    Console.WriteLine("Enter x coordinate");
                    int x = EnterData();
                    Console.WriteLine("Enter y coordinate");
                    int y = EnterData();
                    Console.WriteLine("Enter width");
                    int width = EnterData();
                    Console.WriteLine("Enter height");
                    int height = EnterData();
                    Color color = ChooseColor();
                    DrawFigure.DrawRectangle(x, y, width, height, color);
                    Console.WriteLine("Press something to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (selectedMenu == "Exit")
                {
                    Environment.Exit(0);
                }
                else if (selectedMenu == "Ellipse")
                {
                    Console.Clear();
                    Console.WriteLine("Enter x coordinate");
                    int x = EnterData();
                    Console.WriteLine("Enter y coordinate");
                    int y = EnterData();
                    Console.WriteLine("Enter width");
                    int width = EnterData();
                    Console.WriteLine("Enter height");
                    int height = EnterData();
                    Color color = ChooseColor();
                    DrawFigure.DrawEllipse(x,y,width,height, color);
                    Console.WriteLine("Press something to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (selectedMenu == "Trapeze")
                {
                    Console.Clear();
                    Console.WriteLine("Enter x coordinate");
                    int x = EnterData();
                    Console.WriteLine("Enter y coordinate");
                    int y = EnterData();
                    Console.WriteLine("Enter lower base");
                    int lowerBase = EnterData();
                    Console.WriteLine("Enter upper base");
                    int upperBase = EnterData();
                    Console.WriteLine("Enter height");
                    int height = EnterData();
                    Color color = ChooseColor();
                    DrawFigure.DrawTrapeze(x,y,height, lowerBase, upperBase, color);
                    Console.WriteLine("Press something to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (selectedMenu == "Line")
                {
                    Console.Clear();
                    Console.WriteLine("Enter start x coordinate");
                    int startX = EnterData();
                    Console.WriteLine("Enter start y coordinate");
                    int startY = EnterData();
                    Console.WriteLine("Enter end x coordinate");
                    int endX = EnterData();
                    Console.WriteLine("Enter end y coordinate");
                    int endY = EnterData();
                    Color color = ChooseColor();
                    DrawFigure.DrawLine(startX, startY, endX, endY, color);
                    Console.WriteLine("Press something to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}

