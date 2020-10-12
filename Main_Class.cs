using System;
namespace Group
{
    class Main_Class
    {
        static void Main()
        {
            Console.Title = "Academy Group";
            Console.ForegroundColor = ConsoleColor.White;

            Academy_Group Academy = new Academy_Group();
            ConsoleKeyInfo Input;
            Menu Item = Menu.Add;
            Graphics Layout = new Graphics();

            Academy.Load();
            Layout.Main_Menu();
            Layout.ChangeTextString(Item, ConsoleColor.Yellow);
            do
            {
                Input = Console.ReadKey(true);
                switch (Input.Key)
                {
                    case ConsoleKey.UpArrow:
                        Layout.ChangeTextString(Item, Console.ForegroundColor);
                        Layout.ChangeTextString(Item = Item > Menu.Add ? Item -= Menu.Next : Menu.Edit, ConsoleColor.Yellow);
                        break;
                    case ConsoleKey.DownArrow:
                        Layout.ChangeTextString(Item, Console.ForegroundColor);
                        Layout.ChangeTextString(Item = Item < Menu.Edit ? Item += (byte)Menu.Next : Menu.Add, ConsoleColor.Yellow);
                        break;
                    case ConsoleKey.Enter:
                        Select_Item(Item, Academy);
                        Layout.ChangeTextString(Item = Menu.Add, ConsoleColor.Yellow);
                        break;
                }
            } while (Input.Key != ConsoleKey.Escape);
            Academy.Save();
        }

        static void Select_Item(Menu Item, Academy_Group Academy)
        {
            Console.Clear();
            switch (Item)
            {
                case Menu.Add:
                    Academy.Add();
                    break;
                case Menu.Remove:
                    Academy.Remove();
                    break;
                case Menu.Print:
                    Academy.Print_Config();
                    break;
                case Menu.Sort:
                    Academy.Sort();
                    break;
                case Menu.Search:
                    Academy.Search();
                    break;
                case Menu.Dublicate:
                    Academy.Copy(Academy);
                    break;
                case Menu.Edit:
                    Academy.Edit();
                    break;
            }
        }

    }
}
